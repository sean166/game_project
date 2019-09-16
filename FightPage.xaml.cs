using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Game_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FightPage : Page
    {
        public FightPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
        public async void ReadLines()
        {
            StorageFolder installFolder =
                Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile myTextFile = await installFolder.GetFileAsync("SelectedCharacters.txt");
            var lines = File.ReadLines(myTextFile.Path);
            foreach (string line in lines)
            {
                MainListView.Items.Add(line);

            }
            Debug.WriteLine(myTextFile.Path);
        }
    }
}
