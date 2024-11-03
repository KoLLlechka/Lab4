using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab4
{
    //структура игрушки
    struct Toy
    {
        public string Name;
        public double Cost;
        public int MinAge;
        public int MaxAge;
    }

    internal class BinFiles
    {
        //заполнение бинарного файла рандомными значениями
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

        //заполнение бинарного файла значениями из исходного не кратных k
        public static string WithoutMultiplesK(string sour, string final, int k)
        {
            string sourceFile = string.Empty;
            string finalFile = string.Empty;
            BinWriter1(sour);
            if (File.Exists(sour))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(sour, FileMode.Open)))
                {
                    using (BinaryWriter writer = new BinaryWriter(File.Open(final, FileMode.Create)))
                    {
                        while (reader.BaseStream.Position != reader.BaseStream.Length)
                        {
                            int val = reader.ReadInt32();
                            sourceFile += val + " ";
                            if (val % k != 0)
                            {
                                writer.Write(val);
                                finalFile += val + " ";
                            }
                        }
                        sourceFile = sourceFile.Substring(0, sourceFile.Length - 1);
                        if (finalFile.Length != 0)
                            finalFile = finalFile.Substring(0, finalFile.Length - 1);
                    }
                    return $"Содержание исходного файла:\n{sourceFile}\n\nСодержание итогового файла:\n{finalFile}";
                }
            }
            else
                return "Файл не найден";
        }

        //заполнение бинарного файла структурами
        public static string FillBinFile(string sour, string[] sarr)
        {
            Toy[] toys = new Toy[sarr.Length];
            Random random = new Random();
            for (int i = 0; i < sarr.Length; i++)
            {
                double randomDouble = random.NextDouble() * (1000 - 10) + 10;
                randomDouble = Math.Round(randomDouble, 2);
                Toy t = new Toy();
                t.Name = sarr[i];
                t.Cost = randomDouble;
                t.MinAge = random.Next(0, 6);
                t.MaxAge = random.Next(t.MinAge, 15);
                toys[i] = t;
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(sour, FileMode.Create)))
            {
                foreach (var t in toys)
                {
                    writer.Write(t.Name);
                    writer.Write(t.Cost);
                    writer.Write(t.MinAge);
                    writer.Write(t.MaxAge);
                }
            }
            return ReadBinFile(sour);
        }

        //вывод данных бинарного файла
        public static string ReadBinFile(string sour)
        {
            string s = "Данные исходного файла:\n\n";
            if (!File.Exists(sour)) throw new Exception($"Файла с именем {sour} не существует");
            using (BinaryReader reader = new BinaryReader(File.Open(sour, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    s += reader.ReadString() + " " + reader.ReadDouble() + " " +
                    reader.ReadInt32() + " " + reader.ReadInt32() + "\n\n";
                }
            }
            return s + SuitableToys(sour);
        }

        //вывод подходит ли игрушка
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

        //заполнение файла случайными значениями по одному элементу в строке
        public static string FillFileN(string sour, int x)
        {
            using (StreamWriter writer = new StreamWriter(File.Open(sour, FileMode.Create)))
            {
                string s = "Файл содержит числа:\n";
                Random random = new Random();
                for (int i = 0; i < x; i++)
                {
                    int val = random.Next(-1000, 1000);
                    writer.WriteLine(val);
                    s += val + ", ";
                    if (i % 10 == 0 && i != 0)
                        s += "\n";
                }
                return s.Substring(0, s.Length - 2);
            }
        }

        //сумма минимаьного и максимального элементов
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

        //заполнение файла случайными значениями через пробел
        public static string FillFile(string sour, int x)
        {
            using (StreamWriter writer = new StreamWriter(File.Open(sour, FileMode.Create)))
            {
                string s = "Файл содержит числа:\n";
                Random random = new Random();
                for (int i = 0; i < x; i++)
                {
                    int val = random.Next(-1000, 1000);
                    writer.Write(val + " ");
                    s += val + ", ";
                    if (i % 10 == 0 && i != 0)
                        s += "\n";
                }
                return s.Substring(0, s.Length - 2);
            }
        }

        //сумма четных элементов
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

        //вывод данных файла
        public static string ReadFile(string sour)
        {
            if (!File.Exists(sour)) throw new Exception($"Файла с именем {sour} не существует");
            using (StreamReader reader = new StreamReader(sour))
            {
                string s = "Файл содержит данные:\n\n";
                while (!reader.EndOfStream)
                {
                    s += reader.ReadLine() + "\n";
                }
                return s;
            }
        }

        //создание нового файла, где каждая строка содержит первый символ соответствующей строки
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
    }
}
