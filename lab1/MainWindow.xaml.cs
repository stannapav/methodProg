using System.Text.RegularExpressions;
using System.Windows;

namespace lab1
{
    public partial class MainWindow : Window
    {
        BisectionCalc bisectionCalc = new BisectionCalc();
        bool[,] changed = { { false, false }, { false, false }, { false, false }, { false, false } };
        Regex numReg = new Regex(@"^[0-9]+$");

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private void firstBtn_Click(object sender, RoutedEventArgs e)
        {
            Result1.Content = bisectionCalc.bisection(Convert.ToDouble(a1.Text), Convert.ToDouble(b1.Text), bisectionCalc.equation1);
        }

        private void secondBtn_Click(object sender, RoutedEventArgs e)
        {
            Result2.Content = bisectionCalc.bisection(Convert.ToDouble(a2.Text), Convert.ToDouble(b2.Text), bisectionCalc.equation2);
        }

        private void thirdBtn_Click(object sender, RoutedEventArgs e)
        {
            Result3.Content = bisectionCalc.bisection(Convert.ToDouble(a3.Text), Convert.ToDouble(b3.Text), bisectionCalc.equation3);
        }

        private void forthBtn_Click(object sender, RoutedEventArgs e)
        {
            Results4.Content = bisectionCalc.bisection(Convert.ToDouble(a4.Text), Convert.ToDouble(b4.Text), bisectionCalc.equation4);
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

        private void a3_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            changed[2, 0] = (!string.IsNullOrEmpty(a3.Text) && numReg.IsMatch(a3.Text)) ? true : false;

            thirdBtn.IsEnabled = (changed[2, 0] && changed[2, 1]) ? true : false;
        }

        private void b3_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            changed[2, 1] = (!string.IsNullOrEmpty(b3.Text) && numReg.IsMatch(b3.Text)) ? true : false;

            thirdBtn.IsEnabled = (changed[2, 0] && changed[2, 1]) ? true : false;
        }

        private void a4_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            changed[3, 0] = (!string.IsNullOrEmpty(a4.Text) && numReg.IsMatch(a4.Text)) ? true : false;

            forthBtn.IsEnabled = (changed[3, 0] && changed[3, 1]) ? true : false;
        }

        private void b4_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            changed[3, 1] = (!string.IsNullOrEmpty(b4.Text) && numReg.IsMatch(b4.Text)) ? true : false;

            forthBtn.IsEnabled = (changed[3, 0] && changed[3, 1]) ? true : false;
        }
    }
}