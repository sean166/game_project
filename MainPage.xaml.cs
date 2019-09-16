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
using System.Threading;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Game_Project
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Create characters
        Characters Python = new Characters();
        Characters Java = new Characters();
        Characters Javascript = new Characters();
        Characters CSharp = new Characters();


        //Timer stuff
        DispatcherTimer timer = new DispatcherTimer();
        private int timerValue = 0;
        private int clickCount = 0;
        public string timerText = "";
        public string updateText = "";

        //Display
        private int _BarScaleFactor = 3;
        private int _ATK;
        private int _HP;
        private int _DEF;

        private enum Character
        {
            Python,
            Java,
            Javascript,
            CSharp
        };

        public enum Selecting
        {
            player,
            computer
        };

        private Selecting CharacterSelecting = Selecting.player;
        private Character PlayerCharacter;
        private Character ComputerCharacter;

        public MainPage()
        {
            this.InitializeComponent();
            //Create characters atk, hp ,def all point add up to 200
            Python.UpdateValues(50, 100, 50);
            Java.UpdateValues(80, 40, 80);
            Javascript.UpdateValues(110, 30, 60);
            CSharp.UpdateValues(75, 75, 50);
        }

        private void StartTimer(int _initialTimerValue)
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timerValue = _initialTimerValue;
            //Create new timer with interval 1 second, which uses the Timer_Tick method every tick
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, object e)
        {
            if (timerValue != -1)
            {
                timerValue -= 1;
            }
            else
            {
                timer.Stop();
            }
        }

        private void SwitchToComputer()
        {
            ConfirmMessage.Visibility = Visibility.Collapsed;
            Player1SelectName.Visibility = Visibility.Collapsed;
            ComputerSelectName.Visibility = Visibility.Visible;
        }
        private void SwitchToPlayer()
        {
            ConfirmMessage.Visibility = Visibility.Collapsed;
            Player1SelectName.Visibility = Visibility.Visible;
            ComputerSelectName.Visibility = Visibility.Collapsed;
        }
        private void AssignCharacter()
        {
            if (CharacterSelecting == Selecting.player)
            {
                switch (Selected.Text)
                {
                    case "Python":
                        PlayerCharacter = Character.Python;
                        break;
                    case "Java":
                        PlayerCharacter = Character.Java;
                        break;
                    case "Javascript":
                        PlayerCharacter = Character.Javascript;
                        break;
                    case "C#":
                        PlayerCharacter = Character.CSharp;
                        break;
                }
            }
            else if (CharacterSelecting == Selecting.computer)
            {
                switch (Selected.Text)
                {
                    case "Python":
                        ComputerCharacter = Character.Python;
                        break;
                    case "Java":
                        ComputerCharacter = Character.Java;
                        break;
                    case "Javascript":
                        ComputerCharacter = Character.Javascript;
                        break;
                    case "C#":
                        ComputerCharacter = Character.CSharp;
                        break;
                }
            }
        }
        private void UpdateStatBars()
        {
            switch (Selected.Text)
            {
                case "Python":
                    ComputerCharacter = Character.Python;
                    _ATK = Python.Atk;
                    _HP = Python.Hp;
                    _DEF = Python.Def;
                    break;
                case "Java":
                    ComputerCharacter = Character.Java;
                    _ATK = Java.Atk;
                    _HP = Java.Hp;
                    _DEF = Java.Def;
                    break;
                case "Javascript":
                    ComputerCharacter = Character.Javascript;
                    _ATK = Javascript.Atk;
                    _HP = Javascript.Hp;
                    _DEF = Javascript.Def;
                    break;
                case "C#":
                    ComputerCharacter = Character.CSharp;
                    _ATK = CSharp.Atk;
                    _HP = CSharp.Hp;
                    _DEF = CSharp.Def;
                    break;
            }
            ATK_Bar.Width = _ATK * _BarScaleFactor;
            Hp_Bar.Width = _HP * _BarScaleFactor;
            Def_Bar.Width = _DEF * _BarScaleFactor;

            ATK_Bar.UpdateLayout();
            Hp_Bar.UpdateLayout();
            Def_Bar.UpdateLayout();
        }
        //This is responsible for indicating the selected character, and providing confirmation functionality
        private void CharacterSelect(object sender, RoutedEventArgs e)
        {
            clickCount += 1;
            if (CharacterSelecting == Selecting.player)
            {
                //On character select
                if (clickCount == 0)
                {
                    Selected.Text = ((Button)sender).Tag.ToString();
                    AssignCharacter();
                    UpdateStatBars();
                    ConfirmMessage.Visibility = Visibility.Visible;
                }
                //Selecting first character
                else if (clickCount == 1)
                {
                    //Clicking another character
                    if (Selected.Text != ((Button)sender).Tag.ToString())
                    {
                        ConfirmMessage.Visibility = Visibility.Visible;
                        Selected.Text = ((Button)sender).Tag.ToString();
                        AssignCharacter();
                        UpdateStatBars();
                    }
                    //Character confirmed
                    else if (Selected.Text == ((Button)sender).Tag.ToString())
                    {
                        CharacterSelecting = Selecting.computer;
                        Selected.Text = "";
                        SwitchToComputer();
                    }
                    clickCount = 0;
                }
            }
            else if (CharacterSelecting == Selecting.computer)
            {
                //On character select
                if (clickCount == 0)
                {
                    Selected.Text = ((Button)sender).Tag.ToString();
                    AssignCharacter();
                    UpdateStatBars();
                    ConfirmMessage.Visibility = Visibility.Visible;
                }
                //Selecting first character
                else if (clickCount == 1)
                {
                    //Clicking another character
                    if (Selected.Text != ((Button)sender).Tag.ToString())
                    {
                        ConfirmMessage.Visibility = Visibility.Visible;
                        Selected.Text = ((Button)sender).Tag.ToString();
                        AssignCharacter();
                        UpdateStatBars();
                    }
                    //Character confirmed
                    else if (Selected.Text == ((Button)sender).Tag.ToString())
                    {
                        AssignCharacter();
                        CharacterSelecting = Selecting.computer;
                        Selected.Visibility = Visibility.Collapsed;
                        ComputerSelectName.Visibility = Visibility.Collapsed;
                        ConfirmMessage.Visibility = Visibility.Collapsed;
                        SelectedTxt.Visibility = Visibility.Collapsed;
                        VersusMessage.Text = $"{PlayerCharacter} vs. {ComputerCharacter}";
                    }
                    clickCount = 0;
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(FightPage));
        }
    }
}