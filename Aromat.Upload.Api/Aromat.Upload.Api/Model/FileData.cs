using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Upload.Api.Model
{
    public class FileData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public byte[] Data { get; set; }
    }
}
