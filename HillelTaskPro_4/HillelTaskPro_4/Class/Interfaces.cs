using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HillelTaskPro_4.Class
{
    interface IOperation
    {
        double OperationValue { get; }
    }

    interface IMatrixInterface
    {
        int[,] matrix { get;  }
    }

    interface ICvcCode
    {
        int CvcCode { get;}

        void Operation(bool isEqualsCvc, double cvcCode);

    }
}
