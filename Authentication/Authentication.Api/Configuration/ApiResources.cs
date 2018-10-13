namespace Authentication.Api.Configuration
{
    using System.Collections.Generic;
    using IdentityServer4.Models;

    public static class ApiResources
    {
        public static IEnumerable<ApiResource> Get()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "microService",
                    DisplayName = "Micro Service",
                    Scopes =
                    {
                        new Scope
                        {
                            Name = "microServices",
                            DisplayName = "Micro Services"
                        }
                    }
                }
            };
        }
    }
}
