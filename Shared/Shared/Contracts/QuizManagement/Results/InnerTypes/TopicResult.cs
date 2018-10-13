namespace Shared.Contracts.QuizManagement.Results.InnerTypes
{
    public class TopicResult
    {
        public TopicResult(
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
