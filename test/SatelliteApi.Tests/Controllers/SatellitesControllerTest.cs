using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SatelliteApi.Models;
using Xunit;

namespace SatelliteApi.Tests.Controllers
{
    public class SatellitesControllerTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;
        private readonly List<Satellite> _satellitesTestResponse;
        
        public SatellitesControllerTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
            _satellitesTestResponse = new List<Satellite>()
            {
                new Satellite(){ Id = "d4913292-f1c4-4f5e-9ec9-e61eb9b7563e" , Name = "ANASIS-II", MissionDuration = "15 years", Mass = "6000kg" },
                new Satellite(){ Id = "344c1de7-f09e-4eee-89a3-b403b12dad0b", Name = "Amos-17", MissionDuration = "19 years", Mass = "6500kg" },
                new Satellite(){ Id = "fc9aba85-53e9-45e9-9f79-6093385df67f", Name = "Paz", MissionDuration = "7 years", Mass = "1341kg" },
                new Satellite(){ Id = "3268443b-cde9-42cb-8091-c4a22bcaa562", Name = "Nusantara Satu", MissionDuration = "15 years", Mass = "4100kg" }
            };
        }

        [Fact]
        public async Task TestGetSatellitesAsync()
        {
            var response = await _client.GetAsync("/v1/satellites");
            response.EnsureSuccessStatusCode();
            var satellites = await response.Content.ReadAsStringAsync();
            Assert.Equal(JsonConvert.SerializeObject(_satellitesTestResponse, new JsonSerializerSettings 
            { 
                ContractResolver = new CamelCasePropertyNamesContractResolver() 
            }), satellites);
        }
    }
}
