using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Aromat.Upload.Api.Model;
using Aromat.Upload.Api.Model.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Aromat.Upload.Api
{
    public class FileMappingProfile : Profile
    {
        public FileMappingProfile()
        {
            CreateMap<IFormFile, UploadFileDto>()
                .ForMember(m => m.Title, c => c.MapFrom(s => s.FileName))
                .ForMember(m => m.Data, c => c.MapFrom((s, m) =>
                {
                    FileData fd = new FileData();
                    byte[] img;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        s.CopyTo(ms);
                        img = ms.ToArray();
                    }

                    return img;
                }))
                .ForMember(m => m.Extension, c => c.MapFrom(s => Path.GetExtension(s.FileName)));
        }
    }
}
