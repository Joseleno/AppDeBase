using AppDeBase.Affaires.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDeBase.Affaires.Interfaces
{
    public interface IFournisseurRepository : IRepository<Fournisseur>
    {
        Task<Fournisseur> ObtenirFournisseurAdresse(Guid id);

        Task<Fournisseur> ObtenirFournisseurProduitsAdresse(Guid id);
    }
}