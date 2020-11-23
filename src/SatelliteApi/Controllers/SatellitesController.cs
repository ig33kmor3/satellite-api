using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SatelliteApi.Models;
using SatelliteApi.Repository;

namespace SatelliteApi.Controllers
{
    [ApiController]
    [Route("/v1/[controller]")]
    public class SatellitesController : ControllerBase
    {
        private readonly ISatelliteRepo _repo;
        
        public SatellitesController(ISatelliteRepo repository)
        {
            _repo = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Satellite>>> GetSatellites()
        {
            var satellites = await _repo.FindAll();
            return Ok(satellites);
        }
    }
}