namespace lab9
{
    internal class Program
    {
        /// <summary>
        /// Функция ввода имени для класса Student
        /// </summary>
        /// <returns></returns>
        static string EnterName()
        {
            Console.WriteLine("Введите имя студента: ");
            string name = Console.ReadLine();
            return name;
        }

        /// <summary>
        /// Функция ввода возраста для класса Student
        /// </summary>
        /// <returns></returns>
        static int EnterAge()
        {
            int age;
            Console.WriteLine("Введите возраст студента: ");
            bool isConvert = int.TryParse(Console.ReadLine(), out age);
            if (!isConvert)
                Console.WriteLine("Неверный формат ввода");
            return age;
        }

        /// <summary>
        /// Функция ввода Gpa для класса Student
        /// </summary>
        /// <returns></returns>
        static double EnterGpa()
        {
            double gpa;
            Console.WriteLine("Введите gpa студента: ");
            bool isConvert = double.TryParse(Console.ReadLine(), out gpa);
            if (!isConvert)
                Console.WriteLine("Неверный формат ввода");
            return gpa;
        }

        /// <summary>
        /// Функция ввода имени для класса StudentArray
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        static string[] EnterNames(int length)
        {
            string[] names = new string[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Введите имя студента {i+1}");
                names[i] = Console.ReadLine();
            }
            return names;
        }

        /// <summary>
        /// Функция ввода возраста для класса StudentArray
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        static int[] EnterAges(int length)
        {
            int[] ages = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Введите возраст студента {i + 1}");
                ages[i] = int.Parse(Console.ReadLine());
            }
            return ages;
        }

        /// <summary>
        /// Функция ввода Gpa для класса StudentArray
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        static double[] EnterGpaes(int length)
        {
            double[] gpaes = new double[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine($"Введите Gpa студента {i + 1}");
                gpaes[i] = double.Parse(Console.ReadLine());
            }
            return gpaes;
        }

        /// <summary>
        /// Функция для поиска самого старшего студента с GPA > 8
        /// </summary>
        /// <param name="personArray"></param>
        /// <returns></returns>
        static int FindStudent(StudentArray personArray)
        {
            int maxAge = -1;
            double maxGpa = 8.0;
            int index = -1;
            for (int i = 0; i < personArray.Length; i++)
            {
                if (personArray[i].Gpa > maxGpa)
                {
                    if (personArray[i].Age > maxAge)
                    {
                        maxAge = personArray[i].Age;
                        index = i;
                    }                   
                }
            }
            return index;
        }

