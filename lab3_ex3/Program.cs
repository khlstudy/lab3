using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_ex3
{
    class Parent
    {
        protected double Pole1;  // Довжина кімнати
        protected double Pole2;  // Ширина кімнати
        protected double Pole3;  // Висота кімнати
        protected double Pole4;  // Площа стін
        protected double Pole5;  // Потрібна кількість штукатурки

        public Parent()
        {
            Pole1 = 0;
            Pole2 = 0;
            Pole3 = 0;
            Pole4 = 0;
            Pole5 = 0;
        }

        public Parent(double length, double width, double height)
        {
            Pole1 = length;
            Pole2 = width;
            Pole3 = height;
            Pole4 = 2 * (length + width) * height;  // Площа стін
            Pole5 = Pole4 * 5;  // Потрібна кількість штукатурки
        }

        public void Print()
        {
            Console.WriteLine($"Довжина кімнати: {Pole1}, Ширина кімнати: {Pole2}, Висота кімнати: {Pole3}, " +
                              $"Площа стін: {Pole4}, Потрібна кількість штукатурки: {Pole5}");
        }

        public bool Metod1(double plasterPerDay)
        {
            if (Pole5 >= plasterPerDay)
            {
                Pole5 -= plasterPerDay;
                return true;
            }
            return false;
        }
    }

    class Child : Parent
    {
        private double Pole6;  // Ширина шпалер
        private double Pole7;  // Довжина шпалер в рулоні
        private int Pole8;  // Кількість рулонів

        public Child(double wallpaperWidth, double wallpaperLength, double roomLength, double roomWidth, double roomHeight)
            : base(roomLength, roomWidth, roomHeight)
        {
            Pole6 = wallpaperWidth;
            Pole7 = wallpaperLength;
            Pole8 = (int)Math.Ceiling(2 * (Pole1 + Pole2) / Pole6);  // Округлення кількості рулонів в більшу сторону
        }

        public new void Print()  // Перевизначено метод Print
        {
            base.Print();  // Викликаємо метод Print з базового класу
            Console.WriteLine($"Ширина шпалер: {Pole6}, Довжина шпалер в рулоні: {Pole7}, Кількість рулонів: {Pole8}");
        }
        public bool Metod2(int rollsPerDay)
        {
            if (Pole8 >= rollsPerDay)
            {
                Pole8 -= rollsPerDay;
                return true;
            }
            return false;
        }
    }

class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Генерація випадкових значень для батьківського класу
            Random random = new Random();
            double roomLength = random.Next(3, 10);  
            double roomWidth = random.Next(3, 7);  
            double roomHeight = random.Next(2, 4);  

            // Створення об'єкта батьківського класу з випадковими значеннями
            Parent parent = new Parent(roomLength, roomWidth, roomHeight);
            Console.WriteLine("Батьківський клас:");
            parent.Print();
            double plasterPerDay = 100;  // кг на день
            int daysForPlastering = 0;

            while (parent.Metod1(plasterPerDay))
            {
                daysForPlastering++;
            }

            Console.WriteLine($"Знадобилося {daysForPlastering} днів на штукатурку."); 
            // Генерація випадкових значень для дочірнього класу
            double wallpaperWidth = 0.53;  // Ширина шпалер 
            double wallpaperLength = random.Next(8, 15);  

            // Створення об'єкта дочірнього класу з випадковими значеннями
            Child child = new Child(wallpaperWidth, wallpaperLength, roomLength, roomWidth, roomHeight);
            Console.WriteLine("\nДочірній клас:");
            child.Print();

            // Обчислюємо кількість днів на поклейку шпалер
            int rollsPerDay = 3;  // рулонів на день
            int daysForWallpapering = 0;

            while (child.Metod2(rollsPerDay))
            {
                daysForWallpapering++;
            }

            Console.WriteLine($"Знадобилося {daysForWallpapering} днів на поклейку шпалер.");
            Console.ReadLine();
        }
    }
}




