namespace UserManagement.Application.Operation.Parameters
{
    using Shared.Operation;

    public class GetUserByIdParameters : IParameter
    {
        public GetUserByIdParameters(
            int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
