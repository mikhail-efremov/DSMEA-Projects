﻿// Accord Math Library
// Accord.NET framework
// http://www.crsouza.com
//
// Copyright © César Souza, 2009
// cesarsouza at gmail.com
//

using System;

namespace Accord.Math
{
    /// <summary>
    ///   Set of special mathematic functions.
    /// </summary>
    /// <remarks>
    ///   References:
    ///   - Cephes Math Library, http://www.netlib.org/cephes/
    /// </remarks>
    public static class Special
    {

        private const double MACHEP = 1.11022302462515654042E-16;
        private const double MAXLOG = 7.09782712893383996732E2;
        private const double MINLOG = -7.451332191019412076235E2;
        private const double MAXGAM = 171.624376956302725;
        private const double SQRTPI = 2.50662827463100050242E0;
        private const double SQRTH = 7.07106781186547524401E-1;
        private const double LOGPI = 1.14472988584940017414;



        /// <summary>
        ///   Gamma function of the specified value.
        /// </summary>
        public static double Gamma(double x)
        {
            double[] P = {
						 1.60119522476751861407E-4,
						 1.19135147006586384913E-3,
						 1.04213797561761569935E-2,
						 4.76367800457137231464E-2,
						 2.07448227648435975150E-1,
						 4.94214826801497100753E-1,
						 9.99999999999999996796E-1
					 };
            double[] Q = {
						 -2.31581873324120129819E-5,
						 5.39605580493303397842E-4,
						 -4.45641913851797240494E-3,
						 1.18139785222060435552E-2,
						 3.58236398605498653373E-2,
						 -2.34591795718243348568E-1,
						 7.14304917030273074085E-2,
						 1.00000000000000000320E0
					 };

            double p, z;

            double q = System.Math.Abs(x);

            if (q > 33.0)
            {
                if (x < 0.0)
                {
                    p = System.Math.Floor(q);

                    if (p == q)
                        throw new OverflowException();

                    z = q - p;
                    if (z > 0.5)
                    {
                        p += 1.0;
                        z = q - p;
                    }
                    z = q * System.Math.Sin(System.Math.PI * z);

                    if (z == 0.0)
                        throw new OverflowException();

                    z = System.Math.Abs(z);
                    z = System.Math.PI / (z * Stirf(q));

                    return -z;
                }
                else
                {
                    return Stirf(x);
                }
            }

            z = 1.0;
            while (x >= 3.0)
            {
                x -= 1.0;
                z *= x;
            }

            while (x < 0.0)
            {
                if (x == 0.0)
                {
                    throw new ArithmeticException();
                }
                else if (x > -1.0E-9)
                {
                    return (z / ((1.0 + 0.5772156649015329 * x) * x));
                }
                z /= x;
                x += 1.0;
            }

            while (x < 2.0)
            {
                if (x == 0.0)
                {
                    throw new ArithmeticException();
                }
                else if (x < 1.0E-9)
                {
                    return (z / ((1.0 + 0.5772156649015329 * x) * x));
                }

                z /= x;
                x += 1.0;
            }

            if ((x == 2.0) || (x == 3.0)) return z;

            x -= 2.0;
            p = Polevl(x, P, 6);
            q = Polevl(x, Q, 7);
            return z * p / q;

        }

        /// <summary>
        ///   Regularized Gamma function (P)
        /// </summary>
        public static double Rgamma(double a, double z)
        {
            return Igam(a, z) / Gamma(a);
        }

