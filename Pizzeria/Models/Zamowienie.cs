using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Zamowienie
    {
        public int IdZamowienie { get; set; }
        public string KosztCalkowity { get; set; }
        public int GotowaPizzaIdGotowaPizza { get; set; }
        public int ImieKlienta { get; set; }
        public int NazwiskoKlienta { get; set; }
        public string UlicaKlienta { get; set; }
        public int NrBudynkuKlienta { get; set; }
        public int NrMieszkaniaKlienta { get; set; }
        public string KodPocztowyKlienta { get; set; }
        public string EmailKlienta { get; set; }
        public string NrTelefonuKlienta { get; set; }
        public int SzacowanaDataDostarczenia { get; set; }
        public int AdministratorIdAdministrator { get; set; }

        public virtual Administrator AdministratorIdAdministratorNavigation { get; set; }
        public virtual GotowaPizza GotowaPizzaIdGotowaPizzaNavigation { get; set; }
    }
}
