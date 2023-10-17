using System.ComponentModel.DataAnnotations;

namespace AssessmentAnswers.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Assessment Assessment { get; set; }
        //public ICollection<AssesAnswer> AssesAnswers { get; set; }

    }
}
