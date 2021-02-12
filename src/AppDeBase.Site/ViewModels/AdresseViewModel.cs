using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace AppDeBase.Site.ViewModels
{
    public class AdresseViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [StringLength(200, ErrorMessage = "Le champ {0} doit comporter entre {2} et {1} caractères", MinimumLength = 3)]
        public string Rue { get; set; }

        public string Complement { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [StringLength(6, ErrorMessage = "Le champ {0} doit comporter {1} caractères", MinimumLength = 6)]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [StringLength(100, ErrorMessage = "Le champ {0} doit comporter entre {2} et {1} caractères", MinimumLength = 3)]
        public string Ville { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [StringLength(50, ErrorMessage = "Le champ {0} doit comporter entre {2} et {1} caractères", MinimumLength = 3)]
        public string Province { get; set; }

        [HiddenInput]
        public Guid FournisseurId { get; set; }
    }
}