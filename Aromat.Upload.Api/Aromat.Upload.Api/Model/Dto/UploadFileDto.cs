using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Model.Dto
{
    public class UploadFileDto
    {
        public byte[] Data { get; set; }
        public string Extension { get; set; }
        public string Title { get; set; }
    }
}
