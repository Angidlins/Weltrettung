using System;
using System.Collections.Generic;

#nullable disable

namespace WeltrettungAuftrag.Models
{
    public partial class Kampf
    {
        public int KampfId { get; set; }
        public string Kampfbezeichnung { get; set; }
        public int AggressorId { get; set; }
        public int HeldId { get; set; }

        public virtual Aggressor Aggressor { get; set; }
        public virtual Held Held { get; set; }
    }

}
