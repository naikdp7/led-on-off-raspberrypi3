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
using Windows.Devices.Gpio;
using System.Threading;
using System.Diagnostics;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ledblink
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GpioPin _pin;
               
        public MainPage()
        {
            this.InitializeComponent();
            Loaded += MainPage_Loaded;
           
          
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)

        {

            var controller = GpioController.GetDefault();

            _pin = controller.OpenPin(18);

            _pin.SetDriveMode(GpioPinDriveMode.Output);

            _pin.Write(GpioPinValue.High);
                      
         }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _pin.Write(GpioPinValue.Low);
            result.Text = "Led is ON";
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            _pin.Write(GpioPinValue.High);
            result.Text = "Led is OFF";
        }
    }
}
