# ООП. Лабораторная работа №4. Массивы и файлы. Вариант 9
## Постановка задач 1 - 3
Задание 1. 
Первый массив, размерностью n х m , заполняется данными, вводимыми с клавиатуры, так что
заполнение ведется по строкам от первых элементов строки к последним.
Второй массив, размерностью n х n, заполняется случайными числами так, что четные числа
заносятся в элементы массива, которые на шахматной доске были бы черными, а нечетные числа
заносятся в элементы, которые на шахматной доске были бы белыми.
Третий массив, размерностью n х n, заполняется для произвольного n так же, как для n=5:

<p align="center">
  <img src="https://github.com/user-attachments/assets/e1955ff8-5a2b-43d0-aa02-73d0a5db44e2" />
</p>

Задание 2. 
Задан двумерный массив. Найдите сумму элементов первого столбца без одного последнего
элемента, сумму элементов второго столбца без двух последних, сумму третьего столбца без трех
последних и т.д. Последний столбец не обрабатывается. Среди найденных сумм найдите
максимальную.

Задание 3. 
(А+4*В)-Ст

## Класс Matrix
## Поле
Класс содержит поле:
```c#
private int[,] matrix;
```

## Конструкторы
Конструктор **по умолчанию** инициализирует пустую матрицу:

```c#
public Matrix()
{
    matrix = new int[0,0];
}
```

Конструктор, создающий матрицу, исходя из введенных значений:

```c#
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
```

Конструктор, создающий матрицу с рандомными значениями, но введенной размерностью:

```c#
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
```

Конструктор, создающий матрицу, располагая элементы так, что четные значения расположены на нечетных позициях матрицы, а нечетные - на четных позициях:

```c#
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
```

Конструктор, создающий матрицу, располая элементы по диагонали, начиная с левого нижнего угла и заканчивая на главной диагонали матрицы:

```c#
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
```

**Конструктор копирования**:

```c#
public Matrix(Matrix M) 
{
    matrix = M.matrix;
}
```

## Методы

Ниже представлены реализованные **методы** класса **Matrix**:

Перегрузка метода ToString() для вывода матрицы:
```c#
//перегрузка метода ToString() для вывода матрицы
public override string ToString() {...}

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
```

Перегрузки операторов:

```c#
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
```

Геттер:

```c#
public int[,] GetMatrix
{
    get { return matrix; }
}
```

## Тесты

# Если пользователь корректно ввел размерность матрицы, ее элементы и подходящее количество элементов для 1 задания
*Вывод:*

