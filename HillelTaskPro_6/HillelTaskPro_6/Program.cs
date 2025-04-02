using System;
using System.Collections.Generic;
using HillelTaskPro_6.Class;
class Program
{
    static void Main()
    {
        ////Task1
        //void GetMemory()
        //{
        //    long memory = GC.GetTotalMemory(false);
        //    Console.WriteLine($"Используется памяти: {memory/1024.0/1024.0:F2} мб");
        //}
        //Theater th = new Theater("Ice Show", "Haizenberg", "Male", 2011);
        //GetMemory();
        //th.Print();
        //GC.Collect();
        //GC.WaitForPendingFinalizers();
        //GetMemory();
        ////Task2
        //Store stor = new Store("JojoMarket", "Street 37", 0);
        //stor.Print();
        //stor.Dispose();

        ////Task3
        ////Class1
        //void GetMemory()
        //{
        //    long memory = GC.GetTotalMemory(false);
        //    Console.WriteLine($"Используется памяти: {memory / 1024.0 / 1024.0:F2} мб");
        //}
        //Theater th = new Theater("Ice Show", "Haizenberg", "Male", 2011);
        //GetMemory();
        //th.Print();
        //th.Dispose();
        //GetMemory();
        ////Class2
        void Test()
        {
            Store stor = new Store("JojoMarket", "Street 37", 0);
            stor.Print();
            stor.Dispose();
        }
        Test();
        GC.Collect();
        GC.WaitForPendingFinalizers();

    }
}
