using System.Windows;

namespace lab1
{
    internal class BisectionCalc
    {
        static double Epsilon = Math.Pow(10, -3);

        public double equation1(double x)
        {
            return Math.Pow(3, x) + 2 * x - 3;
        }

        public double equation2(double x)
        {
            return 3 * Math.Pow(x, 4) - 8 * Math.Pow(x, 3) - 18 * Math.Pow(x, 2) + 2;
        }

        public double equation3(double x)
        {
            return Math.Pow(x, 2) - 4 + Math.Pow(0.5, x);
        }

        public double equation4(double x)
        {
            return Math.Pow(x - 2, 2) * Math.Log10(x + 11) - 1;
        }

        public double bisection(double a, double b, Func<double, double> equation)
        {
            if (equation(a) * equation(b) >= 0)
            {
                MessageBox.Show("wrong interval choose another a or b");

                return 0.0;
            }

            double c = a;

            while (b - a >= Epsilon)
            {
                c = (a + b) / 2;

                if (equation(c) == 0.0)
                    return c;

                else if (equation(c) * equation(a) < 0)
                    b = c;

                else
                    a = c;
            }

            if (equation(c - Epsilon) * equation(c + Epsilon) < 0)
                return c;
            else
                return 0.0;
        }
    }
}