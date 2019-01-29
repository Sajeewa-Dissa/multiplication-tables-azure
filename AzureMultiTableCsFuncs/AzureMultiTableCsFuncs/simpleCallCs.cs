using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using System;
using Newtonsoft.Json;

namespace AzureMultiTablesCsFuncs
{
    public static class simpleCallCs
    {
        [FunctionName("simpleCallCs")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post")]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();

            //get multiple and modulus
            bool success = false;
            int value = 0;

            try {
                value = data?.value;
                success = true;
            }
            catch { success = false; }

            helper obj1 = new helper();

            return success == false
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a multiplier and modulus in the request body")
                : req.CreateResponse(HttpStatusCode.OK, string.Format("You entered: {0}", value));
        }

    }

}
