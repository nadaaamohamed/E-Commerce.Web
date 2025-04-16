using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contarcts
{
    public interface IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
     Task<IEnumerable<TEntity>> GetAllAsync();  
        Task<TEntity?> GetByIdAsync(Tkey id);
        Task AddAsync(TEntity entity);  
        void Update(TEntity entity);
        void Remove(TEntity entity);

    }
}
