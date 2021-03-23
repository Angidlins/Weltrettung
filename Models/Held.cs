using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WeltrettungAuftrag.Models
{
    public partial class Held
    {
        public Held()
        {
            Kampfs = new HashSet<Kampf>();
        }

        public int HeldId { get; set; }

        [Required(ErrorMessage = "Geben Sie Ihren Vorname")]
        public string Vorname { get; set; }
        [Required(ErrorMessage = "Geben Sie Ihren Nachname")]
        public string Nachname { get; set; }
        [Required(ErrorMessage = "Geben Sie Ihren E-Mail")]
        public string Email { get; set; }
        public string Faehigkeit { get; set; }
       
        public bool Volljaehrig { get; set; }

        public virtual ICollection<Kampf> Kampfs { get; set; }
    }
}
