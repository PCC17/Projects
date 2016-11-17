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
using ServerArduinoCommunication;

namespace ServerApplication
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private float blueFactor = 0.4f;
        private float greenFactor = 0.7f;

        private Server server;
        private ArduinoCommunication arduino;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            arduino = new ArduinoCommunication(txtComPort.Text, 9600);

            server = new Server(Convert.ToInt32(txtPort.Text), 3);
            server.hB += AddIncomingToLog;
            server.StartServer();
            lblServerState.Content = "Server: running";
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            server.StopServer();
            lblServerState.Content = "Server: stopped";
        }

        private void AddIncomingToLog(byte[] b)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => {

                //txbLog.Text += "\n" + DateTime.Now + ": " + "R: " + b[0] + "; " + "G: " + b[1] + "; " + "B: " + b[2] + "; ";
                canvas.Background = new SolidColorBrush(Color.FromRgb(b[0], b[1], b[2]));
                b[1] = (byte)(b[1] * greenFactor);
                b[2] = (byte)(b[2] * blueFactor);
                arduino.SendData(b);
            }));
            
        }

        private void txbLog_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox t = (TextBox)sender;
            t.CaretIndex = t.Text.Length;
            t.ScrollToEnd();
        }
    }
}
