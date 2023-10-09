using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{

    class Parent
    {
        protected double Pole1;  // Мінімальний посібник
        protected double Pole2;  // Підвищений коефіцієнт

        public Parent(double pole1, double pole2)
        {
            Pole1 = pole1;
            Pole2 = pole2;
        }

        public virtual void Print()
        {
            Console.WriteLine($"\nМінімальний посібник: {Pole1}. Підвищений коефіцієнт: {Pole2}. ");
        }

        public virtual double Metod()
        {
            return Pole1 * Pole2;
        }
    }

    class Child1 : Parent
    {
        private int Pole3;  // Група інвалідності

        public Child1(double pole1, double pole2, int pole3) : base(pole1, pole2)
        {
            Pole3 = pole3;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Група інвалідності: {Pole3}. Посібник за інвалідністю: {Metod()}. ");
        }

        public override double Metod()
        {
            double baseAmount = base.Metod();
            if (Pole3 == 1)
                return baseAmount * 1.3;
            else if (Pole3 == 2)
                return baseAmount * 1.2;
            else
                return baseAmount;
        }
    }

    class Child2 : Parent
    {
        private int Pole4;  // Кількість дітей

        public Child2(double pole1, double pole2, int pole4) : base(pole1, pole2)
        {
            Pole4 = pole4;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Кількість дітей: {Pole4}. Посібник багатодітним: {Metod()}. ");
        }

        public override double Metod()
        {
            double baseAmount = base.Metod();
            if (Pole4 >= 3 && Pole4 <= 5)
                return baseAmount * 1.1;
            else if (Pole4 > 5)
                return baseAmount * 1.2;
            else
                return baseAmount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Створення об'єктів
            Parent parent = new Parent(500, 1.5);
            Child1 child1 = new Child1(500, 1.5, 1);
            Child1 child2 = new Child1(500, 1.5, 2);
            Child2 child3 = new Child2(500, 1.5, 4);
            Child2 child4 = new Child2(500, 1.5, 6);

            // Виклик методів та виведення результатів
            parent.Print();
            Console.WriteLine("Звичайний посібник: " + parent.Metod());

            child1.Print();
            Console.WriteLine("Посібник за інвалідністю: " + child1.Metod());

            child2.Print();
            Console.WriteLine("Посібник за інвалідністю: " + child2.Metod());

            child3.Print();
            Console.WriteLine("Посібник багатодітним: " + child3.Metod());

            child4.Print();
            Console.WriteLine("Посібник багатодітним: " + child4.Metod());
            Console.ReadLine();
        }
    }

}
