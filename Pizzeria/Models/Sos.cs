using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Sos
    {
        public Sos()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int IdSos { get; set; }
        public string Sos1 { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
