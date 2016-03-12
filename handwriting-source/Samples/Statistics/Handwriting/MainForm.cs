using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Accord.Statistics.Analysis;
using Accord.Controls;
using Accord.Math;
using Accord.Statistics.Kernels;
using System.Drawing.Imaging;
using System.IO;
using ZedGraph;
// ReSharper disable SpecifyACultureInStringConversionExplicitly

namespace Handwriting
{
    public partial class MainForm : Form
    {
        // Colors used in the pie graphics.
        private readonly Color[] colors = { Color.YellowGreen, Color.DarkOliveGreen, Color.DarkKhaki, Color.Olive,
            Color.Honeydew, Color.PaleGoldenrod, Color.Indigo, Color.Olive, Color.SeaGreen };


        KernelDiscriminantAnalysis kda;


        public MainForm()
        {
            InitializeComponent();
        }


        #region Data extraction
        private Bitmap Extract(string text)
        {
            var bitmap = new Bitmap(32, 32, PixelFormat.Format32bppRgb);
            var lines = text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            for (var i = 0; i < 32; i++)
            {
                for (var j = 0; j < 32; j++)
                {
                    if (lines[i][j] == '0')
                        bitmap.SetPixel(j, i, Color.White);
                    else bitmap.SetPixel(j, i, Color.Black);
                }
            }
            return bitmap;
        }

        private double[] Extract(Bitmap bmp)
        {
            var features = new double[32 * 32];
            for (var i = 0; i < 32; i++)
                for (var j = 0; j < 32; j++)
                    features[i * 32 + j] = (bmp.GetPixel(j, i).R == 255) ? 0 : 1;

            return features;
        }

        private double[] Preprocess(Bitmap bitmap)
        {
            var features = new double[64];

            for (var m = 0; m < 8; m++)
            {
                for (var n = 0; n < 8; n++)
                {
                    var c = m * 8 + n;
                    for (var i = m * 4; i < m * 4 + 4; i++)
                    {
                        for (var j = n * 4; j < n * 4 + 4; j++)
                        {
                            var pixel = bitmap.GetPixel(j, i);
                            if (pixel.R == 0x00) // white
                                features[c] += 1;
                        }
                    }
                }
            }

            return features;
        }
        #endregion


        #region Form Events
        private void MainForm_Load(object sender, EventArgs e)
        {
            lbStatus.Text = "Click File->Open to load data.";
        }

        private void btnRunAnalysis_Click(object sender, EventArgs e)
        {
            if (dgvAnalysisSource.Rows.Count == 0)
            {
                MessageBox.Show("Please load the training data before clicking this button");
                return;
            }

            lbStatus.Text = "Gathering data. This may take a while...";
            Application.DoEvents();



            // Extract inputs and outputs
            var rows = dgvAnalysisSource.Rows.Count;
            var input = new double[rows, 32 * 32];
            var output = new int[rows];
            for (var i = 0; i < rows; i++)
            {
                input.SetRow(i, (double[])dgvAnalysisSource.Rows[i].Cells["colTrainingFeatures"].Value);
                output[i] = (int)dgvAnalysisSource.Rows[i].Cells["colTrainingLabel"].Value;
            }

            // Create the chosen Kernel with given parameters
            IKernel kernel;
            if (rbGaussian.Checked)
                kernel = new Gaussian((double)numSigma.Value);
            else
                kernel = new Polynomial((int)numDegree.Value, (double)numConstant.Value);

            // Create the Kernel Discriminant Analysis using the selected Kernel
            kda = new KernelDiscriminantAnalysis(input, output, kernel);

            kda.Threshold = (double)numThreshold.Value;
            kda.Regularization = (double)numRegularization.Value;


            lbStatus.Text = "Computing the analysis. This may take a significant amount of time...";
            Application.DoEvents();

            // Compute the analysis. It should take a while.
            kda.Compute();


            // Show information about the analysis in the form
            dgvPrincipalComponents.DataSource = kda.Discriminants;
            dgvFeatureVectors.DataSource = new ArrayDataView(kda.DiscriminantMatrix);
            dgvClasses.DataSource = kda.Classes;

            // Create the component graphs
            CreateComponentCumulativeDistributionGraph(graphCurve);
            CreateComponentDistributionGraph(graphShare);

            lbStatus.Text = "Analysis complete. Click Classify to test the analysis.";

            btnClassify.Enabled = true;
        }

