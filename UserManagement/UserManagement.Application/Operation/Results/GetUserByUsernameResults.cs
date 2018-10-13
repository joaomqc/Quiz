namespace UserManagement.Application.Operation.Results
{
    using Shared.Operation;

    public class GetUserByUsernameResults : IResult
    {
        public GetUserByUsernameResults(
            int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
