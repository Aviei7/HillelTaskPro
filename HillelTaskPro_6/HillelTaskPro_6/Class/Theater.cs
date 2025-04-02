using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HillelTaskPro_6.Class
{
    class Theater :IDisposable
    {
        string name;
        string fullNameAutor;
        string ganre;
        int year;
        IntPtr Prints;

        public Theater(string Tname, string TfullNameAutor, string Tganre, int Tyear)
        {
            name = Tname;
            fullNameAutor = TfullNameAutor;
            ganre = Tganre;
            year = Tyear;
        }

        public void Print()
        {
            string str = $"Name - {name}\nfullNameAutor - {fullNameAutor}\nganre - {ganre}\nyear - {year}";
            Prints = Marshal.StringToHGlobalAnsi(str);
        }

        ~Theater()
        {
            Marshal.FreeHGlobal(Prints);
        }

        //Task3
        public void Dispose()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
