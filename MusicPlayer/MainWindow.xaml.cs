using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.Windows.Threading;


namespace MusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

        }


         private void Timer_Tick(Object sender, EventArgs e)
        {
            if (mediaPlayer.Source != null)
                try
                {
                    //AUDIO LIGADO PELO AMOR DE DEUS :>
                    lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tente Ligar o Audio se estiver desabilitado.");
                }
            else
                lblStatus.Content = "No file selected...";
        }

        private void Tocar_Click(object sender, RoutedEventArgs e)
        { 
            mediaPlayer.Play(); 
        }

        private void Pausar_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void Parar_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            //if (openFileDialog.ShowDialog() == true)
            //    mediaPlayer.Open(new Uri(openFileDialog.FileName));

            mediaPlayer.Open(new Uri(System.Environment.CurrentDirectory + "/resources/Arctic Monkeys - Do I Wanna Know_ (Official Video)(MP3_320K).mp3", UriKind.Relative));

            
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Mudar_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                mediaPlayer.Open(new Uri(openFileDialog.FileName));

            
            
            timer.Start();


        }
            
        }
    }

