using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace DomainApp.Interface
{
    public interface IExampleProvider<T> where T : class
    {
        public T GetExamples();
    }


    public class SchemaGnerator : ISchemaGenerator
    {
        public OpenApiSchema GenerateSchema(Type modelType, SchemaRepository schemaRepository, MemberInfo memberInfo = null, ParameterInfo parameterInfo = null, ApiParameterRouteInfo routeInfo = null)
        {
            
            throw new NotImplementedException();
        }
    }
}
