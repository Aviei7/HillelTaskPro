using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelTaskPro_4.Class
{
    abstract class Main
    {
        public double OperationValue { get; set; }

        //Msg
        private void ShowValue()
        {
            Console.WriteLine($"BaseValue - {OperationValue}");
        }

        //+
        public void Operation(double add)
        {
            OperationValue += add;
            ShowValue();
        }

        //-
        public void Operation(double Subtract, bool IsSub )
        {
            if (IsSub)
            {
                OperationValue -= Subtract;
                ShowValue();
            }
        }

        //Equal
        public void Operation<T>(T objvalue, bool IsEqual) where T : IOperation
        {
            if (IsEqual)
            {
                if (OperationValue == objvalue.OperationValue)
                {
                    Console.WriteLine("Equals");
                }
                else
                {
                    Console.WriteLine("NoEquals");
                }
            }
        }

        //MoreOrLess
        public void Operation<T>(T objvalue) where T : IOperation
        {
            string name = objvalue.GetType().Name;
            if (OperationValue > objvalue.OperationValue)
            {
                Console.WriteLine($"Current {name}_Value > input {name}_Value");
            }
            else if (OperationValue < objvalue.OperationValue)
            {
                Console.WriteLine($"Current {name}_Value < input {name}_Value");
            }
            else
            {
                Console.WriteLine($"Equals");
            }
        }
    }
}
