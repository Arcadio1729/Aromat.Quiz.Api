using Aromat.Upload.Api.Model;
using Aromat.Upload.Api.Model.Dto;
using Aromat.Upload.Api.Service;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
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
    [ApiController]
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
        [Route("upload-file-form")]
        public ActionResult UploadFiles(IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fileDto = this._mapper.Map<UploadFileDto>(file);

            var result = this._fileService.CreateFileDb(fileDto);
            return Ok(result);
        }


        [HttpPost]
        [Route("upload-file-body")]
        public ActionResult UploadFiles([FromBody]UploadFileDto fileDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = this._fileService.CreateFileDb(fileDto);
            return Ok(result);
        }

        [HttpPost]
        [Route("upload-files-db")]
        public ActionResult UploadFiles([FromForm]List<IFormFile> files)
        {
            var filesDtos = this._mapper.Map<List<UploadFileDto>>(files);

            this._fileService.CreateFilesDb(filesDtos);
            return Ok();
        }

        [HttpGet]
        [Route("download")]
        public ActionResult GetFile([FromBody]int id)
        {
            byte[] img = this._fileService.GetFile(id);
            return File(img, "image/png");
        }
    
        [HttpGet]
        [Route("download-test")]
        public IEnumerable<Person> TestGet()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Person
            {
                Name = "Mr",
                Age = rng.Next(0, 99)
            })
            .ToArray();
        }
    }
}
