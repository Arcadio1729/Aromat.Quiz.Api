using Aromat.Upload.Api.Model;
using Aromat.Upload.Api.Model.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Service
{
    public class FileService : IFileService
    {
        private readonly UploadDbContext _context;

        public FileService(UploadDbContext context)
        {
            this._context = context;
        }

        public byte[] GetImage()
        {
            return this._context.FilesData.FirstOrDefault().Data;
        }

        public void UploadFilesDb(List<UploadFileDto> filesDtos)
        {
            foreach(var fd in filesDtos)
            {
                FileData f = new FileData()
                {
                    Data = fd.Data,
                    FileDetails = new FileDetails()
                    {
                        Extension = fd.Extension,
                        Title = fd.Title
                    }
                };
                this._context.FilesData.Add(f);
                this._context.SaveChanges();
            }
        }

        //public void UploadFilesDb(List<IFormFile> files)
        //{
        //    files.ForEach(file=>
        //    {
        //        Image img = new Image();

        //        if (file.Length <= 0) return;

        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            file.CopyToAsync(ms);
        //            img.ImageData = ms.ToArray();
        //            this._context.Images.Add(img);
        //            this._context.SaveChanges();
        //        }
        //    });
        //}
    }
}
