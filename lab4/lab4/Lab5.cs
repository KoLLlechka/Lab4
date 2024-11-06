using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static lab4.Lab5;

namespace lab4
{
    public static class Lab5
    {
        //переворачивает список
        public static List<T> RevList<T>(List<T> list)
        {
            list.Reverse();
            return list;
        }

        //справа и слева от элемента E вставляет элемент F
        public static LinkedList<T> FToLinkedList<T>(LinkedList<T> list, T E, T F)
        {
            list.AddAfter(list.Find(E), F);
            list.AddBefore(list.Find(E), F);
            return list;
        }

        //дискотеки, в которые ходили все студенты группы
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

        //дискотеки, в которые ходили некоторые студенты группы
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

        //дискотеки, в которые не ходил ни один из студентов группы
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

        //символы, которые встречаются хотя бы однажды в словах с чётными номерами
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

        //сдавшие экзамен
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
                        result += p.Key + "\n";
                    }
                }
                return result.Trim('\n');
            }
        }

        [Serializable]
        //структура игрушки
        public struct Toy
        {
            public string Name;
            public double Cost;
            public int MinAge;
            public int MaxAge;
        }

        //заполнение xml файла структурами
        public static string FillXmlFile(string[] sarr)
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

            XmlSerializer xml = new XmlSerializer(typeof(Toy[]));
            using (FileStream wr = new FileStream("serialization.xml", FileMode.Create, 
                FileAccess.ReadWrite, FileShare.Read))
            {
                xml.Serialize(wr, toys);
                return ReadFile(wr, xml);
            }
        }

        //вывод данных файла
        public static string ReadFile(FileStream f, XmlSerializer xml)
        {
            string s = "Данные исходного файла:\n\n";
            f.Position = 0;
            f.Seek(0, SeekOrigin.Begin);
            Toy[] t = (Toy[])xml.Deserialize(f);
            foreach (Toy toy in t)
            {
                s += toy.Name + " " + toy.Cost + " " + toy.MinAge + " " + toy.MaxAge + "\n";
            }
            return s + "\n" + SuitableToys(f, xml);
        }

        //вывод подходит ли игрушка
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
    }
}
