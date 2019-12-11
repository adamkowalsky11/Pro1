using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Rozmiar
    {
        public Rozmiar()
        {
            GotowaPizza = new HashSet<GotowaPizza>();
        }

        public int IdRozmiar { get; set; }
        public string Rozmiar1 { get; set; }
        public string Cena { get; set; }

        public virtual ICollection<GotowaPizza> GotowaPizza { get; set; }
    }
}
