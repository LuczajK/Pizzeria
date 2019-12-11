using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Lokale
    {
        public Lokale()
        {
            Zamówienie = new HashSet<Zamówienie>();
        }

        public int IdLokalu { get; set; }
        public string Adres { get; set; }
        public string Godzinyotwarcia { get; set; }
        public string Współrzędne { get; set; }

        public virtual ICollection<Zamówienie> Zamówienie { get; set; }
    }
}
