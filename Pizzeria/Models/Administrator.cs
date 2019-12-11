using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdAdministrator { get; set; }
        public int Imie { get; set; }
        public int Nazwisko { get; set; }
        public int Login { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
