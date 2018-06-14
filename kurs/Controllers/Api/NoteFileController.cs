using Kurs.Core.Data;
using Kurs.Core.Domain;
using Kurs.Core.Infrastructure;
using Kurs.Services.Api;
using Kurs.Services.Note;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Kurs.ApiResults;
using Microsoft.EntityFrameworkCore.Extensions.Internal;

namespace Kurs.Controllers.Api
{
    /// <summary>
    /// Контроллер для работы с файлами записок.
    /// </summary>
    [Route("api/files")]
    public class NoteFileController : BaseApiController<NoteFile>
    {
        private readonly INoteFileService _noteFileService;

        public NoteFileController(IRepository<NoteFile> repository, IEntityExpressionsBuilder entityExpressionsBuilder, 
            IApiQuery apiQuery, IApiHelper apiHelper, INoteFileService noteFileService) : base(repository, entityExpressionsBuilder, apiQuery, apiHelper)
        {
            _noteFileService = noteFileService;
        }

        /// <summary>
        /// Скачивает файл с сервера по id файла.
        /// </summary>
        /// <param name="id">Id файла, который нужно скачать.</param>
        /// <returns></returns>
        [HttpGet("{id}/fileData")]
        public async Task<IActionResult> GetNoteFileData(Guid id)
        {
            var file = EntityRepository.Entities
                .Where(noteFile => noteFile.Id == id)
                .Select(noteFile => new
                {
                    noteFile.ContentType, noteFile.FileName
                }).First();

            return File(await _noteFileService.GetFileDataAsync(id), file.ContentType, file.FileName);
        }

        /// <summary>
        /// Перегружен, чтобы возвращать 404.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override Task<IActionResult> AddItem(NoteFile item)
        {
            return Task.FromResult((IActionResult)NotFound());
        }

        /// <summary>
        /// Перегружен, чтобы возвращать 404.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public override Task<IActionResult> UpdateItem(Guid id, NoteFile item)
        {
            return Task.FromResult((IActionResult)NotFound());
        }

        public override async Task<ApiResult> RemoveItem(Guid id)
        {
            await _noteFileService.DeleteFileAsync(id);
            return new ApiResult {Success = true};
        }
    }
}