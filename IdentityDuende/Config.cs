using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace IdentityServerAspNetIdentity;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
           new IdentityResources.OpenId(),
           new IdentityResources.Profile(),
           new IdentityResources.Email(),
           new IdentityResource
        {
            Name = "custom",
            DisplayName = "Custom Identity Resource",
            UserClaims = { "custom" }
        }
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
           new ApiScope("SampleAPI")
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            // Swagger client
            new Client
            {
                ClientId = "api_postman",
                ClientName = "Postman UI for Sample API",
                ClientSecrets = {new Secret("secret".Sha256())},

                AllowedGrantTypes = GrantTypes.Code,

                RedirectUris = {"https://localhost:7170/swagger/oauth2-redirect.html"},
                AllowedCorsOrigins = {"https://localhost:7170"},
                AllowedScopes = { "SampleAPI","openid"}
            }
        };
}
