using Aromat.Upload.Api.Model.Dto;
using Aromat.Upload.Api.Service;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Controllers
{
    [Route("api")]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        private IMapper _mapper;

        public FileController(IFileService fileService,IMapper mapper)
        {
            this._fileService = fileService;
            this._mapper = mapper;
        }


        [HttpPost]
        [Route("upload-db")]
        public ActionResult UploadFiles([FromForm]List<IFormFile> files)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var filesDtos = this._mapper.Map<List<UploadFileDto>>(files);

            this._fileService.UploadFilesDb(filesDtos);
            return Ok();
        }

        [HttpGet]
        [Route("download")]
        public ActionResult GetFile()
        {
            byte[] img = this._fileService.GetImage();
            return File(img, "image/png");
        }

    }
}