        /// <summary>
        ///   Digamma function.
        /// </summary>
        public static double Digamma(double x)
        {
            double s = 0;
            double w = 0;
            double y = 0;
            double z = 0;
            double nz = 0;

            bool negative = false;

            if (x <= 0.0)
            {
                negative = true;
                double q = x;
                double p = (int)System.Math.Floor(q);

                if (p == q)
                    throw new OverflowException("digamma");

                nz = q - p;

                if (nz != 0.5)
                {
                    if (nz > 0.5)
                    {
                        p = p + 1.0;
                        nz = q - p;
                    }
                    nz = System.Math.PI / System.Math.Tan(System.Math.PI * nz);
                }
                else
                {
                    nz = 0.0;
                }

                x = 1.0 - x;
            }

            if (x <= 10.0 & x == System.Math.Floor(x))
            {
                y = 0.0;
                int n = (int)System.Math.Floor(x);
                for (int i = 1; i <= n - 1; i++)
                {
                    w = i;
                    y = y + 1.0 / w;
                }
                y = y - 0.57721566490153286061;
            }
            else
            {
                s = x;
                w = 0.0;

                while (s < 10.0)
                {
                    w = w + 1.0 / s;
                    s = s + 1.0;
                }

                if (s < 1.0E17)
                {
                    z = 1.0 / (s * s);

                    double polv = 8.33333333333333333333E-2;
                    polv = polv * z - 2.10927960927960927961E-2;
                    polv = polv * z + 7.57575757575757575758E-3;
                    polv = polv * z - 4.16666666666666666667E-3;
                    polv = polv * z + 3.96825396825396825397E-3;
                    polv = polv * z - 8.33333333333333333333E-3;
                    polv = polv * z + 8.33333333333333333333E-2;
                    y = z * polv;
                }
                else
                {
                    y = 0.0;
                }
                y = System.Math.Log(s) - 0.5 / s - y - w;
            }

            if (negative == true)
            {
                y = y - nz;
            }

            return y;
        }

        /// <summary>
        ///   Gamma function as computed by Stirling's formula.
        /// </summary>
        public static double Stirf(double x)
        {
            double[] STIR = {
							7.87311395793093628397E-4,
							-2.29549961613378126380E-4,
							-2.68132617805781232825E-3,
							3.47222221605458667310E-3,
							8.33333333333482257126E-2,
		};
            double MAXSTIR = 143.01608;

            double w = 1.0 / x;
            double y = System.Math.Exp(x);

            w = 1.0 + w * Polevl(w, STIR, 4);

            if (x > MAXSTIR)
            {
                double v = System.Math.Pow(x, 0.5 * x - 0.25);
                y = v * (v / y);
            }
            else
            {
                y = System.Math.Pow(x, x - 0.5) / y;
            }
            y = SQRTPI * y * w;
            return y;
        }

        /// <summary>
        ///   Complemented incomplete gamma function.
        /// </summary>
        public static double Igamc(double a, double x)
        {
            double big = 4.503599627370496e15;
            double biginv = 2.22044604925031308085e-16;
            double ans, ax, c, yc, r, t, y, z;
            double pk, pkm1, pkm2, qk, qkm1, qkm2;

            if (x <= 0 || a <= 0) return 1.0;

            if (x < 1.0 || x < a) return 1.0 - Igam(a, x);

            ax = a * System.Math.Log(x) - x - Lgamma(a);
            if (ax < -MAXLOG) return 0.0;

            ax = System.Math.Exp(ax);

            /* continued fraction */
            y = 1.0 - a;
            z = x + y + 1.0;
            c = 0.0;
            pkm2 = 1.0;
            qkm2 = x;
            pkm1 = x + 1.0;
            qkm1 = z * x;
            ans = pkm1 / qkm1;

            do
            {
                c += 1.0;
                y += 1.0;
                z += 2.0;
                yc = y * c;
                pk = pkm1 * z - pkm2 * yc;
                qk = qkm1 * z - qkm2 * yc;
                if (qk != 0)
                {
                    r = pk / qk;
                    t = System.Math.Abs((ans - r) / r);
                    ans = r;
                }
                else
                    t = 1.0;

                pkm2 = pkm1;
                pkm1 = pk;
                qkm2 = qkm1;
                qkm1 = qk;
                if (System.Math.Abs(pk) > big)
                {
                    pkm2 *= biginv;
                    pkm1 *= biginv;
                    qkm2 *= biginv;
                    qkm1 *= biginv;
                }
            } while (t > MACHEP);

            return ans * ax;
        }

        /// <summary>
        ///   Incomplete gamma function.
        /// </summary>
        public static double Igam(double a, double x)
        {
            double ans, ax, c, r;

            if (x <= 0 || a <= 0) return 0.0;

            if (x > 1.0 && x > a) return 1.0 - Igamc(a, x);

            ax = a * System.Math.Log(x) - x - Lgamma(a);
            if (ax < -MAXLOG) return (0.0);

            ax = System.Math.Exp(ax);

            r = a;
            c = 1.0;
            ans = 1.0;

            do
            {
                r += 1.0;
                c *= x / r;
                ans += c;
            } while (c / ans > MACHEP);

            return (ans * ax / a);

        }

