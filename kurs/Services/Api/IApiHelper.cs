using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.ApiResults;
using Kurs.Core.Domain;
using Kurs.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Kurs.Services.Api
{
    public interface IApiHelper
    {
        ApiResult GetErrorResultFromModelState(ModelStateDictionary modelState);
        ApiResult GetErrorResultFromException(Exception exception);
        Task<ApiResult<IEnumerable<T>>> CreateApiResultFromQueryAsync<T>(IQueryable<T> query, Guid id,
            GetItemsOptions options) where T : BaseEntity;
    }
}