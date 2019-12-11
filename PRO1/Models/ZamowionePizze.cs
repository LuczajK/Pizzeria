using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class ZamowionePizze
    {
        public int ZamówienieIdZamowienia { get; set; }
        public int PizzaWlasnaSkładnikIdSkladnik { get; set; }
        public int PizzaWlasnaIdWlasnejPizzy { get; set; }
        public int PizzaWlasnaGotowePizzeIdGotowePizze { get; set; }

        public virtual PizzaWlasna PizzaWlasna { get; set; }
        public virtual Zamówienie ZamówienieIdZamowieniaNavigation { get; set; }
    }
}
