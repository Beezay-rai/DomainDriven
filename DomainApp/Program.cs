using DomainApp;
using DomainApp.Custom;
using DomainApp.HardCoded;
using DomainApp.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Writers;
using OnePoint.PDK.CustomAttribute;
using OnePoint.PDK.Enpoint;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;
public class Program
{
    public static void Main(string[] args)
    {
        #region Pattern Learning
        //#region AbstractFactoryPattern

        //IFurnitureFactory factory;
        //string chairType = "Old";
        //switch (chairType)
        //{
        //    case "Modern":
        //        factory = new ModernFurnitureFactory();
        //        break;
        //    case "Old":
        //        factory = new OldFurnitureFactory();
        //        break;
        //    default:
        //        factory = new ModernFurnitureFactory();
        //        break;

        //}
        //Console.WriteLine(factory.GetChairDescription());

        //#endregion


        //#region FactoryPattern
        //GetShoeFactory myFactory = new GetShoeFactory("Nike");
        //var shoeFactory = myFactory.MyFactory();
        //var shoeName = shoeFactory.GetShoeName();
        //Console.WriteLine(shoeName);
        //#endregion

        //#region BridgePattern
        //var circle = new Circle(new RedColor());
        //circle.DrawShape();

        //#endregion


        //#region Adapter Pattern
        //IBasicPlayer basicPlayer = new Mp3();
        //basicPlayer.Play();

        //IAdvancePlayer mp4Player = new Mp4();

        //IBasicPlayer adapter = new BasicPlayerAdapter(mp4Player);
        //adapter.Play();
        //#endregion


        //#region Builder Pattern
        //IComputerBuilder compBuilder = new ComputerBuilder();
        //compBuilder.SetGraphics("MyGrapgics");
        //var computer = compBuilder.BuildComputer();
        //Console.WriteLine(computer.Graphics);
        //Console.WriteLine(computer.Ram);
        //Console.WriteLine(string.IsNullOrEmpty(computer.Model) ? "Model NOt Defined" : computer.Model);
        //compBuilder.SetModel("myModel");
        //Console.WriteLine(string.IsNullOrEmpty(computer.Model) ? "Model NOt Defined" : computer.Model);
        //#endregion


        //#region CompositePattern

        //var ProductComposite = new ProductComposite();
        //IProduct toy = new Toy();
        //IProduct Bat = new Bat();
        //ProductComposite.Add(toy);
        //ProductComposite.Add(Bat);
        //Console.WriteLine(ProductComposite.ProductDescription());

        //#endregion


        //#region DecoratorPattern
        //ICoffee coffe = new SimpleCoffee();
        //Console.WriteLine("Coffe without Sugar :" + coffe.GetCost());
        //coffe = new SugarDecorator(coffe);
        //Console.WriteLine("Coffe With Sugar :" + coffe.GetCost());

        //#endregion
        #endregion

        //const string OpenApiFilePath = "C:\\Users\\OnePoint-bijay\\source\\repos\\DomainApp\\DomainApp\\openapi.json";
        //const string DllFilePath = "C:\\Users\\OnePoint-bijay\\source\\repos\\DomainApp\\Exterior\\bin\\Debug\\net8.0\\Exterior.dll";


        //using (var stream = new FileStream(OpenApiFilePath, FileMode.Open, FileAccess.ReadWrite))
        //{

        //    //OpenApiDocument openApiDocument = new OpenApiStreamReader().Read(stream, out var openApiDiagnostic);
        //    OpenApiDocument openApiDocument = new OpenApiDocument();

        //    var assembly = Assembly.LoadFrom(DllFilePath);
        //    var endpointTypes = assembly.GetTypes()
        //              .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(CustomEndpoint)))
        //              .ToList();

        //    var schemas = assembly.GetTypes()
        //              .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(CustomComponent)))
        //              .ToList();

        //    if (openApiDocument.Components == null)
        //    {
        //        openApiDocument.Components = new OpenApiComponents();
        //    }


        //    openApiDocument.Components.Schemas = OpenApiHelper.GenerateSchemas(schemas);


        //    var controllersList = assembly.GetTypes()
        //              .Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(ControllerBase)))
        //              .ToList();
        //    if (openApiDocument.Paths == null)
        //        openApiDocument.Paths = new OpenApiPaths();

        //    foreach (var endpointType in endpointTypes)
        //    {
        //        var customEndpointAttribute = endpointType.GetCustomAttributes<CustomEndpointAttribute>().FirstOrDefault();

        //        if (customEndpointAttribute != null)
        //        {
        //            var path = customEndpointAttribute.Path.Replace("[controller]", endpointType.Name.Replace("Controller", ""));

        //            var methods = endpointType.GetMethod("Execute");

        //            var httpMethodAttr = customEndpointAttribute.Method.ToUpper();
        //            OperationType operationType = httpMethodAttr switch
        //            {
        //                "GET" => OperationType.Get,
        //                "POST" => OperationType.Post,
        //                "PUT" => OperationType.Put,
        //                "Delete" => OperationType.Delete,
        //                _ => throw new NotImplementedException($"Unsupported HTTP verb: {httpMethodAttr.GetType().Name}")
        //            };

        //            if (!openApiDocument.Paths.ContainsKey(path))
        //            {
        //                openApiDocument.Paths.Add(path, new OpenApiPathItem());
        //            }




        //            var consume = endpointType.GetCustomAttributes<CustomConsume>();

        //            var openApiRequest = OpenApiHelper.GenerateOpenApiRequest(consume);

        //            var responses = endpointType.GetCustomAttributes<CustomProduceResponseTypeAttribute>();





        //            var openApiResponses = OpenApiHelper.GenerateOpenApiResponses(responses);


        //            openApiDocument.Paths[path].Operations[operationType] = new OpenApiOperation()
        //            {
        //                Responses = openApiResponses,
        //                RequestBody = openApiRequest,
        //                Tags = new List<OpenApiTag> { new OpenApiTag { Name = endpointType.Name.Replace("Controller", "") } }
        //            };
        //        }
        //    }





        //    var writer = new OpenApiJsonWriter(new StreamWriter(stream));
        //    openApiDocument.SerializeAsV3(writer);
        //    writer.Flush();



        //    //var openAPIErrors = openApiDocument.Validate(ValidationRuleSet.GetDefaultRuleSet());
        //    //if (openAPIErrors.Count()>0)
        //    //{

        //    //    foreach (var error in openAPIErrors)
        //    //    {
        //    //        Console.WriteLine("Error Occured In "+ error.Pointer );
        //    //        Console.WriteLine(error.Message);
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    using (var stream2 = new FileStream(OpenApiFilePath, FileMode.Open))
        //    //    {
        //    //        var writer = new OpenApiJsonWriter(new StreamWriter(stream2));
        //    //        openApiDocument.SerializeAsV3(writer);
        //    //        writer.Flush();

        //    //    }



        //    //}




        //}

        //var serviceCollection = new ServiceCollection();
        //serviceCollection.AddSwaggerGen(options =>
        //{
        //    options.DocumentFilter<MyCustomDocument>();
        //    // Add basic Swagger document settings
        //    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        //    {
        //        Title = "Console App API",
        //        Version = "v1",
        //        Description = "Swagger documentation generated from a console app"
        //    });
        //    var serviceProvider = serviceCollection.BuildServiceProvider();
        //    var swaggerGen = serviceProvider.GetRequiredService<ISwaggerProvider>();
        //    var swaggerDoc = swaggerGen.GetSwagger("v1");
        //    using (var writer = new StreamWriter(OpenApiFilePath))
        //    {
        //        var json = System.Text.Json.JsonSerializer.Serialize(swaggerDoc, new System.Text.Json.JsonSerializerOptions
        //        {
        //            WriteIndented = true
        //        });
        //        writer.Write(json);
        //    }

        //});


        var hardcoded = new HardCoded();
        hardcoded.Generate();

    }




}