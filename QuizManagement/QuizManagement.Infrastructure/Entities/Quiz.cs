namespace QuizManagement.Infrastructure.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreationTimestamp { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public bool IsPublic { get; set; }
        
        [Required]
        public int TopicId { get; set; }
        
        [ForeignKey(nameof(TopicId))]
        public virtual Topic Topic { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }

        public virtual IEnumerable<Question> Questions { get; set; }
    }
}
