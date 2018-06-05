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
using ProjekatGurmani1.DB;
using ProjekatGurmani1.Modeli;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatGurmani1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaKupca : Page
    {
        public RegistracijaKupca()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBKupac kupacBaza = new DBKupac();
            Kupac k = new Kupac();

            k.ime = ime.Text;
            k.prezime = prezime.Text;
            k.telefon = tel.Text;
            k.adresa = adresa.Text;
            k.email = mail.Text;
            if(sifra1.TextReadingOrder.ToString().Equals(sifra2.TextReadingOrder.ToString()))
            k.password = sifra1.TextReadingOrder.ToString();
            else
            {
                var messageDialog = new MessageDialog("Nije ista sifra!");
                messageDialog.ShowAsync();
            }

            if (ime.Text == "" && k.prezime == "" && k.telefon == "" && k.adresa == "" && k.email == "")
            {
                var messageDialog1 = new MessageDialog("Popuniti sva polja!");
                messageDialog1.ShowAsync();
            }
     
            else
            {
                var messageDialog1 = new MessageDialog("Uspjesna registracija!");
                messageDialog1.ShowAsync();
            }

            kupacBaza.unesiKupca(k);
        }


        private void RelativePanel_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Admin_pocetna));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
