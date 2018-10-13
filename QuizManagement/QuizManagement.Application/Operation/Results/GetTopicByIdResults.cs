namespace QuizManagement.Application.Operation.Results
{
    using Shared.Operation;

    public class GetTopicByIdResults : IResult
    {
        public GetTopicByIdResults(
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
