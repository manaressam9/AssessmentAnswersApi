using System.ComponentModel.DataAnnotations;

namespace AssessmentAnswers.Models
{
    public class Assessment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<AssesTrueFalse> AssesTrueFalses { get; set; }
        public ICollection<AssesAnswer> AssesAnswers { get; set; }

    }
}
