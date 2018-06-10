using System;
using System.IO;
using System.Threading.Tasks;
using Kurs.Core.Domain;
using Microsoft.AspNetCore.Http;

namespace Kurs.Services.Note
{
    public interface INoteFileService
    {
        Task<NoteFile> UploadFileAsync(Guid noteId, IFormFile formFile);
        Task<Stream> GetFileDataAsync(Guid noteFileId);
        Task DeleteFileAsync(Guid noteFileId);
    }
}