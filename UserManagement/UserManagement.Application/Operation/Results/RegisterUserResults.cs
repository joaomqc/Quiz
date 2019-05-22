namespace UserManagement.Application.Operation.Results
{
    using Shared.Operation;

    public class RegisterUserResults : IResult
    {
        public RegisterUserResults(
            bool succeeded)
        {
            Succeeded = succeeded;
        }

        public bool Succeeded { get; }
    }
}