        /// <summary>
        ///   Chi-square function (left hand tail).
        /// </summary>
        /// <remarks>
        ///   Returns the area under the left hand tail (from 0 to x)
        ///   of the Chi square probability density function with
        ///   df degrees of freedom.
        /// </remarks>
        /// <param name="df">degrees of freedom</param>
        /// <param name="x">double value</param>
        /// <returns></returns>
        public static double ChiSq(double df, double x)
        {
            if (x < 0.0 || df < 1.0) return 0.0;

            return Igam(df / 2.0, x / 2.0);

        }

        /// <summary>
        ///  Chi-square function (right hand tail).
        /// </summary>
        /// <remarks>
        ///  Returns the area under the right hand tail (from x to
        ///  infinity) of the Chi square probability density function
        ///  with df degrees of freedom:
        /// </remarks>
        /// <param name="df">degrees of freedom</param>
        /// <param name="x">double value</param>
        /// <returns></returns>
        public static double ChiSqc(double df, double x)
        {
            if (x < 0.0 || df < 1.0) return 0.0;

            return Igamc(df / 2.0, x / 2.0);

        }

        /// <summary>
        ///   Sum of the first k terms of the Poisson distribution.
        /// </summary>
        /// <param name="k">number of terms</param>
        /// <param name="x">double value</param>
        /// <returns></returns>
        public static double Poisson(int k, double x)
        {
            if (k < 0 || x < 0) return 0.0;

            return Igamc((double)(k + 1), x);
        }

        /// <summary>
        ///   Sum of the terms k+1 to infinity of the Poisson distribution.
        /// </summary>
        /// <param name="k">start</param>
        /// <param name="x">double value</param>
        /// <returns></returns>
        public static double Poissonc(int k, double x)
        {
            if (k < 0 || x < 0) return 0.0;

            return Igam((double)(k + 1), x);
        }

        /// <summary>
        ///   Area under the Gaussian probability density function,
        ///   integrated from minus infinity to the given value.
        /// </summary>
        /// <returns>
        ///   The area under the Gaussian p.d.f. integrated
        ///   from minus infinity to the given value.
        /// </returns>
        public static double Normal(double value)
        {
            double x, y, z;

            x = value * SQRTH;
            z = System.Math.Abs(x);

            if (z < SQRTH) y = 0.5 + 0.5 * Erf(x);
            else
            {
                y = 0.5 * Erfc(z);
                if (x > 0) y = 1.0 - y;
            }

            return y;
        }

        /// <summary>
        ///   Complementary error function of the specified value.
        /// </summary>
        /// <remarks>
        ///   http://mathworld.wolfram.com/Erfc.html
        /// </remarks>
        public static double Erfc(double value)
        {
            double x, y, z, p, q;

            double[] P = {
						 2.46196981473530512524E-10,
						 5.64189564831068821977E-1,
						 7.46321056442269912687E0,
						 4.86371970985681366614E1,
						 1.96520832956077098242E2,
						 5.26445194995477358631E2,
						 9.34528527171957607540E2,
						 1.02755188689515710272E3,
						 5.57535335369399327526E2
					 };
            double[] Q = {
						 //1.0
						 1.32281951154744992508E1,
						 8.67072140885989742329E1,
						 3.54937778887819891062E2,
						 9.75708501743205489753E2,
						 1.82390916687909736289E3,
						 2.24633760818710981792E3,
						 1.65666309194161350182E3,
						 5.57535340817727675546E2
					 };

            double[] R = {
						 5.64189583547755073984E-1,
						 1.27536670759978104416E0,
						 5.01905042251180477414E0,
						 6.16021097993053585195E0,
						 7.40974269950448939160E0,
						 2.97886665372100240670E0
					 };
            double[] S = {
						 //1.00000000000000000000E0, 
						 2.26052863220117276590E0,
						 9.39603524938001434673E0,
						 1.20489539808096656605E1,
						 1.70814450747565897222E1,
						 9.60896809063285878198E0,
						 3.36907645100081516050E0
					 };

            if (value < 0.0) x = -value;
            else x = value;

            if (x < 1.0) return 1.0 - Erf(value);

            z = -value * value;

            if (z < -MAXLOG)
            {
                if (value < 0) return (2.0);
                else return (0.0);
            }

            z = System.Math.Exp(z);

            if (x < 8.0)
            {
                p = Polevl(x, P, 8);
                q = P1evl(x, Q, 8);
            }
            else
            {
                p = Polevl(x, R, 5);
                q = P1evl(x, S, 6);
            }

            y = (z * p) / q;

            if (value < 0) y = 2.0 - y;

            if (y == 0.0)
            {
                if (value < 0) return 2.0;
                else return (0.0);
            }


            return y;
        }

