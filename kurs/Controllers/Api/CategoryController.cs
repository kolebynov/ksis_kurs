using Kurs.ApiResults;
using Kurs.Core.Data;
using Kurs.Core.Domain;
using Kurs.Core.Infrastructure;
using Kurs.Models;
using Kurs.Services.Api;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kurs.Controllers.Api
{
    [Route("api/categories")]
    public class CategoryController : BaseApiController<NoteCategory>
    {
        public CategoryController(IRepository<NoteCategory> repository, IEntityExpressionsBuilder entityExpressionsBuilder,
            IApiQuery apiQuery, IApiHelper apiHelper) : base(repository, entityExpressionsBuilder, apiQuery, apiHelper)
        {
        }

        [HttpGet("{id}/notes")]
        public Task<ApiResult<IEnumerable<Note>>> GetNotes([FromServices]IRepository<Note> repository, Guid id,
            GetItemsOptions options)
        {
            return ApiHelper.CreateApiResultFromQueryAsync(repository.Entities.Where(entity => entity.CategoryId == id),
                Guid.Empty, options);
        }
    }
}