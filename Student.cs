using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace lab9
{
    public class Student
    {
        int age;
        double gpa;
        static int count = 0;

        public string Name { get; set; }

        public int Age
        {
            get => age;
            set
            {
                if (value <= 0 || value > 100)
                {
                    throw new Exception("Ошибка! Значение для поля age не должно быть меньше  0 или больше 100");  
                }
                else
                    age = value;
            }
        }

        public double Gpa
        {
            get => gpa;
            set
            {
                if (value > 10 || value < 0)
                {
                    throw new Exception("Ошибка! Значение для поля gpa должно быть в промежутке от 0 до 10");
                }
                else
                    gpa = value;
            }
        }

        public override string ToString()
        {
            return $"name: {Name}, age: {Age}, gpa: {Gpa.ToString("0.0")}";
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public Student ()
        {
            Name = "NoName";
            Age = 20;
            Gpa = 5.5;
            count++;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="gpa"></param>
        public Student(string name, int age, double gpa) 
        {
            this.Name = name;
            this.Age = age;
            this.Gpa = gpa;
            count++;
        }

        /// <summary>
        /// Конструктор копирования
        /// </summary>
        /// <param name="person"></param>
        public Student (Student person)
        {
            Name = person.Name;
            Age = person.Age;
            Gpa = person.Gpa;
            count++;
        }

        /// <summary>
        /// Вывод информации о студенте
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"Имя - {Name}, Возраст - {Age}, Балл - {Gpa.ToString("0.0")}");
            Console.WriteLine();
        }

        /// <summary>
        /// Сравнение возрастов 2 студентов (статическая функция)
        /// </summary>
        /// <param name="person1"></param>
        /// <param name="person2"></param>
        public int CompareAge(Student person)
        {
            return Age.CompareTo(person.Age);
        }

        /// <summary>
        /// Сравнение баллов 2 студентов (нестатический метод)
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static int CompareGpa(Student person1, Student person2)
        {
            return person1.Gpa.CompareTo(person2.Gpa);
        }

        /// <summary>
        /// Унарная операция: увеличение возраста студента на 1
        /// </summary>
        /// <param name="Age"></param>
        /// <returns></returns>
        public static Student operator ++(Student person)
        {
            Student personChanged = new Student();
            personChanged.Name = person.Name;
            personChanged.Age = person.Age + 1;
            personChanged.Gpa = person.Gpa;
            return personChanged;
        }

        /// <summary>
        /// Форматирование имени: перая буква заглавная, остальные строчные
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public static string operator ~ (Student t)
        {
            string formattedName = char.ToUpper(t.Name[0]) + t.Name.Substring(1).ToLower();
            t.Name = formattedName;
            return formattedName;
        }

        /// <summary>
        /// Новый студент с тем же возрастом и gpa, но другим именем
        /// </summary>
        /// <param name="s"></param>
        /// <param name="newName"></param>
        /// <returns></returns>
        public static Student operator % (Student s, string newName)
        {
            Student newStudent = new Student();
            newStudent.Age = s.Age;
            newStudent.Gpa = s.Gpa;
            newStudent.Name = newName;
            return newStudent;
        }

        public static Student operator %(string newName, Student s)
        {
            Student newStudent = new Student();
            newStudent.Age = s.Age;
            newStudent.Gpa = s.Gpa;
            newStudent.Name = newName;
            return newStudent;
        }

        /// <summary>
        /// Тот же студент, но с уменьшенным gpa
        /// </summary>
        /// <param name="s"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static Student operator - (Student s, double d)
        {
            Student changedGpa = new Student();
            changedGpa.Age = s.Age;
            changedGpa.Gpa = s.Gpa - d;
            changedGpa.Name = s.Name;
            return changedGpa;
        }

        /// <summary>
        /// Вычисление номера курса студента (явное приведение)
        /// </summary>
        public static explicit operator int (Student p)
        {
            if (p.Age <= 21 & p.Age >= 18)
                return p.Age - 17;
            else
                return -1;
        }

        /// <summary>
        /// неявное приведение типов
        /// </summary>
        /// <param name="d"></param>
        public static implicit operator bool(Student d)
        {
            bool result = d.Gpa < 6;
            return result;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not Student) return false;
            return ((Student)obj).age == this.Age && ((Student)obj).gpa == this.Gpa;
        }

        public static int GetCount => count;
    }
}