        /// <summary>
        ///   Error function of the specified value.
        /// </summary>
        public static double Erf(double x)
        {
            double y, z;
            double[] T = {
						 9.60497373987051638749E0,
						 9.00260197203842689217E1,
						 2.23200534594684319226E3,
						 7.00332514112805075473E3,
						 5.55923013010394962768E4
					 };
            double[] U = {
						 //1.00000000000000000000E0,
						 3.35617141647503099647E1,
						 5.21357949780152679795E2,
						 4.59432382970980127987E3,
						 2.26290000613890934246E4,
						 4.92673942608635921086E4
					 };

            if (System.Math.Abs(x) > 1.0)
                return (1.0 - Erfc(x));

            z = x * x;
            y = x * Polevl(z, T, 4) / P1evl(z, U, 5);

            return y;
        }

        /// <summary>
        ///   Natural logarithm of gamma function.
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static double Lgamma(double x)
        {
            double p, q, w, z;

            double[] A = {
						 8.11614167470508450300E-4,
						 -5.95061904284301438324E-4,
						 7.93650340457716943945E-4,
						 -2.77777777730099687205E-3,
						 8.33333333333331927722E-2
					 };
            double[] B = {
						 -1.37825152569120859100E3,
						 -3.88016315134637840924E4,
						 -3.31612992738871184744E5,
						 -1.16237097492762307383E6,
						 -1.72173700820839662146E6,
						 -8.53555664245765465627E5
					 };
            double[] C = {
						 /* 1.00000000000000000000E0, */
						 -3.51815701436523470549E2,
						 -1.70642106651881159223E4,
						 -2.20528590553854454839E5,
						 -1.13933444367982507207E6,
						 -2.53252307177582951285E6,
						 -2.01889141433532773231E6
					 };

            if (x < -34.0)
            {
                q = -x;
                w = Lgamma(q);
                p = System.Math.Floor(q);

                if (p == q)
                    throw new OverflowException("lgamma");

                z = q - p;
                if (z > 0.5)
                {
                    p += 1.0;
                    z = p - q;
                }
                z = q * System.Math.Sin(System.Math.PI * z);

                if (z == 0.0)
                    throw new OverflowException("lgamma");

                z = LOGPI - System.Math.Log(z) - w;
                return z;
            }

            if (x < 13.0)
            {
                z = 1.0;
                while (x >= 3.0)
                {
                    x -= 1.0;
                    z *= x;
                }
                while (x < 2.0)
                {
                    if (x == 0.0)
                        throw new OverflowException("lgamma");

                    z /= x;
                    x += 1.0;
                }
                if (z < 0.0) z = -z;
                if (x == 2.0) return System.Math.Log(z);
                x -= 2.0;
                p = x * Polevl(x, B, 5) / P1evl(x, C, 6);
                return (System.Math.Log(z) + p);
            }

            if (x > 2.556348e305)
                throw new OverflowException("lgamma");

            q = (x - 0.5) * System.Math.Log(x) - x + 0.91893853320467274178;
            if (x > 1.0e8) return (q);

            p = 1.0 / (x * x);
            if (x >= 1000.0)
                q += ((7.9365079365079365079365e-4 * p
                    - 2.7777777777777777777778e-3) * p
                    + 0.0833333333333333333333) / x;
            else
                q += Polevl(p, A, 4) / x;
            return q;
        }

