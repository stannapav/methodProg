using System.Text.RegularExpressions;
using System.Windows;

namespace lab1
{
    public partial class MainWindow : Window
    {
        Regex ageReg = new Regex(@"^[0-9]+$");
        static double Epsilon = Math.Pow(10, -3);

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void firstBtn_Click(object sender, RoutedEventArgs e)
        {
            Result1.Content = bisection(Convert.ToDouble(a1.Text), Convert.ToDouble(b1.Text), equation1);
        }

        private void secondBtn_Click(object sender, RoutedEventArgs e)
        {
            Result2.Content = bisection(Convert.ToDouble(a2.Text), Convert.ToDouble(b2.Text), equation2);
        }

        private void thirdBtn_Click(object sender, RoutedEventArgs e)
        {
            Result3.Content = bisection(Convert.ToDouble(a3.Text), Convert.ToDouble(b3.Text), equation3);
        }

        private void forthBtn_Click(object sender, RoutedEventArgs e)
        {
            Results4.Content = bisection(Convert.ToDouble(a4.Text), Convert.ToDouble(b4.Text), equation4);
        }

        static double equation1(double x)
        {
            return Math.Pow(3, x) + 2 * x - 3;
        }

        static double equation2(double x)
        {
            return 3 * Math.Pow(x, 4) - 8 * Math.Pow(x, 3) - 18 * Math.Pow(x, 2) + 2;
        }

        static double equation3(double x)
        {
            return Math.Pow(x, 2) - 4 + Math.Pow(0.5, x);
        }

        static double equation4(double x)
        {
            return Math.Pow(x - 2, 2) * Math.Log10(x + 11) - 1;
        }

        static double bisection(double a, double b, Func<double, double> equation)
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

            return c;
        }
    }
}