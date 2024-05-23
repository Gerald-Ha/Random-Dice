using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Würfel
{
    public partial class MainWindow : Window
    {
        private Random zufall;
        private DispatcherTimer timer;
        private int animationIndex;

        public MainWindow()
        {
            InitializeComponent();
            zufall = new Random();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(60);
            timer.Tick += Timer_Tick;
        }

        private void WuerfelButton_Click(object sender, RoutedEventArgs e)
        {
            ergebnisText.Text = "Würfeln...";
            animationIndex = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the image to show the animation
            int imageIndex = zufall.Next(1, 7);
            wuerfelBild.Source = new BitmapImage(new Uri($"pack://application:,,,/Images/dice{imageIndex}.png"));

            animationIndex++;
            if (animationIndex >= 10)
            {
                timer.Stop();
                int wurf = zufall.Next(1, 7);
                wuerfelBild.Source = new BitmapImage(new Uri($"pack://application:,,,/Images/dice{wurf}.png"));
                ergebnisText.Text = $"Du hast eine {wurf} gewürfelt!";
                ergebnisText.Foreground = System.Windows.Media.Brushes.Red;
                ergebnisText.FontWeight = FontWeights.Bold;
            }
        }
    }
}