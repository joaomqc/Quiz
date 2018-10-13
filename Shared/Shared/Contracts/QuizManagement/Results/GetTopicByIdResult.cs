namespace Shared.Contracts.QuizManagement.Results
{
    public class GetTopicByIdResult
    {
        public GetTopicByIdResult(
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
