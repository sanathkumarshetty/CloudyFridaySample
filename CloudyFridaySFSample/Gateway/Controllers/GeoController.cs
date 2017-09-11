using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Fabric;
using System.Net.Http;

namespace Gateway.Controllers
{

    [Route("Gateway/[Controller]")]
    public class GeographyController : Controller
    {

        private readonly ConfigSettings configSettings;
        private readonly StatelessServiceContext serviceContext;
        private readonly HttpClient httpClient;
        private readonly FabricClient fabricClient;


        public GeographyController(ConfigSettings configSettings, StatelessServiceContext serviceContext, HttpClient httpClient, FabricClient fabricClient)
        {
            this.serviceContext = serviceContext;
            this.configSettings = configSettings;
            this.httpClient = httpClient;
            this.fabricClient = fabricClient;
        }


        public async Task<IActionResult> GetAsync()
        {

            try
            {
                string geographyServicesfuri = this.serviceContext.CodePackageActivationContext.ApplicationName + "/" + this.configSettings.GeographyServiceName;
                string proxyUrl =
                      $"http://localhost:{this.configSettings.ReverseProxyPort}/{geographyServicesfuri.Replace("fabric:/", "")}/api/Geo";
                HttpResponseMessage response = await this.httpClient.GetAsync(proxyUrl);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return this.StatusCode((int)response.StatusCode);
                }

                return this.Ok(await response.Content.ReadAsStringAsync());
            }
            catch (Exception e)
            {

                throw e;
            }
           
        }
           
}
    }

