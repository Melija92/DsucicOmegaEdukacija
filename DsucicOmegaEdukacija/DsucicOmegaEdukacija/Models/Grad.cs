﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DsucicOmegaEdukacija.Models
{ 
    public class Grad
    {
        public Grad()
        {
            //Kontakti = new List<Kontakt>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid GradId { get; set; }
        public string Naziv { get; set; }
        //public List<Kontakt> Kontakti { get; set; }
    }
}