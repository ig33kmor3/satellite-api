using System;
using System.ComponentModel.DataAnnotations;

namespace SatelliteApi.Models
{
    public class Satellite
    {
        [Required]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        [Required]
        public string MissionDuration { get; set; }
        [Required]
        public string Mass { get; set; }
    }
}