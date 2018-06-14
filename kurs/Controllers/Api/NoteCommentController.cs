using Kurs.Core.Data;
using Kurs.Core.Domain;
using Kurs.Core.Infrastructure;
using Kurs.Services.Api;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers.Api
{
    /// <summary>
    /// Контроллер для работы с комментариями записок.
    /// </summary>
    [Route("api/comments")]
    public class NoteCommentController : BaseApiController<NoteComment>
    {
        public NoteCommentController(IRepository<NoteComment> repository, IEntityExpressionsBuilder entityExpressionsBuilder, 
            IApiQuery apiQuery, IApiHelper apiHelper) : base(repository, entityExpressionsBuilder, apiQuery, apiHelper)
        {
        }
    }
}