        /// <summary>
        ///   Incomplete beta function evaluated from zero to xx.
        /// </summary>
        public static double Ibeta(double aa, double bb, double xx)
        {
            double a, b, t, x, xc, w, y;
            bool flag;

            if (aa <= 0.0)
                throw new ArgumentOutOfRangeException("aa", "domain error");
            if (bb <= 0.0)
                throw new ArgumentOutOfRangeException("bb", "domain error");

            if ((xx <= 0.0) || (xx >= 1.0))
            {
                if (xx == 0.0) return 0.0;
                if (xx == 1.0) return 1.0;
                throw new ArgumentOutOfRangeException("xx", "domain error");
            }

            flag = false;
            if ((bb * xx) <= 1.0 && xx <= 0.95)
            {
                t = PowerSeries(aa, bb, xx);
                return t;
            }

            w = 1.0 - xx;

            if (xx > (aa / (aa + bb)))
            {
                flag = true;
                a = bb;
                b = aa;
                xc = xx;
                x = w;
            }
            else
            {
                a = aa;
                b = bb;
                xc = w;
                x = xx;
            }

            if (flag && (b * x) <= 1.0 && x <= 0.95)
            {
                t = PowerSeries(a, b, x);
                if (t <= MACHEP) t = 1.0 - MACHEP;
                else t = 1.0 - t;
                return t;
            }

            y = x * (a + b - 2.0) - (a - 1.0);
            if (y < 0.0)
                w = Incbcf(a, b, x);
            else
                w = Incbd(a, b, x) / xc;


            y = a * System.Math.Log(x);
            t = b * System.Math.Log(xc);
            if ((a + b) < MAXGAM && System.Math.Abs(y) < MAXLOG && System.Math.Abs(t) < MAXLOG)
            {
                t = System.Math.Pow(xc, b);
                t *= System.Math.Pow(x, a);
                t /= a;
                t *= w;
                t *= Gamma(a + b) / (Gamma(a) * Gamma(b));
                if (flag)
                {
                    if (t <= MACHEP) t = 1.0 - MACHEP;
                    else t = 1.0 - t;
                }
                return t;
            }

            y += t + Lgamma(a + b) - Lgamma(a) - Lgamma(b);
            y += System.Math.Log(w / a);
            if (y < MINLOG)
                t = 0.0;
            else
                t = System.Math.Exp(y);

            if (flag)
            {
                if (t <= MACHEP) t = 1.0 - MACHEP;
                else t = 1.0 - t;
            }
            return t;
        }

        /// <summary>
        ///   Continued fraction expansion #1 for incomplete beta integral.
        /// </summary>
        public static double Incbcf(double a, double b, double x)
        {
            double xk, pk, pkm1, pkm2, qk, qkm1, qkm2;
            double k1, k2, k3, k4, k5, k6, k7, k8;
            double r, t, ans, thresh;
            int n;
            double big = 4.503599627370496e15;
            double biginv = 2.22044604925031308085e-16;

            k1 = a;
            k2 = a + b;
            k3 = a;
            k4 = a + 1.0;
            k5 = 1.0;
            k6 = b - 1.0;
            k7 = k4;
            k8 = a + 2.0;

            pkm2 = 0.0;
            qkm2 = 1.0;
            pkm1 = 1.0;
            qkm1 = 1.0;
            ans = 1.0;
            r = 1.0;
            n = 0;
            thresh = 3.0 * MACHEP;

            do
            {
                xk = -(x * k1 * k2) / (k3 * k4);
                pk = pkm1 + pkm2 * xk;
                qk = qkm1 + qkm2 * xk;
                pkm2 = pkm1;
                pkm1 = pk;
                qkm2 = qkm1;
                qkm1 = qk;

                xk = (x * k5 * k6) / (k7 * k8);
                pk = pkm1 + pkm2 * xk;
                qk = qkm1 + qkm2 * xk;
                pkm2 = pkm1;
                pkm1 = pk;
                qkm2 = qkm1;
                qkm1 = qk;

                if (qk != 0) r = pk / qk;
                if (r != 0)
                {
                    t = System.Math.Abs((ans - r) / r);
                    ans = r;
                }
                else
                    t = 1.0;

                if (t < thresh) return ans;

                k1 += 1.0;
                k2 += 1.0;
                k3 += 2.0;
                k4 += 2.0;
                k5 += 1.0;
                k6 -= 1.0;
                k7 += 2.0;
                k8 += 2.0;

                if ((System.Math.Abs(qk) + System.Math.Abs(pk)) > big)
                {
                    pkm2 *= biginv;
                    pkm1 *= biginv;
                    qkm2 *= biginv;
                    qkm1 *= biginv;
                }
                if ((System.Math.Abs(qk) < biginv) || (System.Math.Abs(pk) < biginv))
                {
                    pkm2 *= big;
                    pkm1 *= big;
                    qkm2 *= big;
                    qkm1 *= big;
                }
            } while (++n < 300);

            return ans;
        }

