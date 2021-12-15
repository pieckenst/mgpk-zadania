using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp28
{
    class Program
    {
        static double x1(double r) => (Math.PI * r * r);
        static double x2(double r) => (2 * Math.PI * r);

        
        static void Main(string[] args)
        {
            double r;
            do {
                Console.WriteLine("Введите число: ");
                Double.TryParse(Console.ReadLine(), out r);
            }
            while (r <= 0);
            Console.WriteLine("Площадь круга: {0} , Длина Окружности {1}", x1(r), x2(2));
            Console.ReadLine();
            

        }
    }
}
