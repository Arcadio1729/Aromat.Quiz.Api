using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aromat.Quiz.Api.Model;
using Aromat.Quiz.Api.Model.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Http;
namespace Aromat.Quiz.Api
{
    public class QuestionMappingProfile : Profile
    {
        private readonly QuizDbContext _context;

        public QuestionMappingProfile(QuizDbContext context)
        {
            this._context = context;

            CreateMap<(CreateQuestionDto, CreateAnswerDto), Question>()
                .ForMember(q => q.FileData.Data, dto => dto.MapFrom(x => x.Item1.QuestionImageId))
                .ForMember(q => q.LatexContent, dto => dto.MapFrom(x => x.Item1.LatexContent))
                .ForMember(q => q.QuestionsDetails, dto => dto.MapFrom(x => new
                {

                }));
        }

        public QuestionMappingProfile()
        {
            CreateMap<CourseDetailsDto, CourseDetails>()
                .ForMember(c => c.Id, dto => dto.MapFrom(x => x.Id))
                .ForMember(c => c.Name, dto => dto.MapFrom(x => x.Name));
        }
    }
}
