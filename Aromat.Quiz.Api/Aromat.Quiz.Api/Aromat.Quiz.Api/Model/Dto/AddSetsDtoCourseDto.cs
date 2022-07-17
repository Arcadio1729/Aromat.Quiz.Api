using System.Collections.Generic;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class AddSetsToCourseDto
    {
        public int CourseId { get; set; }
        public List<SetDto> Sets { get; set; }
    }
}