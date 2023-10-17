using System.ComponentModel.DataAnnotations;

namespace AssessmentAnswers.Models
{
    public class AssesTrueFalse
    {
        [Key]
        public int Id { get; set; } 
        public string Text { get; set; }

        public bool IsTrue { get; set; }

        public int AssesId { get; set; }
        //public Assessment Assessment { get; set; } = null!;
        //public AssesAnswer AssesAnswer { get; set; } = null!;
      
    }
}
