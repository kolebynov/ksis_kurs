using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kurs.ApiResults;
using Kurs.Core.Data;
using Kurs.Core.Domain;
using Kurs.Core.Infrastructure;
using Kurs.Models;
using Kurs.Services.Api;
using Kurs.Services.Note;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kurs.Controllers.Api
{
    [Route("api/notes")]
    public class NoteController : BaseApiController<Note>
    {
        private readonly INoteFileService _noteFileService;

        public NoteController(IRepository<Note> repository, IEntityExpressionsBuilder entityExpressionsBuilder, 
            IApiQuery apiQuery, IApiHelper apiHelper, INoteFileService noteFileService) 
            : base(repository, entityExpressionsBuilder, apiQuery, apiHelper)
        {
            _noteFileService = noteFileService;
        }

        [HttpGet("{id}/comments")]
        public Task<ApiResult<IEnumerable<NoteComment>>> GetComments([FromServices]IRepository<NoteComment> repository, Guid id, 
            GetItemsOptions options)
        {
            return ApiHelper.CreateApiResultFromQueryAsync(repository.Entities.Where(entity => entity.NoteId == id),
                Guid.Empty, options);
        }

        [HttpGet("{id}/files")]
        public Task<ApiResult<IEnumerable<NoteFile>>> GetFiles([FromServices]IRepository<NoteFile> repository, Guid id,
            GetItemsOptions options)
        {
            return ApiHelper.CreateApiResultFromQueryAsync(repository.Entities.Where(entity => entity.NoteId == id),
                Guid.Empty, options);
        }

        [HttpPost("{id}/uploadFiles")]
        public async Task<ApiResult<IEnumerable<NoteFile>>> UploadFiles([FromServices] IRepository<NoteFile> repository, 
            Guid id, List<IFormFile> files)
        {
            List<Guid> uploadedFiles = new List<Guid>(files.Count);
            foreach (IFormFile formFile in files)
            {
                uploadedFiles.Add((await _noteFileService.UploadFileAsync(id, formFile)).Id);
            }

            return ApiResult.SuccessResult(await ApiQuery.GetItemsFromQueryAsync(
                repository.Entities.Where(file => uploadedFiles.Contains(file.Id)), Guid.Empty, null));
        }
    }
}