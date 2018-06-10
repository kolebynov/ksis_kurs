using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;

namespace Kurs.Core.Infrastructure
{
    public class EntityExpressionsBuilder : IEntityExpressionsBuilder
    {
        private static readonly ConcurrentDictionary<Type, LambdaExpression> DefaultEntitySelectorsCache = 
            new ConcurrentDictionary<Type, LambdaExpression>();

        public Expression<Func<TEntity, TEntity>> GetDefaultEntitySelectorExpression<TEntity>()
        {
            Type entityType = typeof(TEntity);
            if (!DefaultEntitySelectorsCache.TryGetValue(entityType, out LambdaExpression result))
            {
                ParameterExpression inputEntityExpression = Expression.Parameter(entityType);

                DefaultEntitySelectorsCache[entityType] = result = Expression.Lambda<Func<TEntity, TEntity>>(
                    Expression.MemberInit(
                        Expression.New(entityType.GetConstructor(Type.EmptyTypes)),
                        entityType.GetProperties()
                            .Where(property => property.GetCustomAttribute<IgnoreDataMemberAttribute>() == null)
                            .Select<PropertyInfo, MemberBinding>(property =>
                                Expression.Bind(property, Expression.Property(inputEntityExpression, property)))
                    ),
                    inputEntityExpression
                );
            }

            return (Expression<Func<TEntity, TEntity>>)result;
        }
    }
}