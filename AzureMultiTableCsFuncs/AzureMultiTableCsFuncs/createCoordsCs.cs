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
    public static class createCoordsCs
    {
        [FunctionName("createCoordsCs")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "post")]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // Get request body
            dynamic data = await req.Content.ReadAsAsync<object>();

            //get multiple and modulus
            bool success = false;
            int x0 = 0;
            int y0 = 0;
            int radius = 0;
            int modulus = 0;

            try {
                x0 = data?.x0;
                y0 = data?.y0;
                radius = data?.radius;
                modulus = data?.modulus;
                success = true;
            }
            catch { success = false; }

            helper obj1 = new helper();

            return success == false
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass x0, y0, radius and modulus in the request body")
                : req.CreateResponse(HttpStatusCode.OK, obj1.createCoords(x0, y0, radius, modulus));
        }

    }

}
