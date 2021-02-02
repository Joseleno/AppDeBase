using System;

namespace AppDeBase.Affaires.Models
{
    public class Produit : Entity
    {
        public Guid FournisseurId { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public decimal Valeur { get; set; }
        public DateTime DateInscription { get; set; }
        public bool Active { get; set; }

        public Fournisseur Fournisseur { get; set; }
    }
}