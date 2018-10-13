namespace QuizManagement.Infrastructure.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class AnswerAttempt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnswerAttemptId { get; set; }

        [Required]
        public int AnswerId { get; set; }

        [Required]
        public int QuestionAttemptId { get; set; }

        [ForeignKey(nameof(AnswerId))]
        public virtual Answer Answer { get; set; }

        [ForeignKey(nameof(QuestionAttemptId))]
        public virtual QuestionAttempt QuestionAttempt { get; set; }
    }
}
