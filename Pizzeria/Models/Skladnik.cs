using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            GotowaPizza = new HashSet<GotowaPizza>();
        }

        public int IdSkladnik { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<GotowaPizza> GotowaPizza { get; set; }
    }
}
