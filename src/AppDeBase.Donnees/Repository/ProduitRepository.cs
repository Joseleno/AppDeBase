using AppDeBase.Affaires.Interfaces;
using AppDeBase.Affaires.Models;
using AppDeBase.Donnees.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDeBase.Donnees.Repository
{
    public class ProduitRepository : Repository<Produit>, IProduitRepository
    {
        public ProduitRepository(AppDeBaseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Produit> ObtenirProduitFornisseur(Guid id)
        {
            return await _dbContext.Produits.AsNoTracking()
                .Include(f => f.Fournisseur)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produit>> ObtenirProduitsFournisseurs()
        {
            return await _dbContext.Produits.AsNoTracking()
                .Include(f => f.Fournisseur).OrderBy(p => p.Nom)
                .ToListAsync();
        }

        public async Task<IEnumerable<Produit>> ObtenirProduitsParFournisseur(Guid fournisseurId)
        {
            return await Chercher(p => p.FournisseurId == fournisseurId);
        }
    }
}