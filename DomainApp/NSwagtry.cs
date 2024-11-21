using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Schema.Generation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
namespace DomainApp
{

    public class HomeController : ControllerBase
    {
        [HttpGet("/api/v1/Home")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
    public class MyModel
    {
        [Required]
        [MinLength(4)]
        public string Title { get; set; }
    }
    public class NSwagtry
    {
        const string OpenApiFilePath = "C:\\Users\\OnePoint-bijay\\source\\repos\\DomainApp\\DomainApp\\openapi.json";
        const string DllFilePath = "C:\\Users\\OnePoint-bijay\\source\\repos\\DomainApp\\Exterior\\bin\\Debug\\net8.0\\Exterior.dll";

        public void Try()
        {


            

        }
       
    }

}
