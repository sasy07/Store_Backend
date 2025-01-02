using System.Linq.Expressions;
using Store.Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;

namespace Store.Application.Contracts.Specification
{
    public interface ISpecification<T> where T : BaseEntity
    {
        Expression<Func<T, bool>> Predicate { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }

    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> predicate)
        {
            Predicate = predicate;
        }

        protected void AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }
        public Expression<Func<T, bool>> Predicate { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();
    }

    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery.AsQueryable();
            if (specification.Predicate != null)
                query = query.Where(specification.Predicate);
            if (specification.Includes.Any())
                query = specification.Includes.Aggregate(query, (current, value) => current.Include(value));
            return query;
        }
    }
}
