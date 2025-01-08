using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MyWebApp2.Helper;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
    //.AddApplicationPart(Assembly.LoadFrom(builder.Configuration.GetSection("DllPath").Value + "Exterior.dll"));
//    .ConfigureApplicationPartManager(partManager =>
//{
//    var baseDllPath = builder.Configuration.GetSection("DllPath").Value;
//    foreach (var dllPath in Directory.GetFiles(baseDllPath, "*.dll"))
//    {
//        try
//        {
//            var assembly = Assembly.LoadFrom(dllPath);
//            partManager.ApplicationParts.Add(new AssemblyPart(assembly));
//            Console.WriteLine($"Loaded assembly from: {dllPath}");
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine($"Failed to load assembly from {dllPath}: {ex.Message}");
//        }
//    }

//});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
const string OpenApiFilePath = "C:\\Users\\OnePoint-bijay\\source\\repos\\DomainApp\\MyWebApp\\wwwroot\\api-doc\\openapi.json";
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Dynamic API",
        Version = "v1",
        Description = "OpenAPI spec for dynamically loaded controllers."
    });
    //c.DocumentFilter<MyCustomDocument>();
    //using (var writer = new StreamWriter(OpenApiFilePath))
    //{
    //    var json = System.Text.Json.JsonSerializer.Serialize(c.SwaggerDoc, new System.Text.Json.JsonSerializerOptions
    //    {
    //        WriteIndented = true
    //    });
    //    writer.Write(json);
    //}
});


var app = builder.Build();



//using (var writer = new StreamWriter(OpenApiFilePath))
//{
//    var json = System.Text.Json.JsonSerializer.Serialize(c.SwaggerDoc, new System.Text.Json.JsonSerializerOptions
//    {
//        WriteIndented = true
//    });
//    writer.Write(json);
//}

app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
