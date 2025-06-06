﻿using System.Threading;
using System.Windows.Controls;
using static CopyFilesWPF.Model.FileCopier;

namespace CopyFilesWPF.Model
{
    public class MainWindowModel
    {
        public FilePath FilePath { get; set; }

        public MainWindowModel() {
            FilePath = new FilePath();
        }

        public void CopyFile(ProgressChangeDelegate onProgressChanged, CompleteDelegate onComplete, Grid gridPanel, FileCopier copier)
        {
            var newCopierThread = new Thread(new ThreadStart(copier.CopyFile))
            {
                IsBackground = true
            };
            newCopierThread.Start();
        }
    }
}
