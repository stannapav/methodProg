using System.Windows;

namespace lab2
{
    internal class IterationMethods
    {
        static double Epsilon = 0.001;

        static bool ConditionOne(double[,] matrix)
        {
            double S = 0.0;

            foreach (var x in matrix)
                S += Math.Pow(x, 2);

            return S < 1;
        }

        static bool ConditionTwo(double[,] matrix)
        {
            double maxElement = 0.0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double S = 0.0;

                for (int j = 0; j < matrix.GetLength(1); j++)
                    S += Math.Abs(matrix[i, j]);

                maxElement = (S > maxElement) ? S : maxElement;
            }

            return maxElement < 1;
        }

        static bool ConditionThree(double[,] matrix)
        {
            double maxElement = 0.0;

            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                double S = 0.0;

                for (int i = 0; i < matrix.GetLength(0); i++)
                    S += Math.Abs(matrix[i, j]);

                maxElement = (S > maxElement) ? S : maxElement;
            }

            return maxElement < 1;
        }

        static bool CheckAnswer(double[,] matrix, double[] B, double[] newValues)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double S = B[i];

                for (int j = 0; j < matrix.GetLength(1); j++)
                    S += newValues[j] * matrix[i, j];

                if (Math.Round(S, 2) != Math.Round(newValues[i], 2))
                    return false;
            }

            return true;
        }

        static double CalcNewElement(double[] newValues, double[] oldValues)
        {
            double maxElement = 0.0;

            for (int i = 0; i < newValues.Length; i++)
                maxElement = (maxElement < Math.Abs(newValues[i] - oldValues[i])) ? Math.Abs(newValues[i] - oldValues[i]) : maxElement;

            return maxElement;
        }

        static public double[] SimpleIteration(double[,] matrix, double[] B)
        {
            if (!(ConditionOne(matrix) || ConditionTwo(matrix) || ConditionThree(matrix)))
            {
                MessageBox.Show("Ця матриця не збіжна тому обчислення не виконується","Задаче не виконується");

                return [0.0];
            }

            double[] oldValues = { 0, 0, 0, 0 };
            double[] newValues = { 0, 0, 0, 0 };
            double newCalcEl = 0.0;

            do
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    newValues[i] = B[i];

                    for (int j = 0; j < matrix.GetLength(1); j++)
                        newValues[i] += oldValues[j] * matrix[i, j];
                }

                newCalcEl = CalcNewElement(newValues, oldValues);

                for (int i = 0; i < newValues.Length; i++)
                    oldValues[i] = newValues[i];
            } while (newCalcEl > Epsilon);

            if (!CheckAnswer(matrix, B, newValues))
            {
                MessageBox.Show("Не правильне обчислення задачі", "Неправильна відповідь");

                return [0.0];
            }

            for (int i = 0; i < newValues.Length; i++)
                newValues[i] = Math.Round(newValues[i], 2);

            return newValues;
        }

        static public double[] ZeydelMethod(double[,] matrix, double[] B)
        {
            if (!(ConditionOne(matrix) || ConditionTwo(matrix) || ConditionThree(matrix)))
            {
                MessageBox.Show("Ця матриця не збіжна тому обчислення не виконується", "Задаче не виконується");

                return [0.0];
            }


            double[] oldValues = { 0, 0, 0, 0 };
            double[] newValues = { 0, 0, 0, 0 };
            double newCalcEl = 0.0;

            do
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    newValues[i] = B[i];

                    for (int j = 0; j < matrix.GetLength(1); j++)
                        newValues[i] += (i > j) ? newValues[j] * matrix[i, j] : oldValues[j] * matrix[i, j];
                }

                newCalcEl = CalcNewElement(newValues, oldValues);

                for (int i = 0; i < newValues.Length; i++)
                    oldValues[i] = newValues[i];
            } while (newCalcEl > Epsilon);

            if (!CheckAnswer(matrix, B, newValues))
            {
                MessageBox.Show("Не правильне обчислення задачі", "Неправильна відповідь");

                return [0.0];
            }

            for (int i = 0; i < newValues.Length; i++)
                newValues[i] = Math.Round(newValues[i], 2);

            return newValues;
        }
    }
}