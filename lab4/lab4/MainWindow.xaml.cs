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
        Dictionary<string, HashSet<string>> studentDisko = new Dictionary<string, HashSet<string>>();
        int kolOfStudent = 1;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tasksComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textTask = tasksComboBox.SelectedItem.ToString().Substring(38);
            answer.Content = "";
            answer.Visibility = Visibility.Visible;
            add.Visibility = Visibility.Collapsed;
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
                case "Lab 5: Задание 1":
                    answer.Content = "Полученный лист:\r\n\r\n";
                    task.Content = "Решить задачу, используя класс List\r\n" +
                        "Составить программу, которая переворачивает список L, т.е. изменяет\r\n" +
                        "ссылки в этом списке так, чтобы его элементы оказались\r\n" +
                        "расположенными в обратном порядке.";
                    ValueText("L =", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                case "Lab 5: Задание 2":
                    answer.Content = "Полученный лист:\r\n\r\n";
                    task.Content = "Решить задачу, используя класс LinkedList\r\n" +
                        "В списке L справа и слева от элемента E вставляет элемент F";
                    ValueText("L =", "E =", "F =", "");
                    VisibleValue(Visibility.Visible, Visibility.Visible, Visibility.Visible, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                case "Lab 5: Задание 3":
                    answer.Content = "All Disko: 1, 2, 3, 4, 5, 6\n";
                    task.Content = "Решить задачу, используя класс HashSet\r\n" +
                        "Есть перечень дискотек города. Студенты группы любят посещать\r\n" +
                        "дискотеки. Известно для каждого студента, в каких дискотеках он\r\n" +
                        "побывал. Определить:\r\n" +
                        "в какие дискотеки из перечня ходили все студенты группы;\r\n" +
                        "в какие дискотеки из перечня ходили некоторые студенты группы;\r\n" +
                        "в какие дискотеки из перечня не ходил ни один из студентов группы?";
                    ValueText("S =", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    value3.Height = 18;
                    add.Visibility = Visibility.Visible;
                    ChangedTask();
                    ForLab5Ex3();
                    break;
                case "Lab 5: Задание 4":
                    answer.Content = "";
                    task.Content = "Решить задачу, используя класс HashSet\r\n" +
                        "Дан текстовый файл. Обработать содержимое файла с использованием\r\nHashSet.\r\n" +
                        "Файл содержит текст на русском языке. Напечатать в алфавитном\r\nпорядке " +
                        "символы, которые встречаются хотя бы однажды в словах с\r\nчётными номерами " +
                        "(нумерацию вести с 1).";
                    ValueText("", "", "", "");
                    VisibleValue(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                case "Lab 5: Задание 5":
                    answer.Content = "";
                    task.Content = "Решить задачу, используя класс Dictionary (или класс SortedList)\r\n" +
                        "Решить текстовую задачу с использованием словаря (входные данные\r\nчитать из " +
                        "текстового файла)\r\n" +
                        "В некотором вузе абитуриенты проходили предварительное тестирование,\r\n" +
                        "по результатам которого они могут быть допущены к сдаче\r\n" +
                        "вступительных экзаменов в первом потоке. Тестирование проводится по\r\n" +
                        "трём предметам, по каждому предмету абитуриент может набрать от 0\r\n" +
                        "до 100 баллов. При этом к сдаче экзаменов в первом потоке\r\n" +
                        "допускаются абитуриенты, набравшие по результатам тестирования не\r\n" +
                        "менее 30 баллов по каждому из трёх предметов, причём сумма баллов\r\n" +
                        "должна быть не менее 140. На вход программы подаются сведения о\r\n" +
                        "результатах предварительного тестирования. Известно, что общее\r\n" +
                        "количество участников тестирования не превосходит 500.\r\n" +
                        "В первой строке вводится количество абитуриентов, принимавших\r\n" +
                        "участие в тестировании, N. Далее следуют N строк, имеющих\r\n" +
                        "следующий формат:\r\n" +
                        "<Фамилия> <Имя> <Баллы>\r\n" +
                        "Здесь <Фамилия> – строка, состоящая не более чем из 20 символов;\r\n" +
                        "<Имя> – строка, состоящая не более чем из 15 символов, <Баллы> –\r\n" +
                        "строка, содержащая три целых числа, разделенных пробелом – баллы,\r\n" +
                        "полученные на тестировании по каждому из трёх предметов. При этом\r\n" +
                        "<Фамилия> и <Имя>, <Имя> и <Баллы> разделены одним пробелом. Пример\r\n" +
                        "входной строки:\r\n" +
                        "Романов Вельямин 48 39 55\r\n" +
                        "Напишите программу, которая будет выводить на экран фамилии и имена\r\n" +
                        "абитуриентов, допущенных к сдаче экзаменов в первом потоке. При этом\r\n" +
                        "фамилии должны выводиться в алфавитном порядке.";
                    ValueText("", "", "", "");
                    VisibleValue(Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
                    value3.Height = 18;
                    ChangedTask();
                    break;
                case "Lab 5: Задание 6":
                    answer.Content = "";
                    task.Content = "XML – cериализация и коллекции\r\n" +
                        "Файл содержит сведения об игрушках: название игрушки, ее стоимость\r\n" +
                        "в рублях и возрастные границы (например, игрушка может\r\n" +
                        "предназначаться для детей от двух до пяти лет). Получить сведения о\r\n" +
                        "том, можно ли подобрать игрушку, любую, кроме мяча, подходящую\r\n" +
                        "ребенку трех лет";
                    ValueText("t =", "", "", "");
                    VisibleValue(Visibility.Visible, Visibility.Collapsed, Visibility.Collapsed, Visibility.Collapsed);
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
                case "Lab 5: Задание 1":
                    answer.Content += InputIsCorrect(
                        () => InputCheck.IsListNotNone(value1.Text.Split(' ')),
                        () => Tasks.ForEx1(value1.Text.Split(' ')));
                    break;
                case "Lab 5: Задание 2":
                    answer.Content = "Полученный лист:\r\n\r\n" + InputIsCorrect(
                        () => InputCheck.IsListNotNone(value1.Text.Split(' ')) && 
                        InputCheck.IsValueInList(value1.Text.Split(' '), value2.Text) &&
                        InputCheck.IsStrNotNone(value2.Text) &&
                        InputCheck.IsStrNotNone(value3.Text),
                        () => Tasks.ForEx2(value1.Text.Split(' '), value2.Text, value3.Text));
                    break;
                case "Lab 5: Задание 3":
                    answer.Content = "All Disko: 1, 2, 3, 4, 5, 6\n" + InputIsCorrect(
                        () => InputCheck.IsDictionaryNotNone(studentDisko),
                        () => Tasks.ForEx3(studentDisko));
                    ForLab5Ex3();
                    break;
                case "Lab 5: Задание 4":
                    answer.Content = Tasks.ForEx4("Lab5ex4.txt");
                    break;
                case "Lab 5: Задание 5":
                    answer.Content = Tasks.ForEx5("Lab5ex5.txt");
                    break;
                case "Lab 5: Задание 6":
                    answer.Content = Tasks.ForEx6(value1.Text.Split(' '));
                    break;
            }
        }

        
        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (InputCheck.IsValueInAllDisko(value1.Text.Split(' '), studentDisko))
            {
                studentDisko.Add("Student" + $"{kolOfStudent}" + ":",
                    new HashSet<string>(value1.Text.Split(' ')));
                answer.Content += "Student" + $"{kolOfStudent}" + ": " + string.Join(", ",
                    value1.Text.Split(' ')) + "\n";
                kolOfStudent++; 
            }
            else
            {
                answer.Content += "Не все названия дискотек соответствуют названиям из перечня\n";
            }
        }

        private void ForLab5Ex3()
        {
            studentDisko.Clear();
            kolOfStudent = 1;
            studentDisko.Add("All Disko:", new HashSet<string> {"1", "2", "3", "4", "5", "6"});
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
