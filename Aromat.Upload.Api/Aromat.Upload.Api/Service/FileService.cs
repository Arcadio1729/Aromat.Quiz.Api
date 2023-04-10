using Aromat.Upload.Api.Exceptions;
using Aromat.Upload.Api.Model;
using Aromat.Upload.Api.Model.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly ILogger<FileService> _logger;

        public FileService(UploadDbContext context, ILogger<FileService> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        public byte[] GetFile(int id)
        {
            var data = this._context.FileData.FirstOrDefault(x=>x.Id==id).Data;

            if (data is null)
                throw new NotFoundException("File not found");

            return data;
        }
        public IEnumerable<byte[]> GetFiles(List<int> filesId)
        {
            List<byte[]> files = new List<byte[]>();

            foreach(var id in filesId)
            {
                var currentFile = this._context.FileData.FirstOrDefault(x => x.Id == id).Data;

                if (currentFile is null)
                    throw new NotFoundException($"File with {id} not found");

                files.Add(currentFile);
            }

            return files;
        }
        public string CreateFileDb(UploadFileDto file)
        {
            FileData f = new FileData()
            {
                Data = file.Data
            };

            this._context.FileData.Add(f);
            this._context.SaveChanges();

            UploadedFileDto dto = new UploadedFileDto 
            { 
                Data = f.Data,
                Id=f.Id
            };

            var json = JsonConvert.SerializeObject(dto);

            this._logger.LogInformation($"info - {DateTime.Now} - Id: {dto.Id}");
            this._logger.LogTrace($"trace - {DateTime.Now} - Id: {dto.Id}");

            return json;
        }
        public void CreateFilesDb(List<UploadFileDto> filesDtos)
        {
            foreach(var fd in filesDtos)
            {
                FileData f = new FileData()
                {
                    Data = fd.Data
                };

                this._context.FileData.Add(f);
                this._context.SaveChanges();
            }
        }

    }
}
