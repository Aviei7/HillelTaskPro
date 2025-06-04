using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CopyFilesWPF.View
{

    public class GridPlacement
    {
        public static readonly Dictionary<string, (int row, int column)> Positions = new()
        {
            { "nameFile", (0, 0) },
            { "progressBar", (1, 0) },
            { "pauseB", (1, 1) },
            { "cancelB", (1, 2) }
        };
    }
}
