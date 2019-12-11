using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class PizzaWlasna
    {
        public PizzaWlasna()
        {
            ZamowionePizze = new HashSet<ZamowionePizze>();
        }

        public int SkładnikIdSkladnik { get; set; }
        public int IdWlasnejPizzy { get; set; }
        public decimal Cena { get; set; }
        public int GotowePizzeIdGotowePizze { get; set; }

        public virtual BazowePizze GotowePizzeIdGotowePizzeNavigation { get; set; }
        public virtual Skladnik SkładnikIdSkladnikNavigation { get; set; }
        public virtual ICollection<ZamowionePizze> ZamowionePizze { get; set; }
    }
}
