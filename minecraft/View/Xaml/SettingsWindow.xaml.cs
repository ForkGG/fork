﻿
using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using nihilus.Logic.Manager;
using nihilus.Logic.Model;
using nihilus.ViewModel;

namespace nihilus.View.Xaml
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private ServerViewModel viewModel;
        
        public SettingsWindow(ServerViewModel viewModel)
        {
            this.viewModel = viewModel;
            viewModel.Server.CreateBackup();
            DataContext = this.viewModel;
            InitializeComponent();
        }

        private void Btn_Apply(object sender, RoutedEventArgs e)
        {
            Close();
            
            //Write changes to File
            viewModel.UpdateSettings();
        }

        private void Btn_Cancel(object sender, RoutedEventArgs e)
        {
            Close();
            
            //Undo changes
            viewModel.Server.ApplyBackup();
        }

        private async void Btn_Delete(object sender, RoutedEventArgs e)
        {
            Close();
            bool success = await ServerManager.Instance.DeleteServerAsync(viewModel);
            if(!success)
                Console.WriteLine("Problem while deleting "+viewModel.Server.Name);
            else
            {
                ApplicationManager.Instance.MainViewModel.Servers.Remove(viewModel); //This shouldn't be here
            }
        }

        private async void Btn_ChangeVersion(object sender, RoutedEventArgs e)
        {
            Overlay.Visibility = Visibility.Visible;
            bool success = await ServerManager.Instance.ChangeServerVersionAsync((ServerVersion) VersionSelector.SelectedValue, viewModel);
            if (!success)
            {
                //TODO: Display error
                return;
            }
            
            Close();          
        }

        private async void Btn_RegenerateEnd(object sender, RoutedEventArgs e)
        {
            bool success = await ServerManager.Instance.DeleteDimensionAsync("DIM1", viewModel.Server);
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0.0;
            doubleAnimation.To = 0.4;
            doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            doubleAnimation.AutoReverse = true;
            Rectangle target;
            if (success)
            {
                target = RegEndSucc;
            }
            else
            {
                target = RegEndFail;
            }
            Storyboard.SetTarget(doubleAnimation, target);
            Storyboard.SetTargetProperty(doubleAnimation,new PropertyPath(OpacityProperty));
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }

        private async void Btn_RegenerateNether(object sender, RoutedEventArgs e)
        {
            bool success = await ServerManager.Instance.DeleteDimensionAsync("DIM-1", viewModel.Server);
            DoubleAnimation doubleAnimation = new DoubleAnimation();
            doubleAnimation.From = 0.0;
            doubleAnimation.To = 0.4;
            doubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(500));
            doubleAnimation.AutoReverse = true;
            Rectangle target;
            if (success)
            {
                target = RegNetherSucc;
            }
            else
            {
                target = RegNetherFail;
            }
            Storyboard.SetTarget(doubleAnimation, target);
            Storyboard.SetTargetProperty(doubleAnimation,new PropertyPath(OpacityProperty));
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(doubleAnimation);
            storyboard.Begin();
        }
    }
}
