using System;
using System.Threading;
using System.Threading.Tasks;

namespace Theme_16
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintSomethingAsync();
            //PrintSomethingAsync(50, "thread #2", 50);
            //PrintSomethingAsync(100, "thread #3", 80);

        }

        static async void PrintSomethingAsync(/*int delay, string message, int count*/)
        {
            Console.WriteLine("Начало метода PrintSomethingAsync");
            //await Task.Run(() => PrintSomething(delay, message, count));
            await Task.Run(() => PrintSomething());
            Console.WriteLine("Конец метода PrintSomethingAsync");
        }

        public static void PrintSomething()
        {
            Console.WriteLine("хуй");
            //for (int i = 0; i >= 100; i++)
            //{
                
            //    Thread.Sleep(20);
            //}
        }
    }

    //class Program
    //{
    //    static void Factorial()
    //    {
    //        int result = 1;
    //        for (int i = 1; i <= 6; i++)
    //        {
    //            result *= i;
    //        }
    //        Thread.Sleep(8000);
    //        Console.WriteLine($"Факториал равен {result}");
    //    }
    //    // определение асинхронного метода
    //    static async void FactorialAsync()
    //    {
    //        Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
    //        await Task.Run(() => Factorial());                // выполняется асинхронно
    //        Console.WriteLine("Конец метода FactorialAsync");
    //    }

    //    static void Main(string[] args)
    //    {
    //        FactorialAsync();   // вызов асинхронного метода

    //        Console.WriteLine("Введите число: ");
    //        int n = Int32.Parse(Console.ReadLine());
    //        Console.WriteLine($"Квадрат числа равен {n * n}");

    //        Console.Read();
    //    }

    //    public static void PrintSomething()
    //    {
    //        Console.WriteLine("");
    //    }
    //}
}