        private void btnClassify_Click(object sender, EventArgs e)
        {
            if (dgvAnalysisTesting.Rows.Count == 0)
            {
                MessageBox.Show("Please load the testing data before clicking this button");
                return;
            }
            else if (kda == null)
            {
                MessageBox.Show("Please perform the analysis before attempting classification");
                return;
            }

            lbStatus.Text = "Classification started. This may take a while...";
            Application.DoEvents();

            var hits = 0;
            progressBar.Visible = true;
            progressBar.Value = 0;
            progressBar.Step = 1;
            progressBar.Maximum = dgvAnalysisTesting.Rows.Count;

            // Extract inputs
            foreach (DataGridViewRow row in dgvAnalysisTesting.Rows)
            {
                var input = (double[])row.Cells["colTestingFeatures"].Value;
                var expected = (int)row.Cells["colTestingExpected"].Value;

                var output = kda.Classify(input);
                row.Cells["colTestingOutput"].Value = output;

                if (expected == output)
                {
                    row.Cells[0].Style.BackColor = Color.LightGreen;
                    row.Cells[1].Style.BackColor = Color.LightGreen;
                    row.Cells[2].Style.BackColor = Color.LightGreen;
                    hits++;
                }
                else
                {
                    row.Cells[0].Style.BackColor = Color.White;
                    row.Cells[1].Style.BackColor = Color.White;
                    row.Cells[2].Style.BackColor = Color.White;
                }

                progressBar.PerformStep();
            }

            progressBar.Visible = false;

            lbStatus.Text =
                $"Classification complete. Hits: {hits}/{dgvAnalysisTesting.Rows.Count} ({(double) hits/dgvAnalysisTesting.Rows.Count:0%})";
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            lbStatus.Text = @"Loading data. This may take a while...";
            Application.DoEvents();
            
            // Load optdigits dataset into the DataGridView
            var trainerReader = new StringReader(Properties.Resources.optdigits_tra);
            var test0Reader = new StringReader(Properties.Resources.optdigits_test0);
            
            dgvAnalysisSource.Rows.Clear();
            dgvAnalysisTesting.Rows.Clear();
            
            while (true)
            {
                var buffer = new char[(32 + 2) * 32];
                var read = trainerReader.ReadBlock(buffer, 0, buffer.Length);
                var label = trainerReader.ReadLine();

                if (read < buffer.Length || label == null) break;

                var bitmap = Extract(new string(buffer));
                var features = Extract(bitmap);
                var clabel = int.Parse(label);
                dgvAnalysisSource.Rows.Add(bitmap, clabel, features);
            }

            while (true)
            {
                var buffer = new char[(32 + 2) * 32];
                var read = test0Reader.ReadBlock(buffer, 0, buffer.Length);
                var label = test0Reader.ReadLine();

                lbStatus.Text = @"Dataset loaded. Click Run analysis to start the analysis.";

                if (read < buffer.Length || label == null) break;

                var bitmap = Extract(new String(buffer));
                var features = Extract(bitmap);
                var clabel = Int32.Parse(label);
                dgvAnalysisTesting.Rows.Add(bitmap, clabel, null, features);
            }

            btnSampleRunAnalysis.Enabled = true;
        }

        private void btnCanvasClassify_Click(object sender, EventArgs e)
        {
            if (kda != null)
            {
                var input = canvas.GetDigit();

                var sinput = new string[input.Length];
                for (var i = 0; i < input.Length; i++)
                    sinput[i] = input[i].ToString();

                // Classify the input vector
                double[] responses;
                var num = kda.Classify(input, out responses);

                // Set the actual classification answer 
                lbCanvasClassification.Text = num.ToString();


                // Scale the responses to a [0,1] interval
                var max = responses.Max();
                var min = responses.Min();

                for (var i = 0; i < responses.Length; i++)
                    responses[i] = Tools.Scale(min, max, 0, 1, responses[i]);

                // Create the bar graph to show the relative responses
                CreateBarGraph(graphClassification, responses);
            }
            // Get the input vector drawn
        }

        private void btnCanvasClear_Click(object sender, EventArgs e)
        {
            canvas?.Clear();
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            btnCanvasClassify_Click(this, EventArgs.Empty);
        }

        private void tbPenWidth_Scroll(object sender, EventArgs e)
        {
            canvas.PenSize = tbPenWidth.Value;
        }

