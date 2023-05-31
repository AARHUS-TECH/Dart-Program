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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int NoOfPlayers = 0;
        public static int RoundNo = 0;
        public static string Filelocation = "./Files";
        public static List<string> Players = new List<string>();
         
        public void RefreshPlayers()
        {
            CurrentPlayerList.Text = null;
            foreach (var player in Players)
            {
                CurrentPlayerList.Text += $"{player}\n";
            }
        }
        public void InitEnv()
        {
            if (! File.Exists($"{Filelocation}/players.txt"))
            {
            Directory.CreateDirectory(Filelocation);
            File.Create($"{Filelocation}/players.txt");
            }
            Players.Clear();
            foreach (string line in File.ReadLines($"{Filelocation}/players.txt"))
            {
                Players.Add(line);
            }
            NoOfPlayers = Players.Count;
        }
            public MainWindow()
        {
            InitializeComponent();
            InitEnv();
            RefreshPlayers();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var listwindows = new PlayerListPage();
            Close();
            listwindows.Show();
        }
    }
}
