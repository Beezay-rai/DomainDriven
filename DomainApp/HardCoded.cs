using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using System.IO;

namespace DomainApp.HardCoded
{

    public class HardCoded
    {
        public void Generate()
        {
            const string OpenApiFilePath = "C:\\Users\\OnePoint-bijay\\source\\repos\\DomainApp\\DomainApp\\openapi.json";
            const string DllFilePath = "C:\\Users\\OnePoint-bijay\\source\\repos\\DomainApp\\Exterior\\bin\\Debug\\net8.0\\Exterior.dll";

            var document = new Microsoft.OpenApi.Models.OpenApiDocument()
            {
                Info = new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1",
                    Description = "API documentation generated manually",
                    Contact = new OpenApiContact
                    {
                        Name = "Your Name",
                        Email = "your.email@example.com",
                        Url = new System.Uri("https://example.com")
                    }
                },
                Paths = new OpenApiPaths
                {
                    ["/api/v1/notification/send"] = new OpenApiPathItem
                    {
                        Operations = new Dictionary<OperationType, OpenApiOperation>
                        {
                            {
                                OperationType.Post, new OpenApiOperation
                                {
                                    Tags = new List<OpenApiTag>
                                    {
                                        new OpenApiTag { Name = "FonePay" }
                                    },
                                    RequestBody = new OpenApiRequestBody
                                    {
                                        Content = new Dictionary<string, OpenApiMediaType>
                                        {
                                            {
                                                "application/json", new OpenApiMediaType
                                                {
                                                    Schema = new OpenApiSchema
                                                    {
                                                        Reference = new OpenApiReference
                                                        {
                                                            Type = ReferenceType.Schema,
                                                            Id = "FonePayNotificationRequestModel"
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    },
                                    Responses = new OpenApiResponses
                                    {
                                        {
                                            "429", new OpenApiResponse
                                            {
                                                Description = "Success",
                                                Content = new Dictionary<string, OpenApiMediaType>
                                                {
                                                    {
                                                        "application/json", new OpenApiMediaType
                                                        {
                                                            Schema = new OpenApiSchema
                                                            {
                                                                Reference = new OpenApiReference
                                                                {
                                                                    Type = ReferenceType.Schema,
                                                                    Id = "FonePayErrorModel"
                                                                }
                                                            },
                                                            Example = new OpenApiObject
                                                            {
                                                                ["timestamp"] = new OpenApiString("21/11/2024 11:16:15 AM"),
                                                                ["status"] = new OpenApiInteger(200),
                                                                ["error"] = new OpenApiString("Success"),
                                                                ["message"] = new OpenApiString("Request successful"),
                                                                ["path"] = new OpenApiString(null)
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                        {
                                            "400", new OpenApiResponse
                                            {
                                                Description = "Bad Request",
                                                Content = new Dictionary<string, OpenApiMediaType>
                                                {
                                                    {
                                                        "application/json", new OpenApiMediaType
                                                        {
                                                            Schema = new OpenApiSchema
                                                            {
                                                                Reference = new OpenApiReference
                                                                {
                                                                    Type = ReferenceType.Schema,
                                                                    Id = "FonePayErrorModel"
                                                                }
                                                            },
                                                            Example = new OpenApiObject
                                                            {
                                                                ["timestamp"] = new OpenApiString("21/11/2024 5:01:15 PM"),
                                                                ["status"] = new OpenApiInteger(400),
                                                                ["error"] = new OpenApiString("Bad Request"),
                                                                ["message"] = new OpenApiString("Validation Error"),
                                                                ["path"] = new OpenApiString(null)
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        },
                                    }
                                }
                            }
                        }
                    }
                },
                Components = new OpenApiComponents
                {
                    Schemas = new Dictionary<string, OpenApiSchema>
                    {
                        {
                            "FonePayErrorModel", new OpenApiSchema
                            {
                                Type = "object",
                                Properties = new Dictionary<string, OpenApiSchema>
                                {
                                    { "timestamp", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "status", new OpenApiSchema { Type = "integer" } },
                                    { "error", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "message", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "path", new OpenApiSchema { Type = "string", Nullable = true } }
                                }
                            }
                        },
                        {
                            "FonePayNotificationRequestModel", new OpenApiSchema
                            {
                                Type = "object",
                                Properties = new Dictionary<string, OpenApiSchema>
                                {
                                    { "mobileNumber", new OpenApiSchema { Type = "string", MinLength = 2 } },
                                    { "remark1", new OpenApiSchema { Type = "string", MaxLength = 5, Nullable = true } },
                                    { "retrievalReferenceNumber", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "amount", new OpenApiSchema { Type = "string" } },
                                    { "merchantId", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "terminalId", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "type", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "uniqueId", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "properties", new OpenApiSchema
                                      {
                                          Type = "object",
                                            Reference = new OpenApiReference()
                                            {
                                                Type =ReferenceType.Schema,
                                                Id="FonePayNotificationRequestProp"
                                            }
                                      }
                                    }
                                }
                            }
                        },
                        {
                            "FonePayNotificationRequestProp", new OpenApiSchema
                            {
                               Type = "object",
                                Properties = new Dictionary<string, OpenApiSchema>
                                {
                                    { "txnDate", new OpenApiSchema { Type = "string", Format = "date-time" } },
                                    { "secondaryMobileNumber", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "email", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "sessionSrlNo", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "commission", new OpenApiSchema { Type = "string", Nullable = true } },
                                    { "initiator", new OpenApiSchema { Type = "string", Nullable = true } }
                                }
                            }
                        }
                    }
                }
            };

            using (var stream = new FileStream(OpenApiFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                var writer = new OpenApiJsonWriter(new StreamWriter(stream));
                document.SerializeAsV3(writer);
                writer.Flush();
            }

        }

    }
}
