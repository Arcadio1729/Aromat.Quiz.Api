using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aromat.Quiz.Api.Model.Dto
{
    public class ReadQuestionDetailsDto
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Content { get; set; }
        public int SubjectId { get; set; }
        public int DegreeId { get; set; }
        public int LevelId { get; set; }
        public int ImageId { get; set; }
    }
}
