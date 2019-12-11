using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class BazowePizze
    {
        public BazowePizze()
        {
            PizzaWlasna = new HashSet<PizzaWlasna>();
            PromocjePizza = new HashSet<PromocjePizza>();
        }

        public int IdGotowePizze { get; set; }
        public int Nazwa { get; set; }
        public decimal Cena { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<PizzaWlasna> PizzaWlasna { get; set; }
        public virtual ICollection<PromocjePizza> PromocjePizza { get; set; }
    }
}
