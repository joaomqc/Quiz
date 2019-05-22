namespace UserManagement.Application.Operation.Parameters
{
    using System;
    using Shared.Operation;

    public class GetUserByExternalIdParameters : IParameter
    {
        public GetUserByExternalIdParameters(
            Guid externalId)
        {
            ExternalId = externalId;
        }

        public Guid ExternalId { get; }
    }
}
