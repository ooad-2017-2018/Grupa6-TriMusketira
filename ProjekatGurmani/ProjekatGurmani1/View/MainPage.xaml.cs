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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjekatGurmani1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(odabirLokacijexaml));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
        

            if (tekstic.Text == "admin" ) this.Frame.Navigate(typeof(Admin_pocetna));
            else if (tekstic.Text == "korisnik") this.Frame.Navigate(typeof(MojProfil));
            else if (tekstic.Text == "objekat") this.Frame.Navigate(typeof(MojProfil));
            else if (tekstic.Text == "")
            {
                var messageDialog = new MessageDialog("Morate popuniti sva polja!");
                messageDialog.ShowAsync();
            }
            else
            {
                var messageDialog = new MessageDialog("Ne postoji korisnik u bazi!");
                messageDialog.ShowAsync();

            }
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistracijaKupca));
            
        }
    }
}
