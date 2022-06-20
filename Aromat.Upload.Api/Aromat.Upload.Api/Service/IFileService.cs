using Aromat.Upload.Api.Model;
using Aromat.Upload.Api.Model.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Service
{
    public interface IFileService
    {
        byte[] GetFile(int id);
        IEnumerable<byte[]> GetFiles(List<int> filesId);
        void CreateFileDb(UploadFileDto file);
        void CreateFilesDb(List<UploadFileDto> files);
    }
}
