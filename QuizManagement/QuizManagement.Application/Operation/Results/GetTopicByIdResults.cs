namespace QuizManagement.Application.Operation.Results
{
    using Shared.Operation;

    public class GetTopicByIdResults : IResult
    {
        public GetTopicByIdResults(
            int id,
            string name,
            string description,
            string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }

        public int Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string ImageUrl { get; }
    }
}
