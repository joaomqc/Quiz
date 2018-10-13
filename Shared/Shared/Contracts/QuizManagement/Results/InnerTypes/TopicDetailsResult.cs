namespace Shared.Contracts.QuizManagement.Results.InnerTypes
{
    public class TopicDetailsResult
    {
        public TopicDetailsResult(
            int id,
            string name,
            string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
    }
}
