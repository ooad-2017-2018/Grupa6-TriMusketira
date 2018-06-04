using BeFitApp.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProjekatGurmani.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
      
            ViewBag.Message = "Ova aplikacija je namjenjena za sve osobe koje su ljubitelji ukusne hrane. Osnovna ideja jeste da korisnici ove aplikacije mogu vrlo lahko naruciti hranu i uzivati u istoj. Najvecu korist imaju ljudi koji nisu u stanju odlaziti po hranu, te traziti najpovoljniju. Jednostavan i brz nacin pretrage nudi upravo ova aplikacija. Aplikacija nudi i veliki izbor dostava poslastica, kao sto su torte, kolaci, krofne i slicno. Na veoma brz i lagan nacin mozete naruciti zeljeno jelo, ali najveca prednost je i ta sto je omoguceno placanje kreditnom karticom, sto je danas velika olaksica za mnoge. Svaki objekat ima opis svojih usluga. Pored toga, svaki objekat ima ocjenu koja je zasnovana na ocjenama dotadasnjih korisnika njihovih usluga, sto pomaze kupcima sigurnije narucivanje. Takodjer se mogu pronaci adrese svih vecih restorana, fastfood-ova, slasticarnih, te sve sto se tice hrane. Svaki korak je jasno naveden za korisnika u cilju sto lakseg koristenja, sto je jako bitno, s obzirom da je svrha to da se omoguci upotreba za sve generacije." +
                "U cilju vece posjecenosti osmisljeno je i to da kupac ostvaruje odredjeni popust, na nacin sakupljanja tanjirica.Za svaku narudzbu iz odredjenog objekta kupac dobije po jedan 'tanjiric' za taj objekat, te kada skupi 5 'tanjirica' dobija popust od 50 % na sestu narudzbu iz tog lokala, nakon cega se resetuju 'tanjirici', te ih kupac skuplja ispocetka.Nakon neaktivnosti od godinu dana 'tanjirici' se resetuju. Na taj nacin podsticemo nase kupce na sto vecu azurnost ove aplikacije." +
                "Uzivajte u odlicnoj ponudi, preglednim jelovnicima, mnogim akcijama, ali prije svega u ukusnoj hrani.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }


        public ActionResult Mapa()
        {
            ViewBag.Message = "Vaza lokacija";

            return View();
        }

        public ActionResult GetLocations()
        {
            var task = Task.Run(async () => await AsyncGetLocations());
            task.Wait();
            var asyncFunctionResult = task.Result;
            return asyncFunctionResult;
        }
        public async Task<ActionResult> AsyncGetLocations()
        {

            var client = new HttpClient();
            var address = new Uri("https://api.foursquare.com/v2/venues/search?ll=43.85,18.23&categoryId=4bf58dd8d48988d175941735&client_id=KHAWRYD4PJ0LKVSZQF4CEXTX5GK3BDPTWS3XLCTVAYQPK515&client_secret=BSTBTSNVENYHWGGNYGGQ00X33NJNNFTPZVIPOB3LGC1UVXBI&v=20160202");
            HttpResponseMessage response = await client.GetAsync(address);
            String stream = await response.Content.ReadAsStringAsync();
            dynamic dyn = JsonConvert.DeserializeObject(stream);
            var sp = stream.Split('"');
            double lat = 0;
            var locations = new List<Locations>();
            string loc = "n";
            for (int i = 0; i < sp.Length; i++)
            {
                if (sp[i] == "lat")
                    lat = Convert.ToDouble(sp[i + 1].Substring(1, sp[i + 1].Length - 2));
                if (sp[i] == "lng")
                {
                    for (int j = i; j >= 0; j--)
                        if (sp[j] == "name")
                        {
                            loc = sp[j + 2];
                            break;
                        }
                    locations.Add(new Locations(lat, Convert.ToDouble(sp[i + 1].Substring(1, sp[i + 1].Length - 4)), loc));
                }
            }

            return Json(locations, JsonRequestBehavior.AllowGet);
        }



    }

}
namespace BeFitApp.Controllers
{
    class Locations
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string naziv { get; set; }
        public Locations(double latitude, double longitude, string naziv)
        {
            this.latitude = latitude;
            this.longitude = longitude;
            this.naziv = naziv;
        }
    };
}