        static void Main(string[] args)
        {
            Student person1 = new Student();
            person1.Name = EnterName();
            person1.Age = EnterAge();
            person1.Gpa = EnterGpa();
            Student person2 = new Student();
            person2.Name = EnterName();
            person2.Age = EnterAge();
            person2.Gpa = EnterGpa();
            Console.WriteLine("Студент 1:");
            person1.Print();
            Console.WriteLine("Студент 2:");
            person2.Print();

            Console.WriteLine("=== Сравнение студентов по возрасту ===");
            int resultCompareAge = person1.CompareAge(person2); // обращение к нестатическому методу
            if (resultCompareAge > 0)
            {
                Console.WriteLine($"{person1.Name} старше {person2.Name}");
                Console.WriteLine();
            }
            else
            {
                if (resultCompareAge < 0)
                {
                    Console.WriteLine($"{person1.Name} младше {person2.Name}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"{person1.Name} ровесник {person2.Name}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("=== Сравнение студентов по Gpa ===");
            int resultCompareGpa = Student.CompareGpa(person1, person2); // обращение к статическому методу
            if (resultCompareGpa > 0)
            {
                Console.WriteLine($"GPA {person1.Name} выше GPA {person2.Name}");
                Console.WriteLine();
            }
            else
            {
                if (resultCompareGpa < 0)
                {
                    Console.WriteLine($"GPA {person1.Name} ниже GPA {person2.Name}");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"GPA {person1.Name} равен GPA {person2.Name}");
                    Console.WriteLine();
                }
            }

            Console.WriteLine("==== Унарная операция ' ++ ' - Увеличение возраста студента на 1 ===="); ;
            try
            {
                person1++;
                person1.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            Console.WriteLine("===== Унарная операция ' ~ ' - Форматирование имени студента ===== ");
            person2.Name = ~person2;
            person2.Print();

            Console.WriteLine("==== Бинарная операция ' % ' - Студент с таким же возрастом и Gpa, но другим именем ==== ");
            Student person3 = person1 % "Sara";
            person3.Print();

            Console.WriteLine("==== Бинарная операция ' - ' - Уменьшение Gpa ==== ");
            try
            {
                person2 = person2 - 5.1;
                person2.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            Console.WriteLine("===== Явное приведение к типу int (нахождение курса студента) ===== ");
            if ((int)person1 > 0)
            {
                Console.WriteLine($"Студент {person1.Name} учится на {(int)person1} курсе");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Невозможно определить номер курса");
                Console.WriteLine();
            }

            Console.WriteLine("===== Неявное приведение к типу bool ===== ");
            if (person3)
            {
                Console.WriteLine($"Студент {person3.Name} скорее всего имеет удовлетворительные оценки");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Студент {person3.Name} скорее всего имеет оценки выше 'удовлетворительно'");
                Console.WriteLine();
            }

            Console.WriteLine($"Создано {Student.GetCount} объекта в классе Student");
            Console.WriteLine();

            Console.WriteLine("==== Класс StudentArray ====");
            Console.WriteLine();

            /// Использование конструктора с параметром (заполнение рандомными значениями)///
            Console.WriteLine("1 массив - Заполнение рандомными значениями (конструктор с параметром)");
            StudentArray personArray1 = new StudentArray(5);
            personArray1.Print();

            ///Использование конструктора с параметрами (ручной ввод элементов)///
            Console.WriteLine("2 массив - Пользовательский ввод элементов (конструктор с параметрами)");
            int length;
            Console.WriteLine("Введите длину массива: ");
            bool isConvert = int.TryParse(Console.ReadLine(), out length);
            if (!isConvert)
                Console.WriteLine("Неверный формат числа");
            string[] names = EnterNames(length);
            int[] ages = EnterAges(length);
            double[] gpaes = EnterGpaes(length);
            StudentArray personArray2 = new StudentArray(length, names, ages, gpaes);
            Console.WriteLine("Сформированный 2 массив  ");
            personArray2.Print();

            ///Использование конструктора без параметров///
            Console.WriteLine("3 массив - Конструктор без параметров");
            StudentArray personArray3 = new StudentArray();
            personArray3.Print();

            ///Использование конструктора копирования///
            Console.WriteLine("4 массив - Глубокое копирование 1-го массива");
            StudentArray personArray4 = new StudentArray(personArray1);
            personArray4.Print();

            /// Использование индексаторов ///
            Console.WriteLine();
            Console.WriteLine("=== Работа с индексаторами ===");
            Console.WriteLine("1 массив - с измененным 1-ым элементом");
            personArray1[0] = new Student("Allison", 17, 9.0); // запись объекта с существющим индексом            
            personArray1.Print();
            Console.WriteLine($"Студент с индексом 4 - {personArray1[4]}"); // получение объекта с существующим индексом

            Console.WriteLine("2 массив");
            personArray2.Print();
            try
            {
                personArray2[100] = new Student("Dolly", 12, 4.8); //запись объекта с несуществующим индексом
                Console.WriteLine(personArray2[100]); // получение объекта с несуществующим индексом
                personArray2.Print();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }

            Console.WriteLine("==== Поиск в 1-ом массиве самого старшего студента с gpa > 8  ====");
            int index = FindStudent(personArray1);
            if (index >= 0)
                Console.WriteLine($"Самый старший студент с Gpa > 8 - {personArray1[index]}");
            else
                Console.WriteLine("Такого студента нет");

            Console.WriteLine();
            Console.WriteLine($"Создано {StudentArray.GetCountArray} объекта в классе StudentArray");
        }
    }
}
