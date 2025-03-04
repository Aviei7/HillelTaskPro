
using System;
namespace MyCalculator
{
    class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();
            double result = calculator.Calculate("1+2*3+21/2*31");
            Console.WriteLine(result);
        }
    }
}