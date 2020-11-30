using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using SatelliteApi.Models;

namespace SatelliteApi.Repository
{
    public interface ISatelliteRepo
    {
        Task<IEnumerable<Satellite>> FindAll();
    }
}