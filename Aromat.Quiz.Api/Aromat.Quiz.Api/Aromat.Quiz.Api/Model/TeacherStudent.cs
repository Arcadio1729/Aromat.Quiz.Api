using Aromat.Quiz.Api.Model.Authentication;
using System.ComponentModel.DataAnnotations;

namespace Aromat.Quiz.Api.Model
{
    public class TeacherStudent
    {
        [Key]
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
    }
}
