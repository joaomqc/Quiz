namespace Authentication.Api.Configuration
{
    using System.Collections.Generic;
    using IdentityServer4.Models;

    internal class Clients
    {
        public static IEnumerable<Client> Get(string clientSecret)
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "microServices",
                    ClientName = "Micro Services",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret(clientSecret.Sha512())
                    },
                    AllowedScopes = new List<string>
                    {
                        "microServices"
                    }
                }
            };
        }
    }
}
