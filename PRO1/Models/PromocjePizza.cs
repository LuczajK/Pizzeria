using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class PromocjePizza
    {
        public int PromocjeIdPromocji { get; set; }
        public int GotowePizzeIdGotowePizze { get; set; }
        public int SkladnikIdSkladnik { get; set; }

        public virtual BazowePizze GotowePizzeIdGotowePizzeNavigation { get; set; }
        public virtual Promocje PromocjeIdPromocjiNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
