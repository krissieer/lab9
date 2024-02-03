using lab9;
using System;
using System.Xml.Linq;
namespace Тесты
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ConstructorWithParametrs()
        {
            // Arrange
            Student expected = new Student("Jon", 20, 5.5);

            //Act
            Student actual = new Student("Jon", 20, 5.5);

            //Accert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void PropertiesAge1()
        {
            // Arrange 
            Student person = new Student("Jon", 20, 5.5);

            //Act
            try
            {
                person.Age = 180;
            }
            catch (Exception ex) 
            {
                Assert.AreEqual("Ошибка! Значение для поля age не должно быть меньше  0 или больше 100", ex.Message);
            }    
        }

        [TestMethod]
        public void PropertiesAge2()
        {
            // Arrange 
            Student person = new Student("Jon", 20, 5.5);

            //Act
            try
            {
                person.Age = -3;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Ошибка! Значение для поля age не должно быть меньше  0 или больше 100", ex.Message);
            }
        }

        [TestMethod]
        public void ConstructorWithoutParametrs()
        {
            // Arrange
            Student expected = new Student();

            //Act
            Student actual = new Student();

            //Accert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Age, actual.Age);
            Assert.AreEqual(expected.Gpa, actual.Gpa);
        }

        [TestMethod]
        public void CopyConstructor()
        {
            // Arrange
            Student expected = new Student("Jon", 20, 3.5);

            //Act
            Student actual = new Student(expected);

            //Accert
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Age, actual.Age);
            Assert.AreEqual(expected.Gpa, actual.Gpa);
        }

        [TestMethod]
        public void CompareGpa_returnTrue()
        {
            // Arrange         
            Student person1 = new Student("Jon", 22, 3.5);
            Student person2 = new Student("Mary", 19, 2.6);
            int expected = 1;

            //Act
            int actual = Student.CompareGpa(person1,person2);

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareGpa_returnFalse()
        {
            // Arrange         
            Student person1 = new Student("Jon", 22, 3.5);
            Student person2 = new Student("Mary", 19, 4.6);
            int expected = -1;

            //Act
            int actual = Student.CompareGpa(person1, person2);

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareGpa_returnZero()
        {
            // Arrange         
            Student person1 = new Student("Jon", 22, 3.5);
            Student person2 = new Student("Mary", 19, 3.5);
            int expected = 0;

            //Act
            int actual = Student.CompareGpa(person1, person2);

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareAge_returnTrue()
        {
            // Arrange         
            Student person1 = new Student("Jon", 22, 3.5);
            Student person2 = new Student("Mary", 19, 3.5);
            int expected = 1;

            //Act
            int actual = person1.CompareAge(person2);

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareAge_returnFalse()
        {
            // Arrange         
            Student person1 = new Student("Jon", 18, 3.5);
            Student person2 = new Student("Mary", 19, 3.5);
            int expected = -1;

            //Act
            int actual = person1.CompareAge(person2);

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareAge_returnZero()
        {
            // Arrange         
            Student person1 = new Student("Jon", 19, 3.5);
            Student person2 = new Student("Mary", 19, 3.5);
            int expected = 0;

            //Act
            int actual = person1.CompareAge(person2);

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IncrementAge()
        {
            // Arrange         
            Student person = new Student("Jon", 19, 3.5);
            Student expected = new Student("Jon", 20, 3.5);

            //Act
            person++;
            Student actual = person;

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FormatName()
        {
            // Arrange         
            Student person = new Student("jon", 19, 3.5);
            Student expected = new Student("Jon", 19, 3.5);

            //Act
            person.Name = ~person;
            Student actual = person;

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NewStudent()
        {
            // Arrange         
            Student person = new Student("Jon", 19, 3.5);
            Student expected = new Student("Sara", 19, 3.5);

            //Act
            person = person % "Sara";
            Student actual = person;

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NewStudent2()
        {
            // Arrange         
            Student person = new Student("Jon", 19, 3.5);
            Student expected = new Student("Sara", 19, 3.5);

            //Act
            person = "Sara" % person;
            Student actual = person;

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DecrementumGpaExeption()
        {
            // Arrange 
            Student person = new Student("Jon", 20, 5.2);

            //Act
            try
            {
                person = person - 5.9;
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Ошибка! Значение для поля gpa должно быть в промежутке от 0 до 10", ex.Message);
            }
        }

        [TestMethod]
        public void DecrementumGpaExeption2()
        {
            // Arrange 
            Student person = new Student("Jon", 20, 9.2);

            //Act
            try
            {
                person = person - (-2.1);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Ошибка! Значение для поля gpa должно быть в промежутке от 0 до 10", ex.Message);
            }
        }

        [TestMethod]
        public void DecrementumGpa()
        {
            // Arrange         
            Student person = new Student("Jon", 19, 7.5);
            Student expected = new Student("Jon", 19, 5.4);

            //Act
            Student actual = person - 2.1;

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExplicitToInt()
        {
            // Arrange         
            Student person = new Student("Jon", 19, 3.5);
            int expected = 2;

            //Act
            int actual = (int)person;

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ExplicitToInt2()
        {
            // Arrange         
            Student person = new Student("Jon", 25, 3.5);
            int expected = -1;

            //Act
            int actual = (int)person;

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplicitToBool_ReturnTrue()
        {
            // Arrange         
            Student person = new Student("Jon", 18, 3.5);
            bool expected = true;

            //Act
            bool actual = (person);

            //Accert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ImplicitToBool_ReturnFalse()
        {
            // Arrange         
            Student person = new Student("Jon", 18, 8.9);
            bool expected = false;

            //Act
            bool actual = (person);

            //Accert
            Assert.AreEqual(expected, actual);
        }

        // Тестирование класса StudentArray

        [TestMethod]
        public void RandomConstructorWithParametrs()
        {
            // Arrange
            int Length = 3;

            //Act
            StudentArray personArray = new StudentArray(Length);

            //Accert
            Assert.AreEqual(Length, personArray.Length);
        }

        [TestMethod]
        public void ArrayConstructorWithoutParametrs()
        {
            // Arrange
            StudentArray personArray = new StudentArray();

            //Assert
            Assert.AreEqual(2,personArray.Length);
        }

        [TestMethod]
        public void ArrayCopyConstructor()
        {
            // Arrange
            StudentArray personArray = new StudentArray(3);
            personArray[0] = new Student("Jon", 18, 8.9);
            personArray[1] = new Student("Tod", 20, 7.4);
            personArray[2] = new Student("Lola", 21, 6.8);

            //Act
            StudentArray personArray2 = new StudentArray(personArray);

            //Accert
            Assert.AreEqual(personArray.Length, personArray2.Length);
            for (int i = 0; i < personArray.Length; i++)
            {
                Assert.AreNotSame(personArray[i], personArray2[i]); //ссылки указывают на разные объекты в памяти (проверка глубокого копирования)
                Assert.AreEqual(personArray[i], personArray2[i]); // равенство значений элементов
            }
        }

        [TestMethod]
        public void ArrayConstructorWithParametrs()
        {
            // Arrange
            int Length = 3;
            string[] names = {"Don", "Shon", "Rihana"};
            int[] ages = {17,22,18};
            double[] gpaes = {5.4, 9.4, 7.6};

            //Act
            StudentArray personArray = new StudentArray(Length, names, ages, gpaes);

            //Accert
            Assert.AreEqual(personArray.Length, Length);
            Assert.AreEqual(personArray[0].Name, names[0]);
            Assert.AreEqual(personArray[1].Name, names[1]);
            Assert.AreEqual(personArray[2].Name, names[2]);
            Assert.AreEqual(personArray[0].Age, ages[0]);
            Assert.AreEqual(personArray[1].Age, ages[1]);
            Assert.AreEqual(personArray[2].Age, ages[2]);
            Assert.AreEqual(personArray[0].Gpa, gpaes[0]);
            Assert.AreEqual(personArray[1].Gpa, gpaes[1]);
            Assert.AreEqual(personArray[2].Gpa, gpaes[2]);
        }

        [TestMethod]
        public void IndexerArray()
        {
            // Arrange
            StudentArray personArray = new StudentArray(3);
            personArray[0] = new Student("Jon", 18, 8.9);
            personArray[1] = new Student("Tod", 20, 7.4);
            personArray[2] = new Student("Lola", 21, 6.8);

            //Act
            Student element = personArray[0];

            //Accert
            Assert.AreEqual(element, personArray[0]);
        }

        [TestMethod]
        public void IndexerArrayExceptoin()
        {
            // Arrange
            int Length = 3;
            StudentArray personArray = new StudentArray(Length);
            personArray[0] = new Student("Jon", 18, 8.9);
            personArray[1] = new Student("Tod", 20, 7.4);
            personArray[2] = new Student("Lola", 21, 6.8);

            //Act
            try
            {
                personArray[-8] = new Student("Kit", 16, 6.4);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Индекс выходит за пределы массива", e.Message);
            }
        }

        [TestMethod]
        public void IndexerArrayExceptoin2()
        {
            // Arrange
            StudentArray personArray = new StudentArray(3);
            personArray[0] = new Student("Jon", 18, 8.9);
            personArray[1] = new Student("Tod", 20, 7.4);
            personArray[2] = new Student("Lola", 21, 6.8);
            Student element;

            //Act
            try
            {
                element = personArray[4];
            }
            catch (Exception e)
            {
                Assert.AreEqual("Индекс выходит за пределы массива", e.Message);
            }
        }

        [TestMethod]
        public void IndexerArrayExceptoin3()
        {
            // Arrange
            StudentArray personArray = new StudentArray(3);
            personArray[0] = new Student("Jon", 18, 8.9);
            personArray[1] = new Student("Tod", 20, 7.4);
            personArray[2] = new Student("Lola", 21, 6.8);
            Student element;

            //Act
            try
            {
                element = personArray[-1];
            }
            catch (Exception e)
            {
                Assert.AreEqual("Индекс выходит за пределы массива", e.Message);
            }          
        }

        [TestMethod]
        public void ArrayToString()
        {
            // Arrange
            Student person = new Student("Jon", 18, 8.9);
            string expected = "name: Jon, age: 18, gpa: 8,9";

            //Act
            string actual = person.ToString();

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}