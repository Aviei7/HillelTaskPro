using System;
using System.Collections.Generic;
using HillelTaskPro_4.Class;

class Program
{
    static void Main()
    {
        ////Task1
        //Employee testemp = new Employee(200);
        //Employee emp = new Employee(200);
        ////+
        //emp.Operation(213);
        ////-
        //emp.Operation(213, true);
        ////Equals
        //emp.Operation(testemp, true);
        ////<>
        //emp.Operation(testemp);
        ////Task2
        //City testemp = new City(210);
        //City emp = new City(200);
        ////+
        //emp.Operation(213);
        ////-
        //emp.Operation(213, true);
        ////Equals
        //emp.Operation(testemp, true);
        ////<>
        //emp.Operation(testemp);
        //Task3
        //CreditCart testemp = new CreditCart(210);
        //CreditCart emp = new CreditCart(200);
        ////+
        //emp.Operation(213);
        ////-
        //emp.Operation(213, true);
        ////EqualsCVC
        //emp.Operation(true, 223);
        ////<>
        //emp.Operation(testemp);
        //task4
        Matrix mtx = new Matrix(9, 9);
        Matrix testmtx = new Matrix(9, 9);
        //main1
        mtx.ShowMatrix("Other1");
        Console.WriteLine("-----------------------------------------------------------------------");
        //test2
        testmtx.ShowMatrix("Other2");
        //mtx.MatrixOperation(testmtx);
        //mtx.MatrixOperation(testmtx, true);
        //mtx.MatrixOperation<int>(3);
        mtx.MatrixOperation(testmtx, true, false);





    }
}
