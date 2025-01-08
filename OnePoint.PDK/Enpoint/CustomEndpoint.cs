using Microsoft.AspNetCore.Http;
using OnePoint.PDK.Repository;
using OnePoint.PDK.Schema;

namespace OnePoint.PDK.Enpoint
{
    public abstract class CustomEndpoint
    {
        protected CustomEndpoint(CustomSchema schema, CustomRepository repository)
        {

        }
        public abstract Task Execute(HttpContext context);
    }
}
