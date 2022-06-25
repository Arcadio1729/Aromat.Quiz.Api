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
                .ForMember(q => q.ImageContent, dto => dto.MapFrom(x => x.Item1.ImageContent))
                .ForMember(q => q.LatexContent, dto => dto.MapFrom(x => x.Item1.LatexContent))
                .ForMember(q => q.QuestionsDetails, dto => dto.MapFrom(x => new
                {

                }));

        }
    }
}
