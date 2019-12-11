using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class GotowaPizza
    {
        public GotowaPizza()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdGotowaPizza { get; set; }
        public int PizzaIdPizza { get; set; }
        public int SkladnikIdSkladnik { get; set; }
        public int RozmiarIdRozmiar { get; set; }
        public int RodzajIdRodzaj { get; set; }
        public int Cena { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Rodzaj RodzajIdRodzajNavigation { get; set; }
        public virtual Rozmiar RozmiarIdRozmiarNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
