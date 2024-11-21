using DomainApp.Custom;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Schema.Generation;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.Json;
namespace DomainApp.Helper
{


    public static class OpenApiHelper
    {

        public static IOpenApiAny GenerateExample(string[] content_types, Type responseType)
        {
            IOpenApiAny response;

            if (responseType != null)
            {
                var methodInfo = responseType.GetMethod("GetExamples");
                if (methodInfo == null)
                {
                    response = null;
                    return response;
                }
                object instance = Activator.CreateInstance(responseType);
                var exampleInstance = methodInfo.Invoke(instance, null);

                var type = GetOpenApiType(responseType);
                switch (type)
                {
                    case "array":
                        var array = new OpenApiArray();
                        if (exampleInstance is IEnumerable<object> exampleList)
                        {
                            foreach (var item in exampleList)
                            {
                                array.Add(new OpenApiString(item.ToString()));
                            }
                        }
                        response = array;
                        break;

                    case "integer":
                        response = new OpenApiInteger(Convert.ToInt32(exampleInstance));
                        break;

                    case "string":
                        response = new OpenApiString(exampleInstance.ToString());
                        break;

                    case "object":
                        var openApiObject = new OpenApiObject();
                        var props = exampleInstance.GetType().GetProperties();
                        foreach (var prop in props)
                        {
                            var value = prop.GetValue(exampleInstance);
                            openApiObject[prop.Name] = ConvertToOpenApiAny(value);
                        }
                        response = openApiObject;
                        break;

                    default:
                        response = new OpenApiString("Unknown type");
                        break;
                }


            }
            else
            {
                response = null;
            }


            return response;
        }
        public static string GetOpenApiType(Type type)
        {
            return type == typeof(string) ? "string" :
                   type == typeof(int) ? "integer" :
                   type == typeof(float) ? "number" :
                   type == typeof(bool) ? "boolean" :
                   type == typeof(DateTime) ? "string" :
                   type == typeof(DateTimeOffset) ? "string" :
                   type == typeof(Array) ? "array" :
                   type == typeof(List<>) ? "array" :
                   type == typeof(double) ? "number" : "object";
        }

        public static IOpenApiAny ConvertToOpenApiAny(object value)
        {
            return value switch
            {
                null => new OpenApiNull(),
                int intValue => new OpenApiInteger(intValue),
                double doubleValue => new OpenApiDouble(doubleValue),
                bool boolValue => new OpenApiBoolean(boolValue),
                string stringValue => new OpenApiString(stringValue),
                _ => new OpenApiString(value.ToString())
            };
        }

        public static Dictionary<string, OpenApiMediaType> GenerateResponseForMediaType(string[] content_types, Type responseType, Type? exampleType)
        {
            Dictionary<string, OpenApiMediaType> response = new Dictionary<string, OpenApiMediaType>();

            if (content_types != null)
            {
                foreach (var content_type in content_types)
                {
                    response.Add(content_type,
                                new OpenApiMediaType
                                {
                                    Schema = new OpenApiSchema
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.Schema,
                                            Id = responseType.Name
                                        },

                                    },
                                    Example = OpenApiHelper.GenerateExample(content_types, exampleType)

                                }
                             );
                }

            }
            else
            {
                if (responseType.Name != "Void")
                {
                    response.Add("application/json", new OpenApiMediaType
                    {
                        Schema = new OpenApiSchema
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.Schema,
                                Id = responseType.Name
                            }
                        }
                    });
                }


            }



            return response;

        }


        public static OpenApiResponses GenerateOpenApiResponses(IEnumerable<CustomProduceResponseTypeAttribute> produce_response_type)
        {
            OpenApiResponses response = new OpenApiResponses();
            foreach (var item in produce_response_type)
            {
                var exampleType = item.GetExampleProviderType();
                var contentTypes = item.GetContentTypes();
                var openApiContent = OpenApiHelper.GenerateResponseForMediaType(contentTypes, item.Type, exampleType);
                response.Add(item.StatusCode.ToString(), new OpenApiResponse()
                {
                    Description = item.GetDescription(),
                    Content = openApiContent
                });
            }
            return response;
        }

        public static OpenApiRequestBody GenerateOpenApiRequest(IEnumerable<CustomConsume> consumes)
        {
            OpenApiRequestBody response = new OpenApiRequestBody();
            if (consumes != null)
            {
                foreach (var item in consumes)
                {
                    var contentTypes = item.ContentTypes.Select(x => x).ToArray();
                    response.Content = OpenApiHelper.GenerateResponseForMediaType(contentTypes, item.GetType(), item.GetExampleType());
                }
            }

            return response;
        }





        public static Dictionary<string, OpenApiSchema> GenerateSchemas(List<Type> schemasList)
        {
            var generator = new JSchemaGenerator()
            {
                SchemaLocationHandling=SchemaLocationHandling.Definitions,
                SchemaReferenceHandling=SchemaReferenceHandling.Objects,
                DefaultRequired=Newtonsoft.Json.Required.AllowNull,
                


            };
            Dictionary<string, OpenApiSchema> response = new Dictionary<string, OpenApiSchema>();
            foreach (var schema in schemasList)
            {


                var mySchema = generator.Generate(schema);

                var openApiSchema = ConvertJSchemaToOpenApiSchema(mySchema);

                response.Add(schema.Name, openApiSchema);

            }
            return response;


        }
        public static OpenApiSchema ConvertJSchemaToOpenApiSchema(JSchema jSchema)
        {
            var openApiSchema = new OpenApiSchema();

            if (jSchema.Type.HasValue)
            {
                var (openApiType, nullable) = GetOpenApiType(jSchema.Type.Value);

                openApiSchema.Type = openApiType;
                openApiSchema.Nullable = nullable;
            }

            //if (jSchema.ExtensionData != null && jSchema.ExtensionData.Count > 0)
            //{
            //    openApiSchema.Reference = new OpenApiReference()
            //    {
            //        Type = ReferenceType.Schema,
            //        Id=jSchema.ExtensionData.FirstOrDefault().Value.ToString
            //    };
            //}


            openApiSchema.Format = jSchema.Format;

            if (!string.IsNullOrEmpty(jSchema.Description))
            {
                openApiSchema.Description = jSchema.Description;
            }

            if (jSchema.Default != null)
            {
                openApiSchema.Default = ConvertToOpenApiAny(jSchema.Default);
            }

            if (jSchema.Type == JSchemaType.Object && jSchema.Properties.Count > 0)
            {
                openApiSchema.Properties = jSchema.Properties.ToDictionary(
                    prop => prop.Key,
                    prop => ConvertJSchemaToOpenApiSchema(prop.Value)
                );
            }

            //// Handle required properties
            //if (jSchema.Required != null && jSchema.Required.Count > 0)
            //{
            //    openApiSchema.Required = new HashSet<string>(jSchema.Required);
            //}

            if (jSchema.Type == JSchemaType.Array && jSchema.Items != null && jSchema.Items.Count > 0)
            {
                openApiSchema.Items = ConvertJSchemaToOpenApiSchema(jSchema.Items.First());
            }

            if (jSchema.Enum != null && jSchema.Enum.Count > 0)
            {
                openApiSchema.Enum = jSchema.Enum.Select<JToken, IOpenApiAny>(e =>
                {
                    if (e.Type == JTokenType.String)
                    {
                        return new OpenApiString(e.ToString());
                    }
                    else if (e.Type == JTokenType.Integer)
                    {
                        return new OpenApiInteger((int)e);
                    }
                    else if (e.Type == JTokenType.Float)
                    {
                        return new OpenApiFloat((float)e);
                    }
                    else if (e.Type == JTokenType.Boolean)
                    {
                        return new OpenApiBoolean((bool)e);
                    }
                    else
                    {
                        return new OpenApiString(e.ToString());
                    }
                }).ToList();
            }

            if (jSchema.Minimum.HasValue)
                openApiSchema.Minimum = (decimal?)jSchema.Minimum;

            if (jSchema.Maximum.HasValue)
                openApiSchema.Maximum = (decimal?)jSchema.Maximum;

            if (jSchema.MinimumLength.HasValue)
                openApiSchema.MinLength = (int)jSchema.MinimumLength;

            if (jSchema.MaximumLength.HasValue)
                openApiSchema.MaxLength = (int)jSchema.MaximumLength;

            if (jSchema.Pattern != null)
                openApiSchema.Pattern = jSchema.Pattern;

            if (jSchema.AdditionalProperties != null)
            {
                openApiSchema.AdditionalPropertiesAllowed = true;
                if (jSchema.AdditionalProperties.Type != JSchemaType.None)
                {
                    openApiSchema.AdditionalProperties = ConvertJSchemaToOpenApiSchema(jSchema.AdditionalProperties);
                }
            }

            if (jSchema.AllOf != null && jSchema.AllOf.Count > 0)
            {
                openApiSchema.AllOf = jSchema.AllOf.Select(ConvertJSchemaToOpenApiSchema).ToList();
            }

            if (jSchema.OneOf != null && jSchema.OneOf.Count > 0)
            {
                openApiSchema.OneOf = jSchema.OneOf.Select(ConvertJSchemaToOpenApiSchema).ToList();
            }

            if (jSchema.AnyOf != null && jSchema.AnyOf.Count > 0)
            {
                openApiSchema.AnyOf = jSchema.AnyOf.Select(ConvertJSchemaToOpenApiSchema).ToList();
            }
            return openApiSchema;
        }
        private static OpenApiSchema ConvertToOpenApiSchema(JSchema mySchema)
        {
            var openApiSchema = new OpenApiSchema();

            if (mySchema.Type.HasValue)
            {
                var (openApiType, nullable) = GetOpenApiType(mySchema.Type.Value);
                openApiSchema.Type = openApiType;
                openApiSchema.Nullable = nullable;
            }

            if (mySchema.Properties.Count > 0)
            {
                openApiSchema.Properties = new Dictionary<string, OpenApiSchema>();

                foreach (var property in mySchema.Properties)
                {
                    var propertySchema = ConvertToOpenApiSchema(property.Value);
                    openApiSchema.Properties[property.Key] = propertySchema;
                }
            }

            // Handle required fields (if any)
            if (mySchema.Required.Count > 0)
            {
                openApiSchema.Required = new HashSet<string>(mySchema.Required);
            }

            return openApiSchema;
        }

        public static (string returnType, bool nullable) GetOpenApiType(JSchemaType schemaType)
        {
            var (returnVal, nullable) = ("", false);
            // Map JSchema types to OpenAPI types
            if (schemaType.HasFlag(JSchemaType.Null))
            {

                schemaType = (JSchemaType)((int)schemaType & ~((int)JSchemaType.Null));
                nullable = true;


            }
            returnVal = schemaType switch
            {
                JSchemaType.String => "string",
                JSchemaType.Integer => "integer",
                JSchemaType.Boolean => "boolean",
                JSchemaType.Number => "number",
                JSchemaType.Array => "array",
                JSchemaType.Object => "object",
                _ => "object" // Default to object if type is not recognized
            };

            return (returnVal, nullable);
        }


        public static void Try()
        {
            SchemaGeneratorOptions schemaGeneratorOptions = new SchemaGeneratorOptions()
            {
                
            };
            ISerializerDataContractResolver serializerDataContractResolver = null;

        }
       
    }


    
}
