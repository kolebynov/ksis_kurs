using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.Core.Domain;
using Kurs.Models;

namespace Kurs.Services.Api
{
    public interface IApiQuery
    {
        Task<IEnumerable<T>> GetItemsFromQueryAsync<T>(IQueryable<T> query, Guid id, GetItemsOptions options)
            where T : BaseEntity;
    }
}