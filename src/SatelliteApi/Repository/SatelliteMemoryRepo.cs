using System.Collections.Generic;
using System.Threading.Tasks;
using SatelliteApi.Models;

namespace SatelliteApi.Repository
{
    public class SatelliteMemoryRepo : ISatelliteRepo
    {
        private List<Satellite> _context = new List<Satellite>()
        {
            new Satellite(){ Id = "d4913292-f1c4-4f5e-9ec9-e61eb9b7563e" , Name = "ANASIS-II", MissionDuration = "15 years", Mass = "6000kg" },
            new Satellite(){ Id = "344c1de7-f09e-4eee-89a3-b403b12dad0b", Name = "Amos-17", MissionDuration = "19 years", Mass = "6500kg" },
            new Satellite(){ Id = "fc9aba85-53e9-45e9-9f79-6093385df67f", Name = "Paz", MissionDuration = "7 years", Mass = "1341kg" },
            new Satellite(){ Id = "3268443b-cde9-42cb-8091-c4a22bcaa562", Name = "Nusantara Satu", MissionDuration = "15 years", Mass = "4100kg" }
        };
        
        public async Task<IEnumerable<Satellite>> FindAll()
        {
            return await Task.Run(() => _context);
        }
    }
}