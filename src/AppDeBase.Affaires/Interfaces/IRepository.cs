using AppDeBase.Affaires.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppDeBase.Affaires.Interfaces
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task Ajouter(T entity);

        Task<T> ObtenirParId(Guid id);

        Task<List<T>> ObtenirTouts();

        Task Supprimir(Guid id);

        Task Update(T entity);

        Task<int> SaveChanges();

        Task<IEnumerable<T>> Chercher(Expression<Func<T, bool>> predicat);
    }
}