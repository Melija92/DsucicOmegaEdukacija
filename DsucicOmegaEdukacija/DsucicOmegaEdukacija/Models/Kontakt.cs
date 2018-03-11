using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DsucicOmegaEdukacija.Models
{
    public class Kontakt
    {
        public Kontakt()
        {
            imeIPrezime = String.Format("{0} {1}", Ime, Prezime);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid KontaktId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        string imeIPrezime;
        public string ImeIPrezime
        {
            get
            {
                return this.imeIPrezime;
            }

        }
        public DateTime DatumRodenja { get; set; }

        public Guid GradId { get; set; }
        public Grad Grad { get; set; }
    }
}