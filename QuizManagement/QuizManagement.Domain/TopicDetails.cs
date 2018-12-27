namespace QuizManagement.Domain
{
    public class TopicDetails
    {
        public TopicDetails(
            int id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }
}
