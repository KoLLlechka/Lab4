using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string textTask;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void tasksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textTask = tasksComboBox.SelectedItem.ToString().Substring(38);
            answer.Content = "";
            answer.Visibility = Visibility.Visible;
            switch (textTask)
            {           
                case "Lab 4: Задание 1":
                    answer.Content = "Наши матрицы:";
                    task.Content = "Первый массив, размерностью n х m , заполняется данными, вводимыми\r\n" +
                        "с клавиатуры, так что заполнение ведется по строкам от первых\r\n" +
                        "элементов строки к последним.\r\nВторой массив, размерностью n х n, заполняется " +
                        "случайными числами\r\nтак, что четные числа заносятся в элементы массива, которые " +
                        "на\r\nшахматной доске были бы черными, а нечетные числа заносятся в\r\nэлементы, " +
                        "которые на шахматной доске были бы белыми.\r\nТретий массив, размерностью n х n, " +
                        "заполняется для произвольного n\r\nтак же, как для n=5:\r\n\r\n" +
                        "|11  0   0   0    0|\n" +
                        "|7   12  0   0    0|\n" +
                        "|4   8   13  0    0|\n" +
                        "|2   5   9   14   0|\n" +
                        "|1   3   6   10  15|";
                    ValueText("n =", "m =", "arr1 =", "arr3 =");
                    VisibleValue(Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Visible);
                    ChangedTask();
                    value3.Height = 100;
                    value4.Height = 100;
                    break;
                case "Lab 4: Задание 2":
                    answer.Content = "Наша матрица:";
                    task.Content = "Задан двумерный массив n х n. Найдите сумму элементов первого\r\nстолбца " +
                        "без одного последнего элемента, сумму элементов второго\r\nстолбца без двух " +
                        "последних, сумму третьего столбца без трех\r\nпоследних и т.д. Последний столбец " +
                        "не обрабатывается. Среди\r\nнайденных сумм найдите максимальную.";
                    ValueText("n =", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    ChangedTask();
                    break;
                case "Lab 4: Задание 3":
                    answer.Content = "Наши матрицы:";
                    task.Content = "Работа с двумерными массивами как с матрицами\n\n(А+4*В)-Ст";
                    ValueText("n1,m1=", "n2,m2=", "n3,m3=", "");
                    VisibleValue(Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                case "Lab 4: Задание 4":
                    answer.Content = "";                  
                    task.Content = "Получить в другом файле последовательного доступа все компоненты\r\nисходного " +
                        "файла, кроме тех, которые кратны k.";
                    ValueText("k =", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                case "Lab 4: Задание 5":
                    answer.Content = "";
                    task.Content = "Файл содержит сведения об игрушках: название игрушки, ее стоимость\r\n" +
                        "в рублях и возрастные границы (например, игрушка может\r\nпредназначаться для детей " +
                        "от двух до пяти лет). Получить сведения о\r\nтом, можно ли подобрать игрушку, любую, " +
                        "кроме мяча, подходящую\r\nребенку трех лет.\r\n\r\nВведите названия игрушек через пробел";
                    ValueText("n =", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                case "Lab 4: Задание 6":
                    answer.Content = "";
                    task.Content = "В файле найти сумму максимального и минимального элементов.\n\n" +
                        "Введите количсетво элементов в файле";
                    ValueText("n =", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                case "Lab 4: Задание 7":
                    answer.Content = "";
                    task.Content = "Вычислить сумму чётных элементов.\n\n" +
                        "Введите количсетво элементов в файле";
                    ValueText("n =", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                case "Lab 4: Задание 8":
                    answer.Content = "";
                    task.Content = "Создать новый текстовый файл, каждая строка которого содержит\r\n" +
                        "первый символ соответствующей строки исходного файла.";
                    ValueText("", "", "", "");
                    VisibleValue(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                default:
                    break;
            }
        }

        private void ValueText(string v1, string v2, string v3, string v4)
        {
            value1.Text = "";
            value2.Text = "";
            value3.Text = "";
            value4.Text = "";
            valueText1.Content = v1;
            valueText2.Content = v2;
            valueText3.Content = v3;
            valueText4.Content = v4;
        }

        private void VisibleValue(Visibility v1, Visibility v2, Visibility v3, Visibility v4)
        {
            value1.Visibility = v1;
            value2.Visibility = v2;
            value3.Visibility = v3;
            value4.Visibility = v4;
            valueText1.Visibility = v1;
            valueText2.Visibility = v2;
            valueText3.Visibility = v3;
            valueText4.Visibility = v4;
        }

        private void ChangedTask()
        {
            input.Visibility = Visibility.Visible;
            outputButton.Visibility = Visibility.Visible;
        }

        public string InputIsCorrect(Func<bool> isCorrect, Func<string> resultFunc)
        {
            if (isCorrect())
            {
                return resultFunc();
            }
            else
            {
                return "Ввод не корректен";
            }
        }

        private void outputButton_Click(object sender, RoutedEventArgs e)
        {
            switch (textTask)
            {           
                case "Lab 4: Задание 1":
                    answer.Content = "Наши матрицы:\n\n" + InputIsCorrect(
                        () => InputCheck.IsStringToInt(value1.Text) && InputCheck.IsStringToInt(value2.Text) &&
                        InputCheck.IsValueMoreZero(value1.Text) && InputCheck.IsValueMoreZero(value2.Text) &&
                        InputCheck.IsStringToIntArray(value3.Text.Split(' '), int.Parse(value1.Text) * 
                        int.Parse(value2.Text)) &&
                        InputCheck.IsStringToIntArray(value4.Text.Split(' '), N(int.Parse(value1.Text), 1, 2)),
                        () => ForMatrix1() + "\n\n" + ForMatrix2() + "\n\n" + ForMatrix3());
                    break;
                case "Lab 4: Задание 2":
                    answer.Content = "Наша матрица:\n\n" + InputIsCorrect(
                        () => InputCheck.IsStringToInt(value1.Text) && InputCheck.IsValueMoreZero(value1.Text),
                        () => MaxSum());
                    break;
                case "Lab 4: Задание 3":
                    answer.Content = "Наши матрицы:\n\n" + InputIsCorrect(
                        () => InputCheck.IsStringToIntArray(value1.Text.Split(' '), 2) &&
                        InputCheck.IsStringToIntArray(value2.Text.Split(' '), 2) &&
                        InputCheck.IsStringToIntArray(value3.Text.Split(' '), 2) &&
                        InputCheck.ValuesMoreZero(value1.Text.Split(' ')) &&
                        InputCheck.ValuesMoreZero(value2.Text.Split(' ')) &&
                        InputCheck.ValuesMoreZero(value3.Text.Split(' ')),
                        () => ExprValue());
                    break;
                case "Lab 4: Задание 4":
                    answer.Content = InputIsCorrect(
                        () => InputCheck.IsStringToInt(value1.Text) && InputCheck.IsValueNotZero(value1.Text),
                        () => ForBinary1());
                    break;
                case "Lab 4: Задание 5":
                    answer.Content = ForBinary2();
                    break;
                case "Lab 4: Задание 6":
                    answer.Content = InputIsCorrect(
                        () => InputCheck.IsStringToInt(value1.Text) && InputCheck.IsValueMoreZero(value1.Text),
                        () => ForBinary3());
                    break;
                case "Lab 4: Задание 7":
                    answer.Content = InputIsCorrect(
                        () => InputCheck.IsStringToInt(value1.Text) && InputCheck.IsValueMoreZero(value1.Text),
                        () => ForBinary4());
                    break;
                case "Lab 4: Задание 8":
                    answer.Content = ForBinary5();
                    break;
            }
        }

        private string ForBinary5()
        {
            string nameSourceFile = "f.txt";
            string nameFinalFile = "f1.txt";
            return BinFiles.ReadFile(nameSourceFile) + BinFiles.WriterFile(nameSourceFile, nameFinalFile);
        }

        private string ForBinary4()
        {
            string nameSourceFile = "b2.txt";
            return BinFiles.FillFile(nameSourceFile, int.Parse(value1.Text)) + 
                BinFiles.EvenEl(nameSourceFile);
        }

        private string ForBinary3()
        {
            string nameSourceFile = "b.bin";
            return BinFiles.FillFileN(nameSourceFile, int.Parse(value1.Text)) + BinFiles.MinPlusMax(nameSourceFile);
        }

        private string ForBinary2()
        {
            string nameSourceFile = "b.bin";
            return BinFiles.FillBinFile(nameSourceFile, value1.Text.Split(' '));
        }

        private string ForBinary1()
        {
            string nameSourceFile = "b.bin";
            string nameFinalFile = "b1.bin";
            return BinFiles.WithoutMultiplesK(nameSourceFile, nameFinalFile, int.Parse(value1.Text));
        }

        private string ExprValue()
        {
            if (InputCheck.IsDimensionsCorrect(value1.Text.Split(' '), value2.Text.Split(' '), value3.Text.Split(' ')))
            {
                Matrix A = new Matrix(int.Parse(value1.Text.Split(' ')[0]), int.Parse(value1.Text.Split(' ')[1]));
                Matrix B = new Matrix(int.Parse(value2.Text.Split(' ')[0]), int.Parse(value2.Text.Split(' ')[1]));
                Matrix C = new Matrix(int.Parse(value3.Text.Split(' ')[0]), int.Parse(value3.Text.Split(' ')[1]));
                return A.ToString() + "\n" + B.ToString() + "\n" + C.ToString() + "\n" + "(А+4*В)-Ст =\n\n" +
                    ((A + 4 * B) - C.Transpose()).ToString();
            }
            return "Не получится сложить или вычесть матрицы из-за\nразной размерности";
        }

        private int N(int n, int i, int j)
        {
            return (n > 1) ? N(n - 1, i + j, j + 1) : i;
        }

        private string MaxSum()
        {
            Matrix mat = new Matrix(int.Parse(value1.Text));
            return mat.ToString() + "\n" + "Максимальная сумма: " + mat.Sum().ToString();
        }
        
        private string ForMatrix1()
        {
            Matrix mat = new Matrix(value3.Text.Split(' '), int.Parse(value1.Text), int.Parse(value2.Text));
            return mat.ToString();
        }

        private string ForMatrix2()
        {
            Matrix mat = new Matrix(int.Parse(value1.Text));
            return mat.ToString();
        }

        private string ForMatrix3()
        {
            Matrix mat = new Matrix(value4.Text.Split(' '), int.Parse(value1.Text));
            return mat.ToString();
        }
    }
}
