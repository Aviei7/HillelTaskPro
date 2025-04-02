using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelTaskPro_6.Class
{
    class Store : IDisposable
    {
        string name;
        string address;
        string typeStore;

        public Store(string Tname, string Taddress, int TtypeStore)
        {
            name = Tname; address = Taddress;

            if (TtypeStore == 0) { typeStore = "продовольчий"; }
            else if (TtypeStore == 1) { typeStore = "господарський"; }
            else if (TtypeStore == 2) { typeStore = "одяг"; }
            else if (TtypeStore == 3) { typeStore = "взуття"; };
        }

        public void Dispose()
        {
            Console.WriteLine("Memory clear");
        }

        public void Print()
        {
            Console.WriteLine($"Name - {name}\naddress - {address}\ntypeStore - {typeStore}");
        }

        //Task3
        ~Store()
        {
            GC.SuppressFinalize(this);
            Console.WriteLine("Memory clear(Distructor)");
        }

    }
}
