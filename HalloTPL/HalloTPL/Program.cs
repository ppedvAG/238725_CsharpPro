using System;
using System.Threading;
using System.Threading.Tasks;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("** Hallo TPL **");

        //Parallel.Invoke(Zähle, Zähle, Zähle);

        //Parallel.For(0, 100000, new ParallelOptions() { MaxDegreeOfParallelism = 99 }
        //                          , i => Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {i}"));


        Task t1 = new Task(() =>
        {
            Console.WriteLine("T1 gestartet");
            Thread.Sleep(2000);

            throw new OutOfMemoryException();
            Console.WriteLine("T1 fertig");
        });

        t1.ContinueWith(t =>
        {
            Console.WriteLine("T1 continue (always)");
        });

        t1.ContinueWith(t =>
        {
            Console.WriteLine("T1 ok");
        }, TaskContinuationOptions.NotOnFaulted);

        t1.ContinueWith(t =>
        {
            Console.WriteLine($"T1 error {t.Exception.InnerException.Message}");
        }, TaskContinuationOptions.OnlyOnFaulted);

        t1.Start();

        Task<long> t2 = new Task<long>(() =>
        {
            Console.WriteLine("T2 gestartet");
            Thread.Sleep(1500);
            Console.WriteLine("T2 fertig");

            return 984775329872349;
        });
        t2.Start();

        //Task.WaitAll(t1, t2);

        Console.WriteLine($"T2 Result: {t2.Result}");

        Console.WriteLine("Ende");
        Console.ReadLine();
    }
    static void Zähle()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {i}");
        }
    }

}