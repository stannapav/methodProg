using System.Windows;

namespace lab2
{
    public partial class MainWindow : Window
    {
        double[,] matrix =
            {
                { 0.0, 0.17, -0.33, 0.18 },
                { 0.0, 0.18, 0.43, -0.08 },
                { 0.22, 0.18, 0.21, 0.07 },
                { 0.08, 0.07, 0.21, 0.04 }
            };

        double[] B = { -1.2, 0.33, 0.48, -1.2 };

        public MainWindow()
        {
            InitializeComponent();
        }

        private void simpleIterationBtn_Click(object sender, RoutedEventArgs e)
        {
            double[] result = IterationMethods.SimpleIteration(matrix, B);

            resultLbl.Content = "Простої ітерації [" + string.Join(", ", result) + "]" ;
        }

        private void zeydelMethodBtn_Click(object sender, RoutedEventArgs e)
        {
            double[] result = IterationMethods.ZeydelMethod(matrix, B);

            resultLbl.Content = "Методом Зейделя [" + string.Join(", ", result) + "]";
        }
    }
}