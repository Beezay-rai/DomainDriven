using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace MyWebApp2.Helper
{
    public class test : ISchemaGenerator
    {
        public OpenApiSchema GenerateSchema(Type modelType, SchemaRepository schemaRepository, MemberInfo memberInfo = null, ParameterInfo parameterInfo = null, ApiParameterRouteInfo routeInfo = null)
        {
            throw new NotImplementedException();
        }
    }
}
