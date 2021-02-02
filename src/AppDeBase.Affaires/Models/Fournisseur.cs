using System;
using System.Collections.Generic;

namespace AppDeBase.Affaires.Models
{
    public class Fournisseur : Entity
    {
        public string Nom { get; set; }
        public string Document { get; set; }
        public TypeFournisseur TypeFournisseur { get; set; }
        public Adresse Adresse { get; set; }
        public bool Acitve { get; set; }

        //EF Relations
        public IEnumerable<Produit> Produits { get; set; }
    }
}