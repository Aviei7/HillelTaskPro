using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CopyFilesWPF.Model
{
    class FileCopyPanelContext
    {
        public Grid Panel { get; set; }
        public FileCopier Copier { get; set; }
        public ProgressBar ProgressBar { get; set; }
        public Button PauseResumeButton { get; set; }
        public Button CancelButton { get; set; }
    }
}