        private void dgvClasses_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvClasses.CurrentRow != null)
            {
                var dclass = (DiscriminantAnalysisClass)dgvClasses.CurrentRow.DataBoundItem;

                var list = new ImageList();

                lvClass.Items.Clear();
                lvClass.LargeImageList = list;
                var idx = dclass.Indexes;
                for (var i = 0; i < idx.Length; i++)
                {
                    {
                        var bitmap = (Bitmap)dgvAnalysisSource.Rows[idx[i]].Cells["colTrainingImage"].Value;
                        list.Images.Add(bitmap);
                    }

                    var item = new ListViewItem(String.Empty, i);
                    lvClass.Items.Add(item);
                }
            }
        }
        #endregion


        #region ZedGraph Creation
        public void CreateComponentCumulativeDistributionGraph(ZedGraphControl zgc)
        {
            var myPane = zgc.GraphPane;

            myPane.CurveList.Clear();

            // Set the titles and axis labels
            myPane.Title.Text = "Component Distribution";
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Tahoma";
            myPane.XAxis.Title.Text = "Components";
            myPane.YAxis.Title.Text = "Percentage";

            var list = new PointPairList();
            foreach (var t in kda.Discriminants)
            {
                list.Add(t.Index, t.CumulativeProportion);
            }

            // Hide the legend
            myPane.Legend.IsVisible = false;

            // Add a curve
            var curve = myPane.AddCurve("label", list, Color.Red, SymbolType.Circle);
            curve.Line.Width = 2.0F;
            curve.Line.IsAntiAlias = true;
            curve.Symbol.Fill = new Fill(Color.White);
            curve.Symbol.Size = 7;

            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.XAxis.Scale.MagAuto = true;
            myPane.YAxis.Scale.MagAuto = true;


            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
            zgc.Invalidate();
        }

        public void CreateComponentDistributionGraph(ZedGraphControl zgc)
        {
            var myPane = zgc.GraphPane;
            myPane.CurveList.Clear();

            // Set the GraphPane title
            myPane.Title.Text = "Component Proportion";
            myPane.Title.FontSpec.Size = 24f;
            myPane.Title.FontSpec.Family = "Tahoma";

            // Fill the pane background with a color gradient
            //myPane.Fill = new Fill(Color.White);

            // No fill for the chart background
            myPane.Chart.Fill.Type = FillType.None;

            myPane.Legend.IsVisible = false;

            // Add some pie slices
            for (var i = 0; i < kda.Discriminants.Count; i++)
            {
                myPane.AddPieSlice(kda.Discriminants[i].Proportion, colors[i % colors.Length], 0.1, kda.Discriminants[i].Index.ToString());
            }
            
            myPane.XAxis.Scale.MinAuto = true;
            myPane.XAxis.Scale.MaxAuto = true;
            myPane.YAxis.Scale.MinAuto = true;
            myPane.YAxis.Scale.MaxAuto = true;
            myPane.XAxis.Scale.MagAuto = true;
            myPane.YAxis.Scale.MagAuto = true;
            
            // Calculate the Axis Scale Ranges
            zgc.AxisChange();
            zgc.Invalidate();
        }

        public void CreateBarGraph(ZedGraphControl zgc, double[] discriminants)
        {
            var myPane = zgc.GraphPane;

            myPane.CurveList.Clear();

            myPane.Title.IsVisible = false;
            myPane.Legend.IsVisible = false;
            myPane.Border.IsVisible = false;
            myPane.Border.IsVisible = false;
            myPane.Margin.Bottom = 20f;
            myPane.Margin.Right = 20f;
            myPane.Margin.Left = 20f;
            myPane.Margin.Top = 30f;

            myPane.YAxis.Title.IsVisible = true;
            myPane.YAxis.IsVisible = true;
            myPane.YAxis.MinorGrid.IsVisible = false;
            myPane.YAxis.MajorGrid.IsVisible = false;
            myPane.YAxis.IsAxisSegmentVisible = false;
            myPane.YAxis.Scale.Max = 9.5;
            myPane.YAxis.Scale.Min = -0.5;
            myPane.YAxis.MajorGrid.IsZeroLine = false;
            myPane.YAxis.Title.Text = "Classes";
            myPane.YAxis.MinorTic.IsOpposite = false;
            myPane.YAxis.MajorTic.IsOpposite = false;
            myPane.YAxis.MinorTic.IsInside = false;
            myPane.YAxis.MajorTic.IsInside = false;
            myPane.YAxis.MinorTic.IsOutside = false;
            myPane.YAxis.MajorTic.IsOutside = false;

            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.XAxis.MajorTic.IsOpposite = false;
            myPane.XAxis.Title.IsVisible = true;
            myPane.XAxis.Title.Text = "Relative class response";
            myPane.XAxis.IsVisible = true;
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 100;
            myPane.XAxis.IsAxisSegmentVisible = false;
            myPane.XAxis.MajorGrid.IsVisible = false;
            myPane.XAxis.MajorGrid.IsZeroLine = false;
            myPane.XAxis.MinorTic.IsOpposite = false;
            myPane.XAxis.MinorTic.IsInside = false;
            myPane.XAxis.MinorTic.IsOutside = false;
            myPane.XAxis.Scale.Format = "0'%";


            // Create data points for three BarItems using Random data
            var list = new PointPairList();

            for (var i = 0; i < discriminants.Length; i++)
                list.Add(discriminants[i] * 100, i);

            myPane.AddBar("b", list, Color.DarkBlue);

            // Set BarBase to the YAxis for horizontal bars
            myPane.BarSettings.Base = BarBase.Y;


            zgc.AxisChange();
            zgc.Invalidate();
        }

        #endregion

        private void canvas_Load(object sender, EventArgs e)
        {

        }
    }
}
