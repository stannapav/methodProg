using System.Windows;

namespace lab1_2
{
    internal class IterationMethod
    {
        static double Epsilon = Math.Pow(10, -3);

        public double equation1(double x)
        {
            return Math.Tan(0.44 * x + 0.3) - Math.Pow(x, 2);
        }

        public double equation2(double x)
        {
            return Math.Pow(x, 3) - 0.1 * Math.Pow(x, 2) + 0.4 * x + 1.2;
        }

        public double phi1(double x)
        {
            return Math.Sqrt(Math.Tan(0.44 * x + 0.3));
        }

        public double phi2(double x)
        {
            return Math.Cbrt(0.1 * Math.Pow(x, 2) - 0.4 * x - 1.2);
        }

        public double Iteration(double a, double b, Func<double, double> equation, Func<double, double> phi)
        {
            if (equation(a) * equation(b) >= 0)
            {
                MessageBox.Show("wrong interval");
                return 0.0;
            }

            double prevX = a;
            double x = (a + b) / 2;

            if (Math.Abs(phi(x)) >= 1)
            {
                MessageBox.Show("this phi will not find root look for another phi");
                return 0.0;
            }

            while (Math.Abs(prevX - x) >= Epsilon)
            {
                prevX = x;
                x = phi(x);
            }

            if (equation(x - Epsilon) * equation(x + Epsilon) < 0)
                return x;
            else
                return 0.0;
        }
    }
}