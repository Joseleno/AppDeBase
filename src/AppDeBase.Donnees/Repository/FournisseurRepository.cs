using AppDeBase.Affaires.Interfaces;
using AppDeBase.Affaires.Models;
using AppDeBase.Donnees.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDeBase.Donnees.Repository
{
    public class FournisseurRepository : Repository<Fournisseur>, IFournisseurRepository
    {
        public FournisseurRepository(AppDeBaseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Fournisseur> ObtenirFournisseurAdresse(Guid id)
        {
            return await _dbContext.Fournisseurs.AsNoTracking()
                .Include(f => f.Adresse)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fournisseur> ObtenirFournisseurProduitsAdresse(Guid id)
        {
            return await _dbContext.Fournisseurs.AsNoTracking()
                .Include(f => f.Produits)
                .Include(f => f.Adresse)
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }
}