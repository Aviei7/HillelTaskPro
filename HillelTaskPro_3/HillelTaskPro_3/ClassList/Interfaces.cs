using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelTaskPro_3.ClassList
{
    interface IOutput
    {
        void Show();

        void Show(string info);
    }

    interface IMath
    {
        int Max();

        int Min();

        float Avg();

        bool Search(int valueToSearch);
    }

    interface ISort
    {
        void SortAsc();

        void SortDesc();

        void SortByParam(bool isAsc);
    }
}
