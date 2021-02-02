using AppDeBase.Affaires.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppDeBase.Affaires.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Ajouter(TEntity entity);

        Task<TEntity> ObtenirParId(Guid Id);

        Task<List<TEntity>> ObtenirTouts();

        Task Supprimir(Guid Id);

        Task Update(TEntity entity);

        Task<int> SaveChanges();

        Task<IEnumerable<TEntity>> Chercher(Expression<Func<TEntity, bool>> predicat);
    }
}