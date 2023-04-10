using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Model.Dto
{
    public class UploadedFileDto
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
    }
}
