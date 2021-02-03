using AppDeBase.Affaires.Interfaces;
using AppDeBase.Affaires.Models;
using AppDeBase.Donnees.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppDeBase.Donnees.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : Entity, new()
    {
        protected readonly AppDeBaseDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        protected Repository(AppDeBaseDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbSet = dbContext.Set<T>();
        }

        public virtual async Task<T> ObtenirParId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> ObtenirTouts()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IEnumerable<T>> Chercher(Expression<Func<T, bool>> predicat)
        {
            return await _dbSet.AsNoTracking().Where(predicat).ToListAsync();
        }

        public virtual async Task Ajouter(T entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Supprimir(Guid id)
        {
            _dbSet.Remove(new T { Id = id });
            await SaveChanges();
        }

        public virtual async Task Update(T entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}