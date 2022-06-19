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
        byte[] GetImage();
        void UploadFileDb(UploadFileDto file);
        void UploadFilesDb(List<UploadFileDto> files);
    }
}
