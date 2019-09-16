using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Game_Project;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Game_Project
{
    public sealed partial class FightImage : UserControl
    {
        public FightImage()
        {
            this.InitializeComponent();
        }
        public void Hide()
        {
            Move1.Visibility = Visibility.Collapsed;
        }
        public void Show(int moveID)
        {
            Hide();
            switch(moveID)
            {
                case 1:
                    Move1.Visibility = Visibility.Visible;
                    break;
                        

                    
            }
        }
    }
}
