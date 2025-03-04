
using System;
namespace MyCalculator;
public class Calculator
{
    private List<char> operations;
    private List<string> operands;
    private char[] signs;

    public Calculator()
    {
        this.operations = new List<char>(); ;
        this.operands = new List<string>(); ;
        this.signs = ['*', '/', '+', '-'];
    }

    void Separate(string inputValue)
    {
        int lastAdd = 0;
        int? skipStep = null;

        var operationSet = new HashSet<char>(signs);

        //Разделение знаков и операндов
        for (int i = 0; i < inputValue.Length; i++)
        {

            if (operationSet.Contains(inputValue[i]))
            {
                operations.Add(inputValue[i]);
                skipStep = i;
            }
            else if (i != 0 && (skipStep == null || skipStep + 1 != i))
            {
                operands[lastAdd] += inputValue[i];
            }
            else
            {
                operands.Add(inputValue[i].ToString());
                lastAdd = operands.Count - 1;
            }
        }

        //Сортировка знаков
        //operations.Sort((a, b) => Array.IndexOf(signs, a) - Array.IndexOf(signs, b));

        //Отладка
        //for (int i = 0; i < operands.Count; i++)
        //{
        //    Console.WriteLine($"операнды {i} - {operands[i].ToString()}");
        //}

        //for (int i = 0; i < operations.Count; i++)
        //{
        //    Console.WriteLine($"операция {i} - {operations[i].ToString()} ");
        //}
    }

    public double Calculate(string inputValue)
    {
        Separate(inputValue);

        // Обработка * и /
        for (int i = 0; i < operations.Count; i++)
        {
            if (operations[i] == '*' || operations[i] == '/')
            {
                double leftValue = double.Parse(operands[i]);
                double rightValue = double.Parse(operands[i + 1]);

                double result = (operations[i] == '*') ? leftValue * rightValue : leftValue / rightValue;

                //Console.WriteLine($"Operation - {operations[i]}. left - {leftValue}, right - {rightValue}. reuslt - {result}. i = {i}");

                operands[i] = result.ToString();  
                operands.RemoveAt(i + 1);         
                operations.RemoveAt(i);           
                i--; 
            }
        }

        // Обработка + и -
        for (int i = 0; i < operations.Count; i++)
        {
            double leftValue = double.Parse(operands[i]);
            double rightValue = double.Parse(operands[i + 1]);

            double result = (operations[i] == '+') ? leftValue + rightValue : leftValue - rightValue;

            //Console.WriteLine($"Operation - {operations[i]}. left - {leftValue}, right - {rightValue}. reuslt - {result}. i = {i}");

            operands[i] = result.ToString(); 
            operands.RemoveAt(i + 1);        
            operations.RemoveAt(i);           
            i--; 
        }

        return double.Parse(operands[0]); 
    }

}