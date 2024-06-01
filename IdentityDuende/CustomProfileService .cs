using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityDuende.Data.Migrations;
using IdentityModel;
using System.Security.Claims;

namespace IdentityDuende
{
    public class CustomProfileService : IProfileService
    {
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // Assuming you get the "custom" claim value from a user store or some other source
            // Check if the request is for an ID token and include the email claim only in that case
            var claims = new List<Claim>();
            
            claims.Add(new Claim("custom", "your_custom_value")); // Add email claim
            claims.Add(new Claim("email", "your_custom_value")); // Add other necessary claims
            

            context.IssuedClaims.AddRange(claims);
            return Task.CompletedTask;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            // Here you can determine if the user is active or not
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
