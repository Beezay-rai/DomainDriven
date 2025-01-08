using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using OnePoint.PDK.Data;
using OnePoint.PDK.Models;
using OnePoint.PDK.Repository;
using OnePoint.PDK.Schema;
using Yarp.ReverseProxy.Transforms;

namespace OnePoint.PDK.Handler
{
    public abstract class CustomHandler
    {
        protected CustomSchema _schema;
        protected CustomRepository _repo;
        protected CustomHandler(CustomSchema schema, CustomRepository repo)
        {
            _schema = schema;
            _repo = repo;
        }

        public abstract Task<ConfigurationResult> Configure(ConfigurationModel config);

        public abstract Task<CircuitBreakerModel> PreAsync(HttpContext context, ConfigurationModel config);

        public abstract Task RequestTransfromAsync(RequestTransformContext context, ConfigurationModel config);
    }
}
