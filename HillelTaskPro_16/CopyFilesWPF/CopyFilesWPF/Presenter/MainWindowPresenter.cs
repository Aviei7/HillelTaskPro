using CopyFilesWPF.Model;
using CopyFilesWPF.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CopyFilesWPF.Presenter
{

    public class MainWindowPresenter : IMainWindowPresenter
    {
        private readonly IMainWindowView _mainWindowView;
        private readonly MainWindowModel _mainWindowModel;
        private CancellationTokenSource? _Cancel;

        public MainWindowPresenter(IMainWindowView mainWindowView)
        {
            _mainWindowView = mainWindowView;
            _mainWindowModel = new MainWindowModel();
        }

        public void ChooseFileFromButtonClick(string path)
        {
            _mainWindowModel.FilePath.PathFrom = path;
        }

        public void ChooseFileToButtonClick(string path)
        {
            _mainWindowModel.FilePath.PathTo = path;
        }


        // порефакторить этот метод, убрать хардкод, разделить на более мелкие методы
        public void CopyButtonClick()
        {
            int ColumnCount = 3;
            double WidthLength = 320;
            int RowCount = 2;
            double HeightLength = 20;

            //CancelToken
            if (_Cancel != null)
            {
                _Cancel.Cancel();
                _Cancel.Dispose();
            }

            _Cancel = new CancellationTokenSource();
            var CancelToken = _Cancel.Token;

            _mainWindowModel.FilePath.PathFrom = _mainWindowView.MainWindowView.FromTextBox.Text;
            _mainWindowModel.FilePath.PathTo = _mainWindowView.MainWindowView.ToTextBox.Text;
            _mainWindowView.MainWindowView.FromTextBox.Text = "";
            _mainWindowView.MainWindowView.ToTextBox.Text = "";
            _mainWindowView.MainWindowView.Height = _mainWindowView.MainWindowView.Height + 60;
            var newPanel = new Grid();
            //Создания разметки для Grid
            CreateGridLayaout(newPanel, ColumnCount, RowCount, WidthLength, HeightLength);
            var nameFile = new TextBlock
            {
                Text = Path.GetFileName(_mainWindowModel.FilePath.PathFrom),
                Margin = new Thickness(5, 0, 5, 0)
            };
            //Перемещение nameFile на позицию
            PlacementToGrid(newPanel, nameFile, "nameFile");

            var progressBar = new ProgressBar
            {
                Margin = new Thickness(10, 10, 10, 10)
            };
            //Перемещение progressBar на позицию
            PlacementToGrid(newPanel, progressBar, "progressBar");

            var pauseB = new Button
            {
                Content = "Pause",
                Margin = new Thickness(5)
            };
            pauseB.Click += PauseCancelClick;
            //Перемещение pauseB на позицию
            PlacementToGrid(newPanel, pauseB, "pauseB");

            var cancelB = new Button
            {
                Content = "Cancel",
                Margin = new Thickness(5)
            };
            cancelB.Click += PauseCancelClick;
            //Перемещение cancelB на позицию
            PlacementToGrid(newPanel, cancelB, "cancelB");

            DockPanel.SetDock(newPanel, Dock.Top);
            newPanel.Height = 60;
            _mainWindowView.MainWindowView.MainPanel.Children.Add(newPanel);

            var copier = new FileCopier(_mainWindowModel.FilePath, ProgressChanged, ModelOnComplete, newPanel, _Cancel);
            var context = new FileCopyPanelContext
            {
                Panel = newPanel,
                Copier = copier,
                ProgressBar = progressBar,
                PauseResumeButton = pauseB,
                CancelButton = cancelB
            };

            newPanel.Tag = context;
            newPanel.Tag = context;
            pauseB.Tag = context;
            cancelB.Tag = context;
            _mainWindowModel.CopyFile(ProgressChanged, ModelOnComplete, newPanel, copier);
        }

        private enum ButtonAction { Cancel, Pause, Resume }

        //Метод создания разметки для Grid
        private void CreateGridLayaout(Grid newPanel, int ColumnCount, int RowCount, double WidthLength, double HeightLength)
        {
            newPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(WidthLength) });
            newPanel.RowDefinitions.Add(new RowDefinition { Height = new GridLength(HeightLength) });
            for (int i = 0; i < ColumnCount-1; i++)
            {
                newPanel.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            for (int i = 0; i < RowCount-1; i++)
            {
                newPanel.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            }
        }

        private void PlacementToGrid(Grid newPanel, UIElement Obj, string ObjName)
        {
            foreach (var dictionary in GridPlacement.Positions)
            {
                if (dictionary.Key.Equals(ObjName))
                {
                    Grid.SetRow(Obj, dictionary.Value.row);
                    Grid.SetColumn(Obj, dictionary.Value.column);
                }
            }
            newPanel.Children.Add(Obj);
        }


        // порефакторить этот метод, убрать хардкод, и переделать его по SOLID (тут несколько ответсвенностей)
        //+
        private void PauseCancelClick(object sender, RoutedEventArgs routedEventArgs)
        {
            if (sender is not Button btn)
                return;

            var InfoButton = (FileCopyPanelContext)btn.Tag;

            btn.IsEnabled = false;
            if (btn == InfoButton.CancelButton)
            {
                _Cancel.Cancel();
            }
            else if (btn == InfoButton.PauseResumeButton)
            {
                InfoButton.Copier.PauseFlag.Reset();
            }
            else
            {
                InfoButton.Copier.PauseFlag.Set();
            }
        }

        private void ModelOnComplete(Grid panel)
        {
            _mainWindowView.MainWindowView.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate ()
                {
                    _mainWindowView.MainWindowView.Height = _mainWindowView.MainWindowView.Height - 60;
                    _mainWindowView.MainWindowView.MainPanel.Children.Remove(panel);
                    _mainWindowView.MainWindowView.CopyButton.IsEnabled = true;
                }
            );
        }

        // порефакторить этот метод, убрать хардкод, и переделать его по SOLID (тут несколько ответсвенностей)
        //+
        private void ProgressChanged(double persentage, Grid panel)
        {

            _mainWindowView.MainWindowView.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                (ThreadStart)delegate ()
                {
                    var context = (FileCopyPanelContext)panel.Tag;

                    context.ProgressBar.Value = persentage;

                    if (context.PauseResumeButton.Content.Equals("Resume") && context.PauseResumeButton.IsEnabled == false)
                    {
                        context.PauseResumeButton.Content = "Pause";
                        context.PauseResumeButton.IsEnabled = true;
                    }
                    else if (context.PauseResumeButton.Content.Equals("Pause") && context.PauseResumeButton.IsEnabled == false)
                    {
                        context.PauseResumeButton.Content = "Resume";
                        context.PauseResumeButton.IsEnabled = true;
                    }
                }
            );
        }
    }
}
