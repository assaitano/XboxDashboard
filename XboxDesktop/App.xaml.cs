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
using System.Xml.Linq;


namespace XboxDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void btnAnimationEnd(object sender, EventArgs e)
        {         
            ((MainWindow)System.Windows.Application.Current.MainWindow).btn_PressEnd();
        }

        public static bool PlayAnimation = false;

        public void AnimationEnd(object sender, EventArgs e)
        {
            PlayAnimation = false;
        }

        public static Thickness Scroll_toPosition = new Thickness(0, 0, 0, 0); 

    }
}
