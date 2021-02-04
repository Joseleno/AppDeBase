using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppDeBase.Site.ViewModels
{
    public class FournisseurViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [StringLength(100, ErrorMessage = "Le champ {0} doit comporter entre {2} et {1} caractères", MinimumLength = 3)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Le champ {0} est requis")]
        [StringLength(15, ErrorMessage = "Le champ {0} doit comporter entre {2} et {1} caractères", MinimumLength = 7)]
        public string Document { get; set; }

        [DisplayName("Type")]
        public int TypeFournisseur { get; set; }

        public AdresseViewModel Adresse { get; set; }

        [DisplayName("Actif")]
        public bool Acitve { get; set; }

        //EF Relations
        public IEnumerable<ProduitViewModel> Produits { get; set; }
    }
}