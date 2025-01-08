using Microsoft.AspNetCore.Http;
using OnePoint.PDK.Models;
using OnePoint.PDK.Repository;
using OnePoint.PDK.Schema;

namespace OnePoint.PDK.Authenticator
{
    public abstract class CustomAuthenticator
    {
        protected CustomSchema _schema;
        protected CustomRepository _repo;
        protected CustomAuthenticator(CustomSchema schema, CustomRepository repo)
        {
            _schema = schema;
            _repo = repo;
        }
        public abstract Task<CustomAuthenticationResult> AuthenticateAsync(HttpContext context, ConfigurationModel configuration);

    }
}
