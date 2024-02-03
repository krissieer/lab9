using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace lab9
{
    public class StudentArray
    {
        static int countArray = 0;
        static Random rnd = new Random();
        Student[] students;

        static string[] studentNames = {"Bob", "John","Clark", "Tom", "Jen", "Lexa", "Sarah", "Ben", "Kate", "Valery","Mark", "Ken", "Shown"};

        public int Length
        {
            get => students.Length; //доступ только "для чтения"
        }

        public StudentArray()
        {
            Student person1 = new Student();
            Student person2 = new Student();
            students = [person1, person2];
            countArray++;
        }

        /// <summary>
        /// Констуктор с параметрами, заполняющий рандомными значениями
        /// </summary>
        /// <param name="Length"></param>
        public StudentArray(int length)
        {
            students = new Student[length];
            for (int i = 0; i < length; i++)
            {
                int randonIndex = rnd.Next(0, 12);
                string name = studentNames[randonIndex];
                int age = rnd.Next(18, 21);
                double gpa = rnd.NextDouble()+rnd.Next(0,9);
                students[i] = new Student(name, age, gpa);
            }
            countArray++;
        }

        /// <summary>
        /// Конструктор с параметрами с пользовательским вводом
        /// </summary>
        /// <param name="Length"></param>
        /// <param name="names"></param>
        /// <param name="ages"></param>
        /// <param name="gpas"></param>
        public StudentArray(int length, string[] names, int[] ages, double[] gpas)
        {
            students = new Student[length];
            for (int i = 0; i < length; i++)
            {
                students[i] = new Student(names[i], ages[i], gpas[i]);
            }
            countArray++;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="other"></param>
        public StudentArray(StudentArray other)
        {
            students = new Student[other.Length];
            for (int i = 0; i < other.Length; i++)
                students[i] = new Student(other.students[i]);
            countArray++;
        }  

        public Student this[int index]
        {
            get
            {
                if (0 <= index && index < students.Length)
                    return students[index];
                else
                    throw new Exception("Индекс выходит за пределы массива");
            }
            set
            {
                if (0 <= index && index < students.Length)
                    students[index] = value;
                else
                    Console.WriteLine("Индекс выходит за пределы массива");
            }
        }

        public void Print()
        {
            foreach (Student student in students)
                Console.WriteLine($"name: {student.Name}, age: {student.Age}, gpa: {student.Gpa.ToString("0.0")}");
        }

        public static int GetCountArray => countArray;
    }
}