![image](https://github.com/user-attachments/assets/531d8a0e-05c7-4b4c-91ba-dd0da487e66d)

# Если пользователь корректно ввел размерность матрицы для 2 задания
*Вывод:*

*Ожидаемый резыльтат: 193*

*Полученный резыльтат:*

![image](https://github.com/user-attachments/assets/706c6c95-d8d5-41ae-998f-03f89499d8dd)

# Если пользователь корректно ввел размерности для трех матриц для 3 задания
*Ожидаемый результат:*

![image](https://github.com/user-attachments/assets/e4032daf-48ff-449b-b8e6-2ad5d7106768)

*Подученный результат:*

![image](https://github.com/user-attachments/assets/0d2e4c3b-3348-4393-ba42-79b877e1222c)

## Постановка задачи 4

Бинарные файлы, содержат числовые данные, исходный файл необходимо заполнить случайными данными, заполнение организовать отдельным методом. 
Получить в другом файле последовательного доступа все компоненты исходного файла, кроме тех, которые кратны k.

Заполнение бинарного файла случайными данными:

```c#
public static void BinWriter1(string file)
{
    using (BinaryWriter bin = new BinaryWriter(File.Open(file, FileMode.Create)))
    {
        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            bin.Write(random.Next(-100, 101));
        }
    }
}
```

Заполнение бинарного файла значениями из исходного не кратных k:

```c#
public static string WithoutMultiplesK(string sour, string final, int k) {...}
```
## Тесты
*Вывод:*

![image](https://github.com/user-attachments/assets/a0f1e655-dcce-4578-b7c4-396a5b46dc51)

## Постановка задачи 5

Бинарные файлы содержат величины типа struct, заполнение исходного файла необходимо организовать отдельным методом. 
Файл содержит сведения об игрушках: название игрушки, ее стоимость в рублях и возрастные
границы (например, игрушка может предназначаться для детей от двух до пяти лет). Получить
сведения о том, можно ли подобрать игрушку, любую, кроме мяча, подходящую ребенку трех лет.

Структура игрушки:

```c#
struct Toy
{
    public string Name;
    public double Cost;
    public int MinAge;
    public int MaxAge;
}
```

Заполнение бинарного файла структурами:

```c#
public static string FillBinFile(string sour, string[] sarr){...}
```

Вывод данных бинарного файла:

```c#
public static string ReadBinFile(string sour){...}
```

Подходит ли игрушка:

```c#
public static string SuitableToys(string sour)
{
    if (!File.Exists(sour)) throw new Exception($"Файла с именем {sour} не существует");
    using (BinaryReader reader = new BinaryReader(File.Open(sour, FileMode.Open)))
    {
        while (reader.BaseStream.Position != reader.BaseStream.Length)
        {
            string name = reader.ReadString();
            float cost = (float)reader.ReadDouble();
            int minAge = reader.ReadInt32();
            int maxAge = reader.ReadInt32();
            if (name != "Мяч" && minAge <=3 && name != "мяч" && name != "МЯЧ")
            {
                return "Ура, мы можем подобрать игрушку :3";
            }
        }
        return "О, нет, мы не можем подобрать игрушку";
    }
}
```

## Тесты
*Вывод:*

![image](https://github.com/user-attachments/assets/2c57835d-a1ca-4978-9af3-9d78a405e3d2)

## Постановка задачи 6

В текстовом файле хранятся целые числа по одному в строке, исходный файл
необходимо заполнить случайными данными, заполнение организовать отдельным методом. 
В файле найти сумму максимального и минимального элементов.

Заполнение файла случайными значениями по одному элементу в строке:

```c#
public static string FillFileN(string sour, int x) {...}
```

Сумма минимального и максимального элементов файла:

```c#
public static string MinPlusMax(string sour)
{
    if (!File.Exists(sour)) throw new Exception($"Файла с именем {sour} не существует");
    using (StreamReader reader = new StreamReader(sour))
    {
        int min = 9999;
        int max = -9999;
        while (!reader.EndOfStream)
        {
            int x = int.Parse(reader.ReadLine());
            if (x < min)
                min = x;
            if (x > max)
                max = x;
        }
        return "\n\n" + "Сумма максимального и минимального элементов: " + (min + max).ToString();
    }
}
```

## Тесты
*Вывод:*

![image](https://github.com/user-attachments/assets/1443a658-0435-4301-9082-6cbeab46e9f8)

## Постановка задачи 7

В текстовом файле хранятся целые числа по несколько в строке, исходный файл
необходимо заполнить случайными данными, заполнение организовать отдельным методом. 
Вычислить сумму чётных элементов.

Заполнение файла случайными значениями через пробел:

```c#
public static string FillFile(string sour, int x) {...}
```

Сумма четных элементов файла:

```c#
public static string EvenEl(string sour)
{
    if (!File.Exists(sour)) throw new Exception($"Файла с именем {sour} не существует");
    using (StreamReader reader = new StreamReader(sour))
    {
        int sum = 0;
        string[] sarr = reader.ReadToEnd().Split(' ');
        for (int i = 1; i < sarr.Length - 1; i+=2)
        {
            sum += int.Parse(sarr[i]);
        }
        return "\n\n" + "Сумма элементов: " + sum;
    }
}
```

## Тесты
*Вывод:*

![image](https://github.com/user-attachments/assets/d8bbb3e1-99f6-4450-8083-728dae731d67)

## Постановка задачи 8

В текстовом файле хранится текст. 
Создать новый текстовый файл, каждая строка которого содержит первый символ
соответствующей строки исходного файла.

Вывод данных файла:
```c#
public static string ReadFile(string sour) {...}
```

Создание нового файла, где каждая строка содержит первый символ соответствующей строки:

```c#
public static string WriterFile(string sour, string final)
{
    if (!File.Exists(sour)) throw new Exception($"Файла с именем {sour} не существует");
    using (StreamReader reader = new StreamReader(sour))
    {
        using (StreamWriter writer = new StreamWriter(File.Open(final, FileMode.Create)))
        {
            string s = "\nСодержание итогового файла:\n\n";
            while (!reader.EndOfStream)
            {
                string s1 = reader.ReadLine();
                writer.WriteLine(s1[0]);
                s += s1[0] + "\n";
            }
            return s.Substring(0, s.Length - 1);
        }
    }
}
```

## Тесты
*Вывод:*

![image](https://github.com/user-attachments/assets/799de0d2-d7ac-42c5-b012-8894021c45e8)



