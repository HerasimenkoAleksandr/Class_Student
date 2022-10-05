using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Student
{
    class Program
    {
        enum Subject { programming, administration, design }
        public class Student
        {
            public string surname { get; set; }
            public string name { get; set; }
            public string patronymic { get; set; }
            public string group { get; set; }
            public int age { get; set; }
            public int[][] assessment;

            public Student(string surnameP, string nameP, string patronymicP, string groupP, int ageP)
            {
                surname = surnameP;
                name = nameP;
                patronymic = patronymicP;
                group = groupP;
                age = ageP;
                int size_sabject = 3;
                assessment = new int[size_sabject][];
                assessment[0] = new int[3];
                assessment[1] = new int[3];
                assessment[2] = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Random A = new Random();

                        assessment[i][j] = A.Next(1, 12);
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine("Имя студента: " + name);
                Console.WriteLine("Отчество: " + patronymic);
                Console.WriteLine("Фамилия: "+ surname);
                Console.WriteLine("Группа: "+ group);
                Console.WriteLine("Возраст: "+age);

            }
            public void Push_Assessment()
            {
                int a;
                Console.WriteLine("Выберите предмет по которому надо добавить оценку:");
                Console.WriteLine("нажмите 1 - програмирование");
                Console.WriteLine("нажмите 2 - администрирование");
                Console.WriteLine("нажмите 3 - дизайн");
                a = Int32.Parse(Console.ReadLine());
                if (a > 0 && a < 4)
                {
                    Subject subject = (Subject)Enum.GetValues(typeof(Subject)).GetValue(a - 1);

                    int size = assessment[(int)subject].Length;
                    Array.Resize(ref (assessment[(int)subject]), size + 1);
                    Console.WriteLine("Введите оценку по предмету " + Enum.GetName(typeof(Subject), subject));
                    int b = Int32.Parse(Console.ReadLine());
                    assessment[(int)subject][size] = b;
                }
                else
                {
                    Push_Assessment();
                }
            }

            public void GetAverageMark()
            {
                int a;
                Console.WriteLine("Выберите предмет по которому хотите увидеть средний бал");
                Console.WriteLine("нажмите 1 - програмирование");
                Console.WriteLine("нажмите 2 - администрирование");
                Console.WriteLine("нажмите 3 - дизайн");
                a = Int32.Parse(Console.ReadLine());
                if (a > 0 && a < 4)
                {
                    Subject subject = (Subject)Enum.GetValues(typeof(Subject)).GetValue(a - 1);
                    var average = assessment[(int)subject].Average();
                    Console.WriteLine("Средний бал по предмету " + Enum.GetName(typeof(Subject), subject) + " = " + average);
                }

            }



        }




            static void Main(string[] args)
            {
            Console.WriteLine("Информация о студенте!");
            Student D=new Student("Petrov", "Valery", "Olegovich", "A", 25);
            D.Print();
            Console.WriteLine();
            D.GetAverageMark();
            Console.WriteLine();
            D.Push_Assessment();
            Console.WriteLine();
            D.GetAverageMark();

        }
        
    }
}
