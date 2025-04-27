using DomainLayer.Models.ProductsModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contarcts
{
    public interface IGenericRepository<TEntity, Tkey> where TEntity : BaseEntity<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, Tkey> specifications);
        Task<TEntity?> GetByIdAsync(ISpecifications<TEntity , Tkey> specifications);
        Task<TEntity?> GetByIdAsync(Tkey id);
        Task AddAsync(TEntity entity);  
        void Update(TEntity entity);
        void Remove(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<int> CountAsync(ISpecifications<TEntity , Tkey> specifications);



    }
}
