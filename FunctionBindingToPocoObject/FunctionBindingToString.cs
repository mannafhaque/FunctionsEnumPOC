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
    public static class FunctionBindingToString
    {
        [FunctionName("FunctionBindingToString")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] string customerJson,
            HttpRequest req,
            ILogger log)
        {
            Customer customer = JsonConvert.DeserializeObject<Customer>(customerJson);
            return (ActionResult)new OkObjectResult($"Hello from FunctionBindingToString: {JsonConvert.SerializeObject(customer)} ");
        }
    }
}