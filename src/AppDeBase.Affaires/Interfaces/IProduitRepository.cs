using AppDeBase.Affaires.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppDeBase.Affaires.Interfaces
{
    public interface IProduitRepository : IRepository<Produit>
    {
        Task<IEnumerable<Produit>> ObtenirProduitsParFournisseur(Guid fornisseurId);

        Task<IEnumerable<Produit>> ObtenirProduitsFournisseurs();

        Task<Produit> ObtenirProduitFornisseur(Guid id);
    }
}