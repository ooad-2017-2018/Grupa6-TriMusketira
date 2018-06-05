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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatGurmani1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminObrisiObjekat : Page
    {
        public AdminObrisiObjekat()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void RelativePanel_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Admin_pocetna));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBObjekat objekatBaza = new DBObjekat();

            objekatBaza.ucitajObjekte();
            foreach (Objekat k in objekatBaza.Objekti)
            {
                if (ime.Text == k.ime + " " + k.prezime) objekatBaza.brisiObjekat(k);
            }
        }
    }
}
