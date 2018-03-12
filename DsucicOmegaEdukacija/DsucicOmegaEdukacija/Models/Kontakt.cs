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

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid KontaktId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public Guid GradId { get; set; }
        public Grad Grad { get; set; }
    }
}