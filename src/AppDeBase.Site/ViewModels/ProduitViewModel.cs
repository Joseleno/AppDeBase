using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppDeBase.Site.ViewModels
{
    public class ProduitViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [StringLength(200, ErrorMessage = "Le champ {0} doit comporter entre {2} et {1} caractères", MinimumLength = 3)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [StringLength(1000, ErrorMessage = "Le champ {0} doit comporter entre {2} et {1} caractères", MinimumLength = 3)]
        public string Description { get; set; }

        [DisplayName("L'Image du produit")]
        public IFormFile ImgTélecharger { get; set; }

        public string Image { get; set; }

        [DisplayName("Prix")]
        [Required(ErrorMessage = "Le champ {0} est requis")]
        public decimal Valeur { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DateInscription { get; set; }

        [DisplayName("Disponible")]
        public bool Active { get; set; }

        public FournisseurViewModel Fournisseur { get; set; }
        public IEnumerable<FournisseurViewModel> Fournisseurs { get; set; }
    }
}