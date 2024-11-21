using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ExampleController
{
    [HttpGet]
    public string Get()
    {
        return "Hello, Swagger!";
    }
}
