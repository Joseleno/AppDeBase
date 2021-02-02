using System;

namespace AppDeBase.Affaires.Models
{
    public class Adresse : Entity
    {
        public Guid FournisseurId { get; set; }
        public int Numero { get; set; }
        public string Rue { get; set; }
        public string Complement { get; set; }
        public string CodePostal { get; set; }
        public string Ville { get; set; }
        public string Province { get; set; }

        //EF Relation
        public Fournisseur Fournisseur { get; set; }
    }
}