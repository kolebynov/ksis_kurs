using Kurs.Core.Data;
using Kurs.Core.Domain;
using Kurs.Core.Infrastructure;
using Kurs.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers.Api
{
    [Route("api/categories")]
    public class CategoryController : BaseApiController<NoteCategory>
    {
        public CategoryController(IRepository<NoteCategory> repository, IEntityExpressionsBuilder entityExpressionsBuilder,
            IApiQuery apiQuery, IApiHelper apiHelper) : base(repository, entityExpressionsBuilder, apiQuery, apiHelper)
        {
        }
    }
}