using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjekatGurmaniWebAPI.Controllers
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

    }
}
