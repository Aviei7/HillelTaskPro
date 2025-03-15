using System;
using System.Collections.Generic;
using HillelTaskPro_3.ClassList;
class Program
{
    static void Main()
    {
        ////task1
        //MyArray arr = new MyArray(5);
        //arr.Show();
        //arr.Show("hi");
        ////task2
        //MyArray operArr = new MyArray(5);
        //Console.WriteLine(operArr.Min());
        //Console.WriteLine(operArr.Max());
        //Console.WriteLine(operArr.Avg());
        ////Search
        //Console.WriteLine(operArr.Search(3));
        //Console.WriteLine(operArr.Search(100));
        //task3
        MyArray operArr = new MyArray(5);
        //asc
        operArr.Show();
        operArr.SortAsc();
        operArr.Show();
        //desc
        operArr.SortDesc();
        operArr.Show();
        //byParam
        operArr.SortByParam(true);
        operArr.Show();
        operArr.SortByParam(false);
        operArr.Show();


    }
}
