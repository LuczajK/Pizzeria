using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Promocje
    {
        public Promocje()
        {
            PromocjePizza = new HashSet<PromocjePizza>();
        }

        public int IdPromocji { get; set; }
        public string KodRabatowy { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<PromocjePizza> PromocjePizza { get; set; }
    }
}
