using System.Threading.Tasks;
using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunctionBindingToPocoObject
{
    public static class FunctionBindingToPocoObjectWithEnum
    {
        [FunctionName("FunctionBindingToPocoObjectWithEnum")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] Customer customer,
            HttpRequest req,
            ILogger log)
        {
            // Why this does not work with .net standard 2.0? 
            return (ActionResult)new OkObjectResult($"Hello from FunctionBindingToPocoObject: {JsonConvert.SerializeObject(customer)} ");
        }
    }
}