        /// <summary>
        ///   Continued fraction expansion #2 for incomplete beta integral.
        /// </summary>
        public static double Incbd(double a, double b, double x)
        {
            double xk, pk, pkm1, pkm2, qk, qkm1, qkm2;
            double k1, k2, k3, k4, k5, k6, k7, k8;
            double r, t, ans, z, thresh;
            int n;
            double big = 4.503599627370496e15;
            double biginv = 2.22044604925031308085e-16;

            k1 = a;
            k2 = b - 1.0;
            k3 = a;
            k4 = a + 1.0;
            k5 = 1.0;
            k6 = a + b;
            k7 = a + 1.0;
            ;
            k8 = a + 2.0;

            pkm2 = 0.0;
            qkm2 = 1.0;
            pkm1 = 1.0;
            qkm1 = 1.0;
            z = x / (1.0 - x);
            ans = 1.0;
            r = 1.0;
            n = 0;
            thresh = 3.0 * MACHEP;
            do
            {
                xk = -(z * k1 * k2) / (k3 * k4);
                pk = pkm1 + pkm2 * xk;
                qk = qkm1 + qkm2 * xk;
                pkm2 = pkm1;
                pkm1 = pk;
                qkm2 = qkm1;
                qkm1 = qk;

                xk = (z * k5 * k6) / (k7 * k8);
                pk = pkm1 + pkm2 * xk;
                qk = qkm1 + qkm2 * xk;
                pkm2 = pkm1;
                pkm1 = pk;
                qkm2 = qkm1;
                qkm1 = qk;

                if (qk != 0) r = pk / qk;
                if (r != 0)
                {
                    t = System.Math.Abs((ans - r) / r);
                    ans = r;
                }
                else
                    t = 1.0;

                if (t < thresh) return ans;

                k1 += 1.0;
                k2 -= 1.0;
                k3 += 2.0;
                k4 += 2.0;
                k5 += 1.0;
                k6 += 1.0;
                k7 += 2.0;
                k8 += 2.0;

                if ((System.Math.Abs(qk) + System.Math.Abs(pk)) > big)
                {
                    pkm2 *= biginv;
                    pkm1 *= biginv;
                    qkm2 *= biginv;
                    qkm1 *= biginv;
                }
                if ((System.Math.Abs(qk) < biginv) || (System.Math.Abs(pk) < biginv))
                {
                    pkm2 *= big;
                    pkm1 *= big;
                    qkm2 *= big;
                    qkm1 *= big;
                }
            } while (++n < 300);

            return ans;
        }

        /// <summary>
        ///   Power series for incomplete beta integral. Use when b*x
        ///   is small and x not too close to 1.
        /// </summary>
        public static double PowerSeries(double a, double b, double x)
        {
            double s, t, u, v, n, t1, z, ai;

            ai = 1.0 / a;
            u = (1.0 - b) * x;
            v = u / (a + 1.0);
            t1 = v;
            t = u;
            n = 2.0;
            s = 0.0;
            z = MACHEP * ai;
            while (System.Math.Abs(v) > z)
            {
                u = (n - b) * x / n;
                t *= u;
                v = t / (a + n);
                s += v;
                n += 1.0;
            }
            s += t1;
            s += ai;

            u = a * System.Math.Log(x);
            if ((a + b) < MAXGAM && System.Math.Abs(u) < MAXLOG)
            {
                t = Gamma(a + b) / (Gamma(a) * Gamma(b));
                s = s * t * System.Math.Pow(x, a);
            }
            else
            {
                t = Lgamma(a + b) - Lgamma(a) - Lgamma(b) + u + System.Math.Log(s);
                if (t < MINLOG) s = 0.0;
                else s = System.Math.Exp(t);
            }
            return s;
        }

        /// <summary>
        ///   Evaluates polynomial of degree N
        /// </summary>
        public static double Polevl(double x, double[] coef, int N)
        {
            double ans;

            ans = coef[0];

            for (int i = 1; i <= N; i++)
            {
                ans = ans * x + coef[i];
            }

            return ans;
        }

        /// <summary>
        ///   Evaluates polynomial of degree N with assumption that coef[N] = 1.0
        /// </summary>
        public static double P1evl(double x, double[] coef, int N)
        {
            double ans;

            ans = x + coef[0];

            for (int i = 1; i < N; i++)
            {
                ans = ans * x + coef[i];
            }

            return ans;
        }

