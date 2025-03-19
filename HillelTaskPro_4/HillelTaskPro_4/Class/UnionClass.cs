using HillelTaskPro_4.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelTaskPro_4.Class
{
    class Employee :Main, IOperation
    {
        public Employee(double value)
        {
            OperationValue += value;
        }
    }

    class City : Main, IOperation
    {
        public City(double value)
        {
            OperationValue += value;
        }
    }

    class CreditCart : Main, ICvcCode, IOperation
    {
        public int CvcCode { get; }

        
        public CreditCart(double value)
        {
            OperationValue += value;
            Random random = new Random();
            CvcCode = random.Next(100,999);
        }

        public void Operation(bool isEqualsCvc, double cvcCode)
        {
            if (isEqualsCvc)
            {
                if (CvcCode == cvcCode)
                {
                    Console.WriteLine("Equals");
                }
                else
                {
                    Console.WriteLine("NoEquals");
                }
            }
        }
    }

    class Matrix : IMatrixInterface
    {
        public int[,] matrix { get; }

        ////TEST_NoEquals
        //public Matrix(int top, int right)
        //{
        //    matrix = new int[top, right];
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            Random random = new Random();
        //            matrix[i,j] = random.Next(0, 100);
        //        }
        //    }
        //}

        //TEST_Equals
        public Matrix(int top, int right)
        {
            matrix = new int[top, right];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = j;
                }

            }
        }

        //Show
        public void ShowMatrix(string nameOper)
        {
            Console.WriteLine($"{nameOper}");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        //+
        public void MatrixOperation<T>(T objvalue) where T : class, IMatrixInterface
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] += objvalue.matrix[i,j];
                }
            }
            Console.WriteLine();
            ShowMatrix("Add");
        }

        //-
        public void MatrixOperation<T>(T objvalue, bool isDiv) where T : class, IMatrixInterface
        {
            if (isDiv)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] -= objvalue.matrix[i, j];
                    }
                }
                Console.WriteLine();
                ShowMatrix("Min");
            }
        }

        //*
        public void MatrixOperation<T>(bool isMulty, T objvalue) where T : class, IMatrixInterface
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= objvalue.matrix[i, j];
                }
            }
            Console.WriteLine();
            ShowMatrix("MultMatrix");
        }

        public void MatrixOperation<T>(int value) 
        {
            for (int i = 0; i<matrix.GetLength(0); i++)
            {
                for (int j = 0; j<matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= value;
                }
            }
            Console.WriteLine();
            ShowMatrix("MultValue");
        }

        public void MatrixOperation<T>(T objvalue, bool Equals, bool test) where T : class, IMatrixInterface
        {
            if (Equals)
            {
                bool isEquals = true;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] != objvalue.matrix[i, j])
                        {
                            isEquals = false;
                            break;
                        }
                    }
                }
                if (isEquals)
                {
                    Console.WriteLine();
                    Console.WriteLine("Equals");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("NoEquals");
                }
            }
        }
    }
}
