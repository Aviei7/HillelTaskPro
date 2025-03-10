using System.Text;
using HillelTaskPro_2.Money;
using HillelTaskPro_2.Instrument;
using HillelTaskPro_2.Struct;
using System;

public class Program
{
    public static void Main()  // точка входа в программу, программа стартует с этой функции (метода)
    {
        Console.OutputEncoding = Encoding.UTF8;
        ////Завдання 1
        //Money mon = new Money(99, 373, "UAN");
        //mon.ShowBalance();
        //Product prod = new Product("Apple", mon);
        //prod.Decrease(10, 837);
        //prod.ShowBalance();
        ////Завдання 2
        //Violin vi = new Violin();
        //vi.Sound(); vi.Show(); vi.Desc(); vi.History();
        //Завдання 3
        Converter conv = new Converter(31);
        Console.WriteLine(conv.Binary());
        Console.WriteLine(conv.Octal());
        Console.WriteLine(conv.Hex());

    }
}