        /// <summary>
        /// Returns the Bessel function of order 0 of the specified number.
        /// </summary>
        public static double BesselJ0(double x)
        {
            double ax;

            if ((ax = System.Math.Abs(x)) < 8.0)
            {
                double y = x * x;
                double ans1 = 57568490574.0 + y * (-13362590354.0 + y * (651619640.7
                    + y * (-11214424.18 + y * (77392.33017 + y * (-184.9052456)))));
                double ans2 = 57568490411.0 + y * (1029532985.0 + y * (9494680.718
                    + y * (59272.64853 + y * (267.8532712 + y * 1.0))));

                return ans1 / ans2;

            }
            else
            {
                double z = 8.0 / ax;
                double y = z * z;
                double xx = ax - 0.785398164;
                double ans1 = 1.0 + y * (-0.1098628627e-2 + y * (0.2734510407e-4
                    + y * (-0.2073370639e-5 + y * 0.2093887211e-6)));
                double ans2 = -0.1562499995e-1 + y * (0.1430488765e-3
                    + y * (-0.6911147651e-5 + y * (0.7621095161e-6
                    - y * 0.934935152e-7)));

                return System.Math.Sqrt(0.636619772 / ax) *
                    (System.Math.Cos(xx) * ans1 - z * System.Math.Sin(xx) * ans2);
            }
        }

        /// <summary>
        /// Returns the Bessel function of order 1 of the specified number.
        /// </summary>
        public static double BesselJ(double x)
        {
            double ax;
            double y;
            double ans1, ans2;

            if ((ax = System.Math.Abs(x)) < 8.0)
            {
                y = x * x;
                ans1 = x * (72362614232.0 + y * (-7895059235.0 + y * (242396853.1
                    + y * (-2972611.439 + y * (15704.48260 + y * (-30.16036606))))));
                ans2 = 144725228442.0 + y * (2300535178.0 + y * (18583304.74
                    + y * (99447.43394 + y * (376.9991397 + y * 1.0))));
                return ans1 / ans2;
            }
            else
            {
                double z = 8.0 / ax;
                double xx = ax - 2.356194491;
                y = z * z;

                ans1 = 1.0 + y * (0.183105e-2 + y * (-0.3516396496e-4
                    + y * (0.2457520174e-5 + y * (-0.240337019e-6))));
                ans2 = 0.04687499995 + y * (-0.2002690873e-3
                    + y * (0.8449199096e-5 + y * (-0.88228987e-6
                    + y * 0.105787412e-6)));
                double ans = System.Math.Sqrt(0.636619772 / ax) *
                    (System.Math.Cos(xx) * ans1 - z * System.Math.Sin(xx) * ans2);
                if (x < 0.0) ans = -ans;
                return ans;
            }
        }

        /// <summary>
        /// Returns the Bessel function of order n of the specified number.
        /// </summary>
        public static double BesselJ(int n, double x)
        {
            int j, m;
            double ax, bj, bjm, bjp, sum, tox, ans;
            bool jsum;

            double ACC = 40.0;
            double BIGNO = 1.0e+10;
            double BIGNI = 1.0e-10;

            if (n == 0) return BesselJ0(x);
            if (n == 1) return BesselJ(x);

            ax = System.Math.Abs(x);
            if (ax == 0.0) return 0.0;
            else if (ax > (double)n)
            {
                tox = 2.0 / ax;
                bjm = BesselJ0(ax);
                bj = BesselJ(ax);
                for (j = 1; j < n; j++)
                {
                    bjp = j * tox * bj - bjm;
                    bjm = bj;
                    bj = bjp;
                }
                ans = bj;
            }
            else
            {
                tox = 2.0 / ax;
                m = 2 * ((n + (int)System.Math.Sqrt(ACC * n)) / 2);
                jsum = false;
                bjp = ans = sum = 0.0;
                bj = 1.0;
                for (j = m; j > 0; j--)
                {
                    bjm = j * tox * bj - bjp;
                    bjp = bj;
                    bj = bjm;
                    if (System.Math.Abs(bj) > BIGNO)
                    {
                        bj *= BIGNI;
                        bjp *= BIGNI;
                        ans *= BIGNI;
                        sum *= BIGNI;
                    }
                    if (jsum) sum += bj;
                    jsum = !jsum;
                    if (j == n) ans = bjp;
                }
                sum = 2.0 * sum - bj;
                ans /= sum;
            }
            return x < 0.0 && n % 2 == 1 ? -ans : ans;
        }

