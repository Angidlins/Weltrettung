using System;
using System.Collections.Generic;

#nullable disable

namespace WeltrettungAuftrag.Models
{
    public partial class Aggressor
    {
        public Aggressor()
        {
            Kampfs = new HashSet<Kampf>();
        }

        public int AggressorId { get; set; }
        public string Name { get; set; }
        public string Spitzname { get; set; }
        public string Spezialitaet { get; set; }

        public virtual ICollection<Kampf> Kampfs { get; set; }
    }
}
