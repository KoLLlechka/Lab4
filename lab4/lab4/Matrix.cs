using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace lab4
{
    internal class Matrix
    {
        private int[,] matrix;

        // Конструтор копирования
        public Matrix(Matrix M) 
        {
            matrix = M.matrix;
        }

        //конструктор по умолчанию
        public Matrix()
        {
            matrix = new int[0,0];
        }

        //конструктор, создающий матрицу, исходя из введенных значений
        public Matrix(string[] stringArr, int n, int m)
        {
            matrix = new int[n, m];
            for (int i = 0, k = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++, k++)
                {
                    matrix[i, j] = int.Parse(stringArr[k]);
                }
            }
        }

        //конструктор, создающий матрицу с рандомными значениями
        public Matrix(int n, int m)
        {
            matrix = new int[n, m];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = random.Next(-9, 20);
                }
            }
            Thread.Sleep(1);
        }

        //конструктор, создающий матрицу, располагая элементы так, 
        //что четные значения расположены на нечетных позициях матрицы,
        //а нечетные - на четных
        public Matrix(int n)
        {
            matrix = new int[n, n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    int num = random.Next(10, 100);
                    if ((i + j) % 2 == 0)
                    {
                        if (num % 2 == 0)
                            matrix[i, j] = num + 1;
                        else
                            matrix[i, j] = num;
                    }
                    else
                    {
                        if (num % 2 == 0)
                            matrix[i, j] = num;
                        else
                            matrix[i, j] = num + 1;
                    }
                }
            }
        }

        //конструктор, создающий матрицу, располая элементы по
        //диагонали, начиная с левого нижнего угла и заканчивая
        //на главной диагонали матрицы
        public Matrix(string[] stringArr, int n)
        {
            matrix = new int[n, n];
            for (int i = n - 1, k = 0, j2 = 0; i >= 0; i--, j2++)
            {
                for (int j = 0, i2 = i; j <= j2; k++, i2++, j++)
                {
                    matrix[i2,j] = int.Parse(stringArr[k]);
                }
            }
        }

        //перегрузка метода ToString() для вывода матрицы
        public override string ToString()
        {
            string s = "";
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                s += "|";
                for (int j = 0; j < m; j++)
                {
                    if (j == 0)
                        s += string.Format("{0,3:d}", matrix[i, j]);
                    else 
                        s += string.Format("{0,5:d}", matrix[i, j]);
                }
                s += "|\n";
            }
            return s;
        }

        //находит максимальную сумму из сумм элементов столбцов 
        //матрицы без учета элементов, номер которых соответствует
        //данному столбцу и тех, что ниже них
        public int Sum()
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);
            int maxSum = 0;
            for (int i = 0; i < n - 1; i++)
            {
                int sum = 0;
                for (int j = 0; j < m - i - 1; j++)
                {
                    sum += matrix[j, i];
                    if (sum > maxSum)
                        maxSum = sum;
                }
            }
            return maxSum;
        }

        //транспонирует матрицу
        public Matrix Transpose()
        {
            Matrix m = new Matrix(matrix.GetLength(1), matrix.GetLength(0));
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    m.matrix[i, j] = matrix[j, i];
                }
            }
            return m;
        }

        //перегрузки операторов
        //сложение матриц
        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            Matrix m3 = new Matrix(m1);
            for (int i = 0; i < m1.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < m1.matrix.GetLength(1); j++)
                {
                    m3.matrix[i, j] = m1.matrix[i, j] + m2.matrix[i, j];
                }
            }
            return m3;
        }
        //вычитание матриц
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            Matrix m3 = new Matrix(m1);
            for (int i = 0; i < m1.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < m1.matrix.GetLength(1); j++)
                {
                    m3.matrix[i, j] = m1.matrix[i, j] - m2.matrix[i, j];
                }
            }
            return m3;
        }
        //умножение матрицы на число
        public static Matrix operator *(int x, Matrix m1)
        {
            Matrix m3 = new Matrix(m1);
            for (int i = 0; i < m1.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < m1.matrix.GetLength(1); j++)
                {
                    m3.matrix[i, j] = m1.matrix[i, j] * x;
                }
            }
            return m3;
        }

        //геттер
        public int[,] GetMatrix
        {
            get { return matrix; }
        }
    }
}
