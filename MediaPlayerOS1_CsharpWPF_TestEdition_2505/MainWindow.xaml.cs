using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MediaPlayerOS1_CsharpWPF_TestEdition_2505
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int StartStopProgressValue;
        public MainWindow()
        {
            InitializeComponent();
            StartingMediaPlayerOS();
        }

        private async void StartingMediaPlayerOS()
        {
            StartingorShutdownMediaPlayerOSGrid.Visibility = Visibility.Visible;
            StartingorShutdownMediaPlayerOSLabel.Content = "Starting MediaPlayer OS...";
            StartStopProgressValue = 0;
            await Task.Delay(1000);

            for (int i = 0; i < 20; i++)
            {
                StartStopProgressValue += 5;
                StartStopProgress.Value = StartStopProgressValue;

                await Task.Delay(100); // 0.3秒ずつ待つ → 合計3秒のアニメーション
            }
            StartingorShutdownMediaPlayerOSGrid.Visibility = Visibility.Collapsed;
            Desktop.Visibility = Visibility.Visible;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (StartMenu.Visibility == Visibility.Visible)
            {
                StartMenu.Visibility = Visibility.Collapsed;
            }
            else
            {
                StartMenu.Visibility = Visibility.Visible;
            }
        }

        private void ShutdownButton_Click(object sender, RoutedEventArgs e)
        {
            ShutdownMediaPlayerOS("0");
        }

        private void dengenbutton_Click(object sender, RoutedEventArgs e)
        {
            if (dengen.Visibility == Visibility.Visible)
            {
                dengen.Visibility = Visibility.Collapsed;
            }
            else
            {
                dengen.Visibility = Visibility.Visible;
            }
        }
        private async void ShutdownMediaPlayerOS(string Exitcode)
        {
            StartingorShutdownMediaPlayerOSLabel.Content = "Shutdown MediaPlayer OS...";
            Desktop.Visibility = Visibility.Collapsed;
            StartingorShutdownMediaPlayerOSGrid.Visibility = Visibility.Visible;
            StartStopProgressValue = 0;
            StartStopProgress.Value = 0;

            for (int i = 0; i < 20; i++)
            {
                StartStopProgressValue += 5;
                StartStopProgress.Value = StartStopProgressValue;
                await Task.Delay(100);
            }

            // 画面全体をフェードアウト
            var fadeOut = new System.Windows.Media.Animation.DoubleAnimation(1, 0, new Duration(TimeSpan.FromMilliseconds(500)));
            this.BeginAnimation(Window.OpacityProperty, fadeOut);

            await Task.Delay(700); // フェードアウト完了まで待機

            if (Exitcode == "1")
            {
                Process.Start(@"MediaPlayerOS Csharp_WPF Test Edition.exe");
                Application.Current.Shutdown();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
    }
}