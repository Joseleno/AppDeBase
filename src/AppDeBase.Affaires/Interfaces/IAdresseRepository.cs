using AppDeBase.Affaires.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppDeBase.Affaires.Interfaces
{
    public interface IAdresseRepository : IRepository<Adresse>
    {
        Task<Adresse> ObtenirAdresseFournisseur(Guid fornisseurId);
    }
}