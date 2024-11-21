using DomainApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using MyWebApp2.Custom;
using OnePoint.PDK.CustomAttribute;
using OnePoint.PDK.Enpoint;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace MyWebApp2.Helper
{
    public class MyCustomDocument : IDocumentFilter
    {
        private readonly IConfiguration _config;
        public MyCustomDocument(IConfiguration config)
        {
            _config = config;
        }

        public class Abc
        {
            public string Messaged { get; set; }
            public string Test { get; set; }
        }
        public void Apply(OpenApiDocument Noice, DocumentFilterContext context)
        {

            var schema = context.SchemaGenerator.GenerateSchema(typeof(Abc), context.SchemaRepository);
            context.SchemaRepository.Schemas.Add("MyCustomType", schema);

            string OpenApiFilePath = _config.GetSection("OpenApiFilePath").Value;


            var baseDllPath = _config.GetSection("DllPath").Value;
            foreach (var dllPath in Directory.GetFiles(baseDllPath, "*.dll"))
            {
                try
                {
                    var assembly = Assembly.LoadFrom(dllPath);
                    var endpointTypes = assembly.GetTypes()
                              .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(CustomEndpoint)))
                              .ToList();

                    var schemas = assembly.GetTypes()
                              .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(CustomComponent)))
                              .ToList();


                    foreach(var test in schemas)
                    {
                        var OpenApischema = context.SchemaGenerator.GenerateSchema(test, context.SchemaRepository);
                        if (!context.SchemaRepository.Schemas.ContainsKey(test.Name)){

                        context.SchemaRepository.Schemas.Add(test.Name, OpenApischema);
                        }
                    }


                    if (Noice.Components == null)
                    {
                        Noice.Components = new OpenApiComponents();
                    }

                    //Noice.Components.Schemas = OpenApiHelper.GenerateSchemas(schemas);


                    var controllersList = assembly.GetTypes()
                              .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ControllerBase)))
                              .ToList();
                    if (Noice.Paths == null)
                        Noice.Paths = new OpenApiPaths();

                    foreach (var endpointType in endpointTypes)
                    {
                        var customEndpointAttribute = endpointType.GetCustomAttributes<CustomEndpointAttribute>().FirstOrDefault();

                        if (customEndpointAttribute != null)
                        {
                            var path = customEndpointAttribute.Path.Replace("[controller]", endpointType.Name.Replace("Controller", ""));

                            var methods = endpointType.GetMethod("Execute");

                            var httpMethodAttr = customEndpointAttribute.Method.ToUpper();
                            OperationType operationType = httpMethodAttr switch
                            {
                                "GET" => OperationType.Get,
                                "POST" => OperationType.Post,
                                "PUT" => OperationType.Put,
                                "Delete" => OperationType.Delete,
                                _ => throw new NotImplementedException($"Unsupported HTTP verb: {httpMethodAttr.GetType().Name}")
                            };

                            if (!Noice.Paths.ContainsKey(path))
                            {
                                Noice.Paths.Add(path, new OpenApiPathItem());
                            }




                            var consume = endpointType.GetCustomAttributes<CustomConsume>();

                            var openApiRequest = OpenApiHelper.GenerateOpenApiRequest(consume);

                            var responses = endpointType.GetCustomAttributes<CustomProduceResponseTypeAttribute>();





                            var openApiResponses = OpenApiHelper.GenerateOpenApiResponses(responses);


                            Noice.Paths[path].Operations[operationType] = new OpenApiOperation()
                            {
                                Responses = openApiResponses,
                                RequestBody = openApiRequest,
                                Tags = new List<OpenApiTag> { new OpenApiTag { Name = endpointType.Name.Replace("Controller", "") } }
                            };
                        }
                    }





                    using (var stream = new FileStream(OpenApiFilePath, FileMode.Open, FileAccess.ReadWrite))
                    {
                        var writer = new OpenApiJsonWriter(new StreamWriter(stream));
                        Noice.SerializeAsV3(writer);
                        writer.Flush();
                    }

                }
                catch (Exception ex)
                {
                }
            }









        }
    }
}
