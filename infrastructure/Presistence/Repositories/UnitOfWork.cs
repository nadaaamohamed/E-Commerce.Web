using DomainLayer.Contarcts;
using DomainLayer.Models;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class UnitOfWork(StoreDbContext _dbContext) : IUintOfWork
    {
        private readonly Dictionary<string , object> _repositories = [];
        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
        {
            var typename = typeof(TEntity).Name;
            //if (_repositories.ContainsKey(typename))
            //{
            //    return (IGenericRepository<TEntity, Tkey>)_repositories[typename];
            //}
            if (_repositories.TryGetValue(typename , out object ?value))
            {
                return (IGenericRepository<TEntity, Tkey>)value;
            }

            else
            {
                var repository = new GenericRepository<TEntity, Tkey>(_dbContext);
                _repositories.Add(typename, repository);
                return repository;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }
    }
}
