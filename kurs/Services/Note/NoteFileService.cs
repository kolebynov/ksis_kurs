using Kurs.Core.Data;
using Kurs.Core.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using Kurs.Core.Extensions;

namespace Kurs.Services.Note
{
    public class NoteFileService : INoteFileService
    {
        private readonly IRepository<NoteFile> _noteFilesRepository;

        public NoteFileService(IRepository<NoteFile> noteFilesRepository)
        {
            _noteFilesRepository = noteFilesRepository;
        }

        public async Task<NoteFile> UploadFileAsync(Guid noteId, IFormFile formFile)
        {
            return await _noteFilesRepository.AddAsync(new NoteFile
            {
                Id = Guid.NewGuid(),
                NoteId = noteId,
                ContentType = formFile.ContentType,
                FileName = formFile.FileName,
                Length = formFile.Length,
                Data = await formFile.OpenReadStream().ReadAllBytesAsync()
            });
        }

        public async Task<Stream> GetFileDataAsync(Guid noteFileId) =>
            new MemoryStream((await _noteFilesRepository.GetByIdAsync(noteFileId)).Data);

        public async Task DeleteFileAsync(Guid noteFileId)
        {
            await _noteFilesRepository.DeleteAsync(noteFileId);
        }
    }
}