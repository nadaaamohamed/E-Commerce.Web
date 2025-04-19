using DomainLayer.Contarcts;
using DomainLayer.Models;
using System.Linq.Expressions;

namespace Service.Speceifications
{
    abstract class BaseSpeceification<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        protected BaseSpeceification(Expression<Func<TEntity, bool>>? criteriaExp)
        {
            Criteria = criteriaExp;
        }


        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        #region Sorting
        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }
        protected void AddOrderBy(Expression<Func<TEntity, object>> OrderByExp) => OrderBy = OrderByExp;
        protected void AddOrderByDescending (Expression<Func<TEntity , object>> OrderByDescendingExp) => OrderByDescending = OrderByDescendingExp;
        #endregion

        #region Include
        public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];

       
        protected void AddInclude(Expression<Func<TEntity, object>> IncludeExpression)
        {
            IncludeExpressions.Add(IncludeExpression);
        }
        #endregion
        #region Pagination
        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPaginated { get; set; }
        protected void ApplyPagination(int PageSize, int PageIndex)
        {
            IsPaginated = true;
            Take = PageSize;
            Skip =(PageIndex- 1) * PageSize;

        }
        #endregion



    }
}
