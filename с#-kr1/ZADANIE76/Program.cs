    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
     
    class Program
    {
        static void Main()
        {
            Console.Write("Введите количество строк: ");
            int firstDimension = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введите количество столбцов: ");
            int secondDimension = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int[,] array = new int[firstDimension, secondDimension];
            for (int i = 0; i < array.GetLength(0); i++)
            {
              string enterString = Console.ReadLine();
              string[] massiveString = enterString.Split(new Char[] { ' ' });
              for (int j = 0; j < massiveString.Length; j++)
              {
                array[i, j] = int.Parse(massiveString[j]);
              }
            }
 
            // Перебираем каждый элемент матрицы и если он равен 0, тогда инкрементируем локальную переменную kolElem и 
            // выводим потом на экран в каждой строке. Если строка не содержит нулевые элементы матрицы, инкрементируем 
            // локальную переменную kolStr
            int kolElem = 0;
            int kolStr = 0;
            for (int i = 0; i < firstDimension; ++i)
            {
                for (int j = 0; j < secondDimension; ++j)
                {
                    if (array[i, j] == 0)
                    {
                        ++kolElem;
                    }
                }
                Console.WriteLine("Строка {0} содержит {1} нулевых элементов", (i+1), kolElem);
                if (kolElem == 0)
                {
                    ++kolStr;
                }
                else
                {
                    kolElem = 0;
                }
            }
 
            // Выводим на экран локальную переменную kolStr
            Console.WriteLine("Количество строк не содержащих нулевые элементы: " + kolStr);
            Console.WriteLine();
    
            //Находим максимальное значение в матрице
            int maxElem = 0;
            int kolVstrech = 0;
            for (int i = 0; i < firstDimension; ++i)
            {
                for (int j = 0; j < secondDimension; ++j)
                {
                    if (array[i, j] == maxElem)
                    {
                        ++kolVstrech;
                    }
 
                    if (array[i, j] > maxElem)
                    {
                        maxElem = array[i, j];
                        kolVstrech = 1;
                    }
 
                }
            }
            //while (kolVstrech < 2)
            //{
                //if (kolVstrech <= 1)
                //{
                    //Console.WriteLine("Максимальное значение: {0} не повторяется в матрице, поэтому ищем новое максимальное значение, которое встречается два или более раз", maxElem);
                    //int maxElemPrediduschiy = maxElem;
                    //maxElem = 0;
                    //kolVstrech = 0;
                    //for (int i = 0; i < firstDimension; ++i)
                    //{
                        //for (int j = 0; j < secondDimension; ++j)
                        //{
                            //if ((array[i, j] == maxElem) && (array[i, j] < maxElemPrediduschiy))
                            //{
                                //++kolVstrech;
                            //}
 
                            //if ((array[i, j] > maxElem) && (array[i, j] < maxElemPrediduschiy))
                            //{
                                //maxElem = array[i, j];
                                //kolVstrech = 1;
                            //}
 
                        //}
                    //}
                //}
            //}
 
            // Находим максимальное 
            Console.WriteLine("Максимальный элемент: {0}", maxElem);
            Console.ReadKey();
        }
    }