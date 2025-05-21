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
            StartingorShutdownMediaPlayerOSLabel.Content = "Starting MediaPlayer OS";
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
        
    }
}