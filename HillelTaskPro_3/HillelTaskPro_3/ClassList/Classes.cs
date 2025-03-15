using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelTaskPro_3.ClassList
{
    class MyArray : IOutput, IMath, ISort
    {
        private int[] numList;
        public MyArray(int value) 
        {
            numList = new int[value];
            Random randomNum = new Random();
            for (int i = 0; i < numList.Length; i++)
            {
                numList[i] = randomNum.Next(-100, 100);
            }
        }

        //IOutput
        public void Show()
        {
            Console.WriteLine(string.Join(", ", numList));
        }

        public void Show(string info)
        {
            Show();
            Console.WriteLine(info);
        }

        //IMath
        public int Max()
        {
            int resultMax = 0;
            foreach (int i in numList)
            {
                if (i > resultMax)
                {
                    resultMax = i;
                }
            }
            return resultMax;
        }

        public int Min()
        {
            int resultMin = Max();
            foreach (int i in numList)
            {
                if (i < resultMin)
                {
                    resultMin = i;
                }
            }
            return resultMin;
        }

        public float Avg()
        {
            int resultAvg = 0;
            foreach (int i in numList)
            {
                resultAvg += i;
            }
            resultAvg /= numList.Length;

            return resultAvg;
        }

        public bool Search(int valueToSearch)
        {
            bool searchResult = false;
            foreach (int i in numList)
            {
                if (valueToSearch == i)
                {
                    searchResult = true;
                }
            }
            return searchResult;
        }

        //ISort
        private void Sort(Func<int, int, bool> sign)
        {
            int tmpArrNum = 0;
            for (int i = 0; i < numList.Length; i++)
            {
                for (int j = 0; j < numList.Length; j++)
                {

                    if (j + 1 < numList.Length && sign(numList[j], numList[j + 1]))
                    {
                        tmpArrNum = numList[j];
                        numList[j] = numList[j + 1];
                        numList[j + 1] = tmpArrNum;
                    }
                }
            }
        }

        public void SortAsc()
        {
            Sort((x, y) => x > y);
        }

        public void SortDesc()
        {
            Sort((x, y) => x < y);
        }

        public void SortByParam(bool isAsc)
        {
            switch(isAsc)
            {
                case true:
                    Sort((x, y) => x > y);
                    break;
                case false:
                    Sort((x, y) => x < y);
                    break;
            }
        }
    }
}
