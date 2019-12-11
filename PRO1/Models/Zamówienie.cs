using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Zamówienie
    {
        public int IdZamowienia { get; set; }
        public int StanIdStanu { get; set; }
        public int LokaleIdLokalu { get; set; }
        public int UżytkownikIdUżytkownika { get; set; }
        public DateTime Data { get; set; }
        public decimal PodsumowanieCeny { get; set; }

        public virtual Lokale LokaleIdLokaluNavigation { get; set; }
        public virtual Stan StanIdStanuNavigation { get; set; }
        public virtual Użytkownik UżytkownikIdUżytkownikaNavigation { get; set; }
        public virtual ZamowionePizze ZamowionePizze { get; set; }
    }
}
