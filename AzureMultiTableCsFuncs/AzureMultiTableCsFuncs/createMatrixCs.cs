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
    public static class createMatrixCs
    {
        [FunctionName("createMatrixCs")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post")]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();

            //get multiple and modulus
            bool success = false;
            int multiple = 0;
            int modulus = 0;

            try {
                multiple = data?.multiple;
                modulus = data?.modulus;
                success = true;
            }
            catch { success = false; }

            helper obj1 = new helper();

            return success == false
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a multiplier and modulus in the request body")
                : req.CreateResponse(HttpStatusCode.OK, obj1.createMatrix(multiple, modulus));
        }

    }

}
