using System.Text.RegularExpressions;
using System.Windows;

namespace lab1_2
{
    public partial class MainWindow : Window
    {
        IterationMethod iterationMethod = new IterationMethod();
        bool[,] changed = { { false, false }, { false, false } };
        Regex numReg = new Regex(@"^[0-9]+$");

        public MainWindow()
        {
            InitializeComponent();
        }

        private void firstBtn_Click(object sender, RoutedEventArgs e)
        {
            double result = iterationMethod.Iteration(Convert.ToDouble(a1.Text), Convert.ToDouble(b1.Text), iterationMethod.equation1, iterationMethod.phi1);

            Result1.Content = Convert.ToString(result);
        }

        private void secondBtn_Click(object sender, RoutedEventArgs e)
        {
            double result = iterationMethod.Iteration(Convert.ToDouble(a2.Text), Convert.ToDouble(b2.Text), iterationMethod.equation2, iterationMethod.phi2);

            Result2.Content = Convert.ToString(result);
        }

        private void a1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            changed[0, 0] = (!string.IsNullOrEmpty(a1.Text) && numReg.IsMatch(a1.Text)) ? true : false;

            firstBtn.IsEnabled = (changed[0, 0] && changed[0, 1]) ? true : false;
        }

        private void b1_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            changed[0, 1] = (!string.IsNullOrEmpty(b1.Text) && numReg.IsMatch(b1.Text)) ? true : false;

            firstBtn.IsEnabled = (changed[0, 0] && changed[0, 1]) ? true : false;
        }

        private void a2_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            changed[1, 0] = (!string.IsNullOrEmpty(a2.Text) && numReg.IsMatch(a2.Text)) ? true : false;

            secondBtn.IsEnabled = (changed[1, 0] && changed[1, 1]) ? true : false;
        }

        private void b2_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            changed[1, 1] = (!string.IsNullOrEmpty(b2.Text) && numReg.IsMatch(b2.Text)) ? true : false;

            secondBtn.IsEnabled = (changed[1, 0] && changed[1, 1]) ? true : false;
        }
    }
}