namespace QuizManagement.Application.Operation.Results
{
    using Shared.Operation;

    public class GetTopicByIdResults : IResult
    {
        public GetTopicByIdResults(
            int id,
            string name,
            string description,
            string url)
        {
            Id = id;
            Name = name;
            Description = description;
            Url = url;
        }

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string Url { get; }
    }
}
