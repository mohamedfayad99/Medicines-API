using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EMedicineBE.Extentions
{
    public static class IdentityServicesExtentions
    {
        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration config)
        {
            // Retrieve the Tokenkey from configuration and handle potential null or empty values.
            var tokenKey = config["Tokenkey"];
            if (string.IsNullOrWhiteSpace(tokenKey))
            {
                throw new ArgumentNullException("Tokenkey is not configured or is empty in the configuration file.");
            }

            // Convert the tokenKey to a byte array for use with the SymmetricSecurityKey
            var key = Encoding.UTF8.GetBytes(tokenKey);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,  // Signing key should be validated
                       IssuerSigningKey = new SymmetricSecurityKey(key),  // The key used to validate the token's signature
                       ValidateIssuer = false,  // The issuer of the token does not need to be validated
                       ValidateAudience = false  // The audience of the token does not need to be validated
                   };
               });

            return services;
        }
    }
}
