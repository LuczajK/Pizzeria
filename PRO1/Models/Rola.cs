using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Rola
    {
        public Rola()
        {
            Użytkownik = new HashSet<Użytkownik>();
        }

        public int IdRoli { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Użytkownik> Użytkownik { get; set; }
    }
}
