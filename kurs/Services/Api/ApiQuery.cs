using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kurs.Core.Data;
using Kurs.Core.Domain;
using Kurs.Core.Infrastructure;
using Kurs.Models;

namespace Kurs.Services.Api
{
    public class ApiQuery : IApiQuery
    {
        private readonly IEntityExpressionsBuilder _entityExpressionsBuilder;

        public ApiQuery(IEntityExpressionsBuilder entityExpressionsBuilder)
        {
            _entityExpressionsBuilder = entityExpressionsBuilder;
        }

        public async Task<IEnumerable<T>> GetItemsFromQueryAsync<T>(IQueryable<T> query, Guid id, GetItemsOptions options)
            where T : BaseEntity
        {
            query = query.Select(_entityExpressionsBuilder.GetDefaultEntitySelectorExpression<T>());
            if (!Equals(id, Guid.Empty))
            {
                query = query.Where(entity => entity.Id == id);
            }
            else
            {
                if (options != null && options.RowsCount > 0)
                {
                    query = query.Skip((options.Page - 1) * options.RowsCount).Take(options.RowsCount);
                }
            }

            return await Task.FromResult((IEnumerable<T>)query.ToArray());
        }
    }
}