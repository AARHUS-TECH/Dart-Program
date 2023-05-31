using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dart
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class PlayerListPage : Window
    {
        public void RefreshPlayers()
        {
            PlayerList.Items.Clear();
            foreach (var player in MainWindow.Players)
            {
                PlayerList.Items.Add(player);
            }
        }
        public void RefreshPlayerstxt()
        {
            File.WriteAllText($"{MainWindow.Filelocation}/players.txt", "");
            File.WriteAllLines($"{MainWindow.Filelocation}/players.txt", MainWindow.Players);
            MainWindow.NoOfPlayers = MainWindow.Players.Count;
        }
        public PlayerListPage()
        {
            InitializeComponent();
            RefreshPlayers();

            
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string UserAnswer = Microsoft.VisualBasic.Interaction.InputBox("Please write the name below: ", "Name", "");
            if (UserAnswer != "")
            {
                MainWindow.Players.Add(UserAnswer);
                RefreshPlayerstxt();
                RefreshPlayers();
            }
          
            


        }

        private void PlayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PlayerList.SelectedItem != null)
            {
                string item = PlayerList.SelectedItem.ToString();
                if (MessageBox.Show($"Delete {item} from player list?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    MainWindow.Players.Remove(item);
                    RefreshPlayerstxt();
                    RefreshPlayers();
                       
                }
            }
            

      


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var Mainwin = new MainWindow();
            Mainwin.Show();
        }
    }
}
