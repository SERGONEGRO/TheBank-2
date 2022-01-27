using System;
using System.Threading;
using System.Threading.Tasks;

namespace Theme_16
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread firstThead = new(PrintSomething);
            firstThead.Start();

            Thread secondThead = new Thread(PrintSomething);
            secondThead.Start();

            Thread thirdThead = new Thread(PrintSomething);
            thirdThead.Start();
        }

        //static async void PrintSomethingAsync()
        //{
        //    await Task.Run(() => PrintSomething());
        //    Console.WriteLine("Конец метода PrintSomethingAsync");
        //}

        static void PrintSomething()
        {
            var th = Thread.CurrentThread;

            Console.WriteLine($"Поток ID: {th.GetHashCode()} START");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Hello from thread №{th.GetHashCode()}");
                Thread.Sleep(100);
            }

            Console.WriteLine($"\nПоток: {th.Name}, ID: {th.GetHashCode()}. Конец работы");
           
        }
    }

    
}
