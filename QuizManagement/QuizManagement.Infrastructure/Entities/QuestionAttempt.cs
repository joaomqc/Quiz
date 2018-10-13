namespace QuizManagement.Infrastructure.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class QuestionAttempt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int QuizAttemptId { get; set; }

        [Required]
        public int QuestionId { get; set; }

        [Required]
        public bool IsCorrect { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public virtual Question Question { get; set; }

        [ForeignKey(nameof(QuizAttemptId))]
        public virtual QuizAttempt QuizAttempt { get; set; }

        public virtual IEnumerable<AnswerAttempt> AnswerAttempts { get; set; }
    }
}
