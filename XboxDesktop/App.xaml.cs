using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace XboxDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void btnAnimationEnd(object sender, EventArgs e)
        {         
            ((MainWindow)System.Windows.Application.Current.MainWindow).btnPressEnd();
        }
    }
}
