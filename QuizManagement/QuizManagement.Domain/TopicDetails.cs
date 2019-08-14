namespace QuizManagement.Domain
{
    public class TopicDetails
    {
        public TopicDetails(
            int id,
            string name,
            string imageUrl)
        {
            Id = id;
            Name = name;
            ImageUrl = imageUrl;
        }

        public int Id { get; }
        public string Name { get; }
        public string ImageUrl { get; }
    }
}
