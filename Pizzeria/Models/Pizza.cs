using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            GotowaPizza = new HashSet<GotowaPizza>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public int SosIdSos { get; set; }

        public virtual Sos SosIdSosNavigation { get; set; }
        public virtual ICollection<GotowaPizza> GotowaPizza { get; set; }
    }
}
