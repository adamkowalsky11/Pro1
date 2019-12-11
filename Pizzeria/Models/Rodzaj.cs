using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Rodzaj
    {
        public Rodzaj()
        {
            GotowaPizza = new HashSet<GotowaPizza>();
        }

        public int IdRodzaj { get; set; }
        public string Rodzaj1 { get; set; }
        public string Cena { get; set; }

        public virtual ICollection<GotowaPizza> GotowaPizza { get; set; }
    }
}
