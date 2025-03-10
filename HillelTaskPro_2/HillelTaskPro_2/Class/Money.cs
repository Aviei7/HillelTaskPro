using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelTaskPro_2.Money
{
    internal class Money
    {
        private int Value;
        private int SmallValue;
        private string Currency;
        public Money(int Value, int SmallValue, string Currency)
        {
            int tmpValue;
            tmpValue = SmallValue / 100;
            this.Value = Value + tmpValue;
            this.SmallValue = SmallValue % 100;
            this.Currency = Currency;
        }

        public void Decrease(int DecValue, int DecSmallValue)
        {
            int DivValue = DecSmallValue / 100;
            this.Value -= DecValue;
            if (this.SmallValue - DecSmallValue < 0)
            {
                this.Value -= DivValue;
                this.SmallValue += (DivValue) * 100;
            }
            this.SmallValue -= DecSmallValue;
            if (this.SmallValue < 0)
            {
                this.Value -= 1;
                this.SmallValue += 100;
            }
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Баланс {Value}.{SmallValue} {Currency}");
        }
    }

    class Product
    {
        private string Name;
        Money price;

        public Product(string name, Money price)
        {
            this.Name = name;
            this.price = price;
        }

        public void Decrease(int DecValue, int DecSmallValue)
        {
            price.Decrease(DecValue, DecSmallValue);
        }

        public void ShowBalance()
        {
            price.ShowBalance();
        }
    }
}
