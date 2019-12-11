using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Użytkownik
    {
        public Użytkownik()
        {
            Zamówienie = new HashSet<Zamówienie>();
        }

        public int IdUżytkownika { get; set; }
        public int RolaIdRoli { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public string NrDomu { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }

        public virtual Rola RolaIdRoliNavigation { get; set; }
        public virtual ICollection<Zamówienie> Zamówienie { get; set; }
    }
}
