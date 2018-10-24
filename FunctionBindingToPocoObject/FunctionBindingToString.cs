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
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] string selskapJson,
            HttpRequest req,
            ILogger log)
        {
            Customer selskap = JsonConvert.DeserializeObject<Customer>(selskapJson);
            return (ActionResult)new OkObjectResult($"Hello from FunctionBindingToString: {JsonConvert.SerializeObject(selskap)} ");
        }
    }
}