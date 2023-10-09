using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_ex2
{ 
    class Parent
    {
        protected double Pole1;  // Перша сторона
        protected double Pole2;  // Друга сторона
        protected double Pole3;  // Кут в градусах
        protected double Pole4;  // Кут в радіанах

        public Parent()
        {
            Pole1 = 0;
            Pole2 = 0;
            Pole3 = 0;
            Pole4 = 0;
        }

        public Parent(double side1, double side2, double angleDegrees)
        {
            Pole1 = side1;
            Pole2 = side2;
            Pole3 = angleDegrees;
            Pole4 = angleDegrees * (Math.PI / 180);  // Переведення кута в радіани
        }

        public void Print()
        {
            Console.WriteLine($"Перша сторона: {Pole1}, Друга сторона: {Pole2}, Кут в градусах: {Pole3}, Кут в радіанах: {Pole4}");
        }

        public double Metod1()
        {
            return Pole1 * Pole2 * Math.Sin(Pole4);  // Площа паралелограма
        }

        public Tuple<double, double> Metod2()
        {
            // Знаходження діагоналей паралелограма
            double diagonal1 = Math.Sqrt(Math.Pow(Pole1, 2) + Math.Pow(Pole2, 2) + 2 * Pole1 * Pole2 * Math.Cos(Pole4));
            double diagonal2 = Math.Sqrt(Math.Pow(Pole1, 2) + Math.Pow(Pole2, 2) - 2 * Pole1 * Pole2 * Math.Cos(Pole4));
            return Tuple.Create(diagonal1, diagonal2);
        }
    }

    class Child : Parent
    {
        public Child(double side1, double side2) : base(side1, side2, 90)
        {
            // Конструктор з двома параметрами для прямокутника
        }

        public double Metod3()
        {
            // Площа описаного кола для прямокутника
            return Math.PI * Pole1 * Pole2 / 4;
        }

        public double Metod4()
        {
            // Довжина описаного кола для прямокутника
            return Math.PI * Math.Sqrt(Math.Pow(Pole1, 2) + Math.Pow(Pole2, 2));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                double side1 = random.Next(1, 10);  // Випадкова перша сторона
                double side2 = random.Next(1, 10);  // Випадкова друга сторона
                double angle = random.Next(1, 180);  // Випадковий кут в градусах

                if (angle != 90)  // Якщо це паралелограм
                {
                    Console.WriteLine("Паралелограм");
                    Parent parallelogram = new Parent(side1, side2, angle);
                    parallelogram.Print();
                    Console.WriteLine($"Площа паралелограма: {parallelogram.Metod1()}");
                    var diagonals = parallelogram.Metod2();
                    Console.WriteLine($"Діагональ 1: {diagonals.Item1}, Діагональ 2: {diagonals.Item2}");
                }
                else  // Якщо це прямокутник
                {
                    Console.WriteLine("Прямокутник");
                    Child rectangle = new Child(side1, side2);
                    rectangle.Print();
                    Console.WriteLine($"Площа описаного кола: {rectangle.Metod3()}");
                    Console.WriteLine($"Довжина описаного кола: {rectangle.Metod4()}");
                }
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }

}