        /// <summary>
        /// Returns the Bessel function of the second kind, of order 0 of the specified number.
        /// </summary>
        public static double BesselY0(double x)
        {
            if (x < 8.0)
            {
                double y = x * x;

                double ans1 = -2957821389.0 + y * (7062834065.0 + y * (-512359803.6
                    + y * (10879881.29 + y * (-86327.92757 + y * 228.4622733))));
                double ans2 = 40076544269.0 + y * (745249964.8 + y * (7189466.438
                    + y * (47447.26470 + y * (226.1030244 + y * 1.0))));

                return (ans1 / ans2) + 0.636619772 * BesselJ0(x) * System.Math.Log(x);
            }
            else
            {
                double z = 8.0 / x;
                double y = z * z;
                double xx = x - 0.785398164;

                double ans1 = 1.0 + y * (-0.1098628627e-2 + y * (0.2734510407e-4
                    + y * (-0.2073370639e-5 + y * 0.2093887211e-6)));
                double ans2 = -0.1562499995e-1 + y * (0.1430488765e-3
                    + y * (-0.6911147651e-5 + y * (0.7621095161e-6
                    + y * (-0.934945152e-7))));
                return System.Math.Sqrt(0.636619772 / x) *
                    (System.Math.Sin(xx) * ans1 + z * System.Math.Cos(xx) * ans2);
            }
        }

        /// <summary>
        /// Returns the Bessel function of the second kind, of order 1 of the specified number.
        /// </summary>
        public static double BesselY(double x)
        {
            if (x < 8.0)
            {
                double y = x * x;
                double ans1 = x * (-0.4900604943e13 + y * (0.1275274390e13
                    + y * (-0.5153438139e11 + y * (0.7349264551e9
                    + y * (-0.4237922726e7 + y * 0.8511937935e4)))));
                double ans2 = 0.2499580570e14 + y * (0.4244419664e12
                    + y * (0.3733650367e10 + y * (0.2245904002e8
                    + y * (0.1020426050e6 + y * (0.3549632885e3 + y)))));
                return (ans1 / ans2) + 0.636619772 * (BesselJ(x) * System.Math.Log(x) - 1.0 / x);
            }
            else
            {
                double z = 8.0 / x;
                double y = z * z;
                double xx = x - 2.356194491;
                double ans1 = 1.0 + y * (0.183105e-2 + y * (-0.3516396496e-4
                    + y * (0.2457520174e-5 + y * (-0.240337019e-6))));
                double ans2 = 0.04687499995 + y * (-0.2002690873e-3
                    + y * (0.8449199096e-5 + y * (-0.88228987e-6
                    + y * 0.105787412e-6)));
                return System.Math.Sqrt(0.636619772 / x) *
                    (System.Math.Sin(xx) * ans1 + z * System.Math.Cos(xx) * ans2);
            }
        }

        /// <summary>
        /// Returns the Bessel function of the second kind, of order n of the specified number.
        /// </summary>
        public static double BesselY(int n, double x)
        {
            double by, bym, byp, tox;

            if (n == 0) return BesselY0(x);
            if (n == 1) return BesselY(x);

            tox = 2.0 / x;
            by = BesselY(x);
            bym = BesselY0(x);
            for (int j = 1; j < n; j++)
            {
                byp = j * tox * by - bym;
                bym = by;
                by = byp;
            }
            return by;
        }

        /// <summary>
        ///   Computes the Basic Spline of order n
        /// </summary>
        public static double BSpline(int n, double x)
        {
            // ftp://ftp.esat.kuleuven.ac.be/pub/SISTA/hamers/PhD_bhamers.pdf
            // http://sepwww.stanford.edu/public/docs/sep105/sergey2/paper_html/node5.html

            double a = 1.0 / Tools.Factorial(n);
            double c;

            bool positive = true;
            for (int k = 0; k <= n + 1; k++)
            {
                c = Binomial(n + 1, k) * Tools.TruncPower(x + (n + 1.0) / 2.0 - k, n);
                a += positive ? c : -c;
                positive = !positive;
            }

            return a;
        }

        /// <summary>
        ///   Computes the Binomial Coefficients C(n,k).
        /// </summary>
        public static double Binomial(int n, int k)
        {
            double[] b = new double[n + 1];
            b[0] = 1;

            for (int i = 1; i <= n; ++i)
            {
                b[i] = 1;
                for (int j = i - 1; j > 0; --j)
                    b[j] += b[j - 1];
            }

            return b[k];
        }

    }
}
