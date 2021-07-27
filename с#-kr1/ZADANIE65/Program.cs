using System;
using System.Collections.Generic;

using System.Text;

namespace ZADANIE65
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Программа определяющая число отрицательных чисел во введенной с клавиатуры последовательности";
			Console.WriteLine("Задание 65 - Шифр 29 - \n Второй Курс Могилёвского Государственного Политехнического Колледжа - Сделано Савичем Андреем Олеговичем");
		    Console.WriteLine("Пожалуйста Введите последовательность");
			double max = +1;
			max = double.Parse(Console.ReadLine());
			double t = 0.0;
			int i = 0;
                        do
                        { 
				
			    t = double.Parse(Console.ReadLine());
				i ++;
		        }
			while(t < max);
			Console.WriteLine("Количество Отрицательных чисел - {0}", i);
			Console.ReadLine();
		}
	}
}
