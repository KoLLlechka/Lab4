using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    internal class Tasks
    {
        public static string ForEx1<T>(T[] sarr)
        {
            List<T> list = new List<T>(sarr);
            return string.Join(" ", Lab5.RevList(list));
        }

        public static string ForEx2<T>(T[] sarr, T E, T F)
        {
            LinkedList<T> list = new LinkedList<T>(sarr);
            return string.Join(" ", Lab5.FToLinkedList(list, E, F));
        }

        public static string ForEx3(Dictionary<string, HashSet<string>> d)
        {
            string ans = string.Empty;
            HashSet<string> q1 = Lab5.AllStudents(d);
            HashSet<string> q2 = Lab5.SomeStudents(d);
            HashSet<string> q3 = Lab5.NobodyStudents(d);
            ans = "Дискотеки, в которые ходили все студенты группы: " + "\n" + 
                string.Join(", ", q1) + "\n" +
                "Дискотеки, в которые ходили некоторые студенты группы: " + "\n" + 
                string.Join(", ", q2) + "\n" +
                "Дискотеки, в которые не ходил ни один из студентов группы: " + "\n" + 
                string.Join(", ", q3) + "\n";
            return ans;
        }

        public static string ForEx4(string f)
        {
            return string.Join(", ", Lab5.Symbols(f));
        }

        public static string ForEx5(string f)
        {
            return Lab5.AdmittedExam(f);
        }

        public static string ForEx6(string[] sarr)
        {
            return Lab5.FillXmlFile(sarr);
        }
    }
}
