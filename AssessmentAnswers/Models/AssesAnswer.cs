using System.ComponentModel.DataAnnotations;

namespace AssessmentAnswers.Models
{
    public class AssesAnswer
    {
        [Key]
        public int Id { get; set; } 
        public string Answer { get; set; }
        public int UserId { get; set; }
       // public User User { get; set; } = null!;
        public int AssesId { get; set; }
      //  public Assessment Assessment { get; set; } = null!;
        public int AssesTrueFalseId { get; set; }
      //  public AssesTrueFalse AssesTrueFalses { get; set; }

    }
}
