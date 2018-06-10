using System;
using System.Linq.Expressions;

namespace Kurs.Core.Infrastructure
{
    public interface IEntityExpressionsBuilder
    {
        Expression<Func<TEntity, TEntity>> GetDefaultEntitySelectorExpression<TEntity>();
    }
}