using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Stan
    {
        public Stan()
        {
            Zamówienie = new HashSet<Zamówienie>();
        }

        public int IdStanu { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Zamówienie> Zamówienie { get; set; }
    }
}
