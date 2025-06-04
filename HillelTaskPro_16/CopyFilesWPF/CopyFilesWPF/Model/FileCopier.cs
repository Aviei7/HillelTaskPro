using System;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace CopyFilesWPF.Model
{
    public class FileCopier
    {
        private readonly Grid _gridPanel;
        private readonly FilePath _filePath;

        public delegate void ProgressChangeDelegate(double progress, Grid gridPanel);
        public delegate void CompleteDelegate(Grid gridPanel);
        public event ProgressChangeDelegate OnProgressChanged;
        public event CompleteDelegate OnComplete;

        private CancellationTokenSource CancelT;
        public ManualResetEvent PauseFlag = new(true);

        public FileCopier(
            FilePath filePath,
            ProgressChangeDelegate onProgressChange,
            CompleteDelegate onComplete,
            Grid gridPanel,
            CancellationTokenSource cancelT)
        {
            OnProgressChanged += onProgressChange;
            OnComplete += onComplete;
            _filePath = filePath;
            _gridPanel = gridPanel;
            CancelT = cancelT;
        }

        public void CopyFile()
        {
            byte[] buffer = new byte[1024 * 1024];

            CancellationToken _CancelT = CancelT.Token;

            while (!_CancelT.IsCancellationRequested)
            {
                try
                {
                    using(var source = new FileStream(_filePath.PathFrom, FileMode.Open, FileAccess.Read))
                    {
                        var fileLength = source.Length;
                        using var destination = new FileStream(_filePath.PathTo, FileMode.CreateNew, FileAccess.Write);
                        long totalBytes = 0;
                        int currentBlockSize = 0;
                        while ((currentBlockSize = source.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            totalBytes += currentBlockSize;
                            double persentage = totalBytes * 100.0 / fileLength;
                            destination.Write(buffer, 0, currentBlockSize);
                            OnProgressChanged(persentage, _gridPanel);

                            if(_CancelT.IsCancellationRequested)
                            {
                                File.Delete(_filePath.PathTo);
                                break;
                            }

                            PauseFlag.WaitOne(Timeout.Infinite); // переделать на thread suspend
                        }
                        CancelT.Cancel();
                    }
                }
                catch (IOException error)
                {
                    // порефакторить код ниже
                    if (!_CancelT.IsCancellationRequested)
                    {
                        var result = MessageBox.Show(error.Message + " Replace?", "Replace?", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            File.Delete(_filePath.PathTo);
                            continue;
                        }
                        else
                        {
                            var result2 = MessageBox.Show(error.Message + " Copying was canceled!", "Cancel", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            CancelT.Cancel();
                            File.Delete(_filePath.PathTo);
                        }
                    }
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Error occured!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            OnComplete(_gridPanel);
        }
    }
}
