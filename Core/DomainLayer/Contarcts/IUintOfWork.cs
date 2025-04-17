using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contarcts
{
    public interface IUintOfWork
    {
        Task <int> SaveChangesAsync();
        IGenericRepository<TEntity, Tkey> GenericRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    }
}
