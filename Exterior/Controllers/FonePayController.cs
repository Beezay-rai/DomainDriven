using Microsoft.AspNetCore.Http;
using DomainApp.Custom;
using OnePoint.PDK.CustomAttribute;
using OnePoint.PDK.Enpoint;
using OnePoint.PDK.Repository;
using OnePoint.PDK.Schema;
using System.ComponentModel.DataAnnotations;


namespace Exterior.Controller
{
    [CustomEndpoint("post", "/api/v1/notification/send")]

    //[CustomConsume("application/json", type: typeof(FonePayNotificationRequestModel))]
    [CustomProduceResponseType(typeof(FonePayErrorModel), 403, typeof(ForbiddenExampleProvider), "application/json", "Forbidden")]
    [CustomProduceResponseType(typeof(FonePayErrorModel), 404, typeof(NotFoundExampleProvider), "application/json", "Not Found")]
    [CustomProduceResponseType(typeof(FonePayErrorModel), 400, typeof(BadRequestExampleProvider), "application/json", "Bad Request")]
    [CustomProduceResponseType(typeof(FonePayErrorModel), 502, typeof(BadGateWayExampleProvider), "application/json", "Bad Gateway")]
    [CustomProduceResponseType(typeof(FonePayErrorModel), 500, typeof(InternalServerErrorExampleProvider), "application/json", "Internal Server Error")]
    [CustomProduceResponseType(typeof(FonePayErrorModel), 429, typeof(TooManyRequestExampleProvider), "application/json", "Too Many Requests")]


    public class FonePayController : CustomEndpoint
    {
        public FonePayController(CustomSchema schema, CustomRepository repository) : base(schema, repository)
        {
        }

        public override Task Execute(HttpContext context)
        {
            throw new NotImplementedException();
        }
    }



    public class FonePayErrorModel : CustomComponent
    {
        public string timestamp { get; set; }
        public int status { get; set; }
        public string error { get; set; }
        public string message { get; set; }
        public object path { get; set; }

       
    }


    public class FonePayNotificationRequestModel : CustomComponent
    {
        [MinLength(2)]
        [Required]
        public string mobileNumber { get; set; } = null!;
        [MaxLength(5)]
        public string remark1 { get; set; }
        [Range(5,10)]
        public string retrievalReferenceNumber { get; set; }
        [Required]
        public string amount { get; set; }
        public string? merchantId { get; set; }
        public string terminalId { get; set; }
        public string type { get; set; }
        public string uniqueId { get; set; }
        [Required]
        public FonePayNotificationRequestProp properties { get; set; }

   
    }

    public class FonePayNotificationRequestProp : CustomComponent
    {
        public DateTime txnDate { get; set; }
        public string secondaryMobileNumber { get; set; }

        public string email { get; set; }
        public string sessionSrlNo { get; set; }
        public string commission { get; set; }
        public string initiator { get; set; }

       
    }
    #region FonePay Error Response Example Provider

    public class ForbiddenExampleProvider : Swashbuckle.AspNetCore.Filters.IExamplesProvider<FonePayErrorModel>
    {
        public FonePayErrorModel GetExamples()
        {
            return new FonePayErrorModel
            {
                timestamp = DateTime.Now.ToString(),
                status = 403,
                error = "Forbidden",
                message = "Invalid authorization data",

            };
        }
    }

    public class NotFoundExampleProvider : Swashbuckle.AspNetCore.Filters.IExamplesProvider<FonePayErrorModel>
    {
        public FonePayErrorModel GetExamples()
        {
            return new FonePayErrorModel
            {
                timestamp = DateTime.Now.ToString(),
                status = 404,
                error = "Not Found !",
                message = "API Not Found",
            };
        }
    }
    public class BadRequestExampleProvider : Swashbuckle.AspNetCore.Filters.IExamplesProvider<FonePayErrorModel>
    {
        public FonePayErrorModel GetExamples()
        {
            return new FonePayErrorModel
            {
                timestamp = DateTime.Now.ToString(),
                status = 400,
                error = "Bad Request",
                message = "Validation Error",
            };
        }
    }
    public class InternalServerErrorExampleProvider : Swashbuckle.AspNetCore.Filters.IExamplesProvider<FonePayErrorModel>
    {
        public FonePayErrorModel GetExamples()
        {
            return new FonePayErrorModel
            {
                timestamp = DateTime.Now.ToString(),
                status = 500,
                error = "Internal Error",
                message = "Contact With Error",
            };
        }
    }
    public class BadGateWayExampleProvider : Swashbuckle.AspNetCore.Filters.IExamplesProvider<FonePayErrorModel>
    {
        public FonePayErrorModel GetExamples()
        {
            return new FonePayErrorModel()
            {
                timestamp = DateTime.UtcNow.ToString(),
                status = 502,
                error = "Bad Gateway",
                message = "Connection Timeout",
            };
        }
    }

    public class TooManyRequestExampleProvider : Swashbuckle.AspNetCore.Filters.IExamplesProvider<FonePayErrorModel>
    {
        public FonePayErrorModel GetExamples()
        {
            return new FonePayErrorModel()
            {
                timestamp = DateTime.UtcNow.ToString(),
                status = 429,
                error = "Too Many Request",
                message = "Rate Limit Exeeced",
            };
        }
    }
    #endregion
}
