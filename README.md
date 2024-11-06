# ООП. Лабораторная работа №4. Массивы и файлы. Вариант 9
## Постановка задачи 1
Решить задачу, используя класс List 
Составить программу, которая переворачивает список L, т.е. изменяет ссылки в этом списке так,
чтобы его элементы оказались расположенными в обратном порядке.

```c#
public static List<T> RevList<T>(List<T> list) {...}
```
## Тесты

![image](https://github.com/user-attachments/assets/e6d9222a-fa9b-4d86-93a4-8c9b5cff20eb)

## Постановка задачи 2
Решить задачу, используя класс LinkedList
D списке L справа и слева от элемента E вставляет элемент F.

```c#
public static LinkedList<T> FToLinkedList<T>(LinkedList<T> list, T E, T F) {...}
```

## Тесты

![image](https://github.com/user-attachments/assets/a9334302-c6d9-473d-a911-6b7ca6eda6a8)

## Постановка задачи 3
Решить задачу, используя класс HashSet
Есть перечень дискотек города. Студенты группы любят посещать дискотеки. Известно для
каждого студента, в каких дискотеках он побывал. Определить:
в какие дискотеки из перечня ходили все студенты группы;
в какие дискотеки из перечня ходили некоторые студенты группы;
в какие дискотеки из перечня не ходил ни один из студентов группы?

Определяет дискотеки, в которые ходили все студенты группы:

```c#
public static HashSet<string> AllStudents(Dictionary<string, HashSet<string>> students)
{
    HashSet<string> result = new HashSet<string>();
    foreach (var dis in students["Student1:"])
    {
        result.Add(dis);
    }
    for (int i = 2; i + 1 <= students.Count; i++)
    {
        result.IntersectWith(students["Student" + i + ":"]);
    }
    return result;
}
```

Определяет дискотеки, в которые ходили некоторые студенты группы:

```c#
public static HashSet<string> SomeStudents(Dictionary<string, HashSet<string>> students)
{
    HashSet<string> result = new HashSet<string>();
    foreach (var dis in students["Student1:"])
    {
        result.Add(dis);
    }
    for (int i = 2; i + 1 <= students.Count; i++)
    {
        result.UnionWith(students["Student" + i + ":"]);
    }
    return result;
}
```

Определяет дискотеки, в которые не ходил ни один из студентов группы:

```c#
public static HashSet<string> NobodyStudents(Dictionary<string, HashSet<string>> students)
{
    HashSet<string> result = new HashSet<string>();
    foreach (var dis in students["All Disko:"])
    {
        result.Add(dis);
    }
    for (int i = 1; i + 1 <= students.Count; i++)
    {
        result.ExceptWith(students["Student" + i + ":"]);
    }
    return result;
}
```

## Тесты

![image](https://github.com/user-attachments/assets/02df3669-f16d-4c6f-8937-ab6eaee15316)

## Постановка задачи 4
Решить задачу, используя класс HashSet
Дан текстовый файл. Обработать содержимое файла с использованием HashSet
Файл содержит текст на русском языке. Напечатать в алфавитном порядке символы, которые
встречаются хотя бы однажды в словах с чётными номерами (нумерацию вести с 1).

Символы, встречающиеся хотя бы однажды в словах с чётными номерами:

```c#
public static char[] Symbols(string f)
{
    using (StreamReader reader = new StreamReader(f))
    {
        string s = string.Empty;
        while (!reader.EndOfStream)
        {
            s += reader.ReadLine();
        }
        string s1 = string.Empty;
        foreach (var c in s)
        {
            if (!char.IsPunctuation(c))
                s1 += c;
        }
        HashSet<string> result = new HashSet<string>(s1.Split(' '));
        HashSet<char> result2 = new HashSet<char>();
        int i = 1;
        foreach (var str in result)
        {
            if (i%2 == 0)
                foreach (var c in str)
                {
                    result2.Add(c);
                }
            i++;  
        }
        char[] result3 = result2.ToArray();
        Array.Sort(result3);
        return result3;
    }
}
```

## Тесты

*Содержание файла:*

![image](https://github.com/user-attachments/assets/a161c34a-af5a-4781-90e3-78c71919029a)

*Вывод:*

![image](https://github.com/user-attachments/assets/6afdfd70-90e4-4116-8449-22bde566a88d)

## Постановка задачи 5
Решить задачу, используя класс Dictionary (или класс SortedList)
Решить текстовую задачу с использованием словаря (входные данные читать из текстового файла)
В некотором вузе абитуриенты проходили предварительное тестирование, по результатам
которого они могут быть допущены к сдаче вступительных экзаменов в первом потоке.
Тестирование проводится по трём предметам, по каждому предмету абитуриент может набрать
от 0 100 баллов. При этом к сдаче экзаменов в первом потоке допускаются абитуриенты,
набравшие по результатам тестирования не менее 30 баллов по каждому из трёх предметов,
причём сумма баллов должна быть не менее 140. На вход программы подаются сведения о
результатах предварительного тестирования. Известно, что общее количество участников
тестирования не превосходит 500.
В первой строке вводится количество абитуриентов, принимавших участие в тестировании, N.
Далее следуют N строк, имеющих следующий формат:
<Фамилия> <Имя> <Баллы>
Здесь <Фамилия> – строка, состоящая не более чем из 20 символов; <Имя> – строка, состоящая не
более чем из 15 символов, <Баллы> – строка, содержащая два целых числа, разделенных
пробелом – баллы, полученные на тестировании по каждому из трёх предметов. При этом
<Фамилия> и <Имя>, <Имя> и <Баллы> разделены одним пробелом. Пример входной строки:
Романов Вельямин 48 39 55
Напишите программу, которая будет выводить на экран фамилии и имена абитуриентов,
допущенных к сдаче экзаменов в первом потоке. При этом фамилии должны выводиться в
алфавитном порядке.

Заполняет словарь, сортирует, создавая новый и определяет, кто из абитуриентов
допущен к сдаче экзаменов в первом потоке:

```c#
public static string AdmittedExam(string f)
{
    using (StreamReader reader = new StreamReader(f))
    {
        Dictionary<string, int[]> applicants = new Dictionary<string, int[]>();
        while (!reader.EndOfStream)
        {
            string[] line = reader.ReadLine().Split(' ');
            string name = line[0] + " " + line[1];
            int[] points = { int.Parse(line[2]), int.Parse(line[3]), int.Parse(line[4]) };
            applicants.Add(name, points);
        }

        SortedDictionary<string, int[]> sorted = new SortedDictionary<string, int[]>(applicants);
        string result = string.Empty;
        foreach (var p in sorted)
        {
            if (p.Value[0] >= 30 && p.Value[1] >= 30 && p.Value[2] >= 30 &&
                (p.Value[0] + p.Value[1] + p.Value[2]) >= 140)
            {
                result += p.Key;
            }
        }
        return result.Trim('\n');
    }
}
```

## Тесты

*Содержание файла:*

![image](https://github.com/user-attachments/assets/2fdaa72c-8d18-4d0b-ba0e-92824476c934)

*Вывод:*

![image](https://github.com/user-attachments/assets/b41ca823-3a98-4d09-b254-4772b0280435)

## Постановка задачи 6
XML – cериализация и коллекции
Файл содержит сведения об игрушках: название игрушки, ее стоимость в рублях и возрастные
границы (например, игрушка может предназначаться для детей от двух до пяти лет).
Определить стоимость самого дорогого конструктора.

Структура игрушки:

```c#
public struct Toy
{
    public string Name;
    public double Cost;
    public int MinAge;
    public int MaxAge;
}
```

Заполнение xml файла структурами:

```c#
public static string FillXmlFile(string[] sarr){...}
```

Вывод данных файла:

```c#
public static string ReadFile(FileStream f, XmlSerializer xml){...}
```

Подходит ли игрушка:

```c#
public static string SuitableToys(FileStream f, XmlSerializer xml)
{
    f.Position = 0;
    f.Seek(0, SeekOrigin.Begin);
    Toy[] t = (Toy[])xml.Deserialize(f);
    foreach (Toy toy in t)
    {
        if (toy.Name != "Мяч" && toy.MinAge <= 3 && toy.Name != "мяч" && toy.Name != "МЯЧ")
        {
            return "Ура, мы можем подобрать игрушку :3";
        }
    }
    return "О, нет, мы не можем подобрать игрушку";
}
```

## Тесты

*Содержание файла:*

![image](https://github.com/user-attachments/assets/9b470eef-7a0e-41eb-848d-ec5f262e1338)

*Вывод:*

![image](https://github.com/user-attachments/assets/477de43e-a8a8-49f7-b58f-a944c4ab7d8c)
