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
    public class AdresseRepository : Repository<Adresse>, IAdresseRepository
    {
        public AdresseRepository(AppDeBaseDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Adresse> ObtenirAdresseFournisseur(Guid fournisseurId)
        {
            return await _dbContext.Adresses.AsNoTracking()
                .FirstOrDefaultAsync(a => a.FournisseurId == fournisseurId);
        }
    }
}