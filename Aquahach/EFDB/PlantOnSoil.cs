using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aquahach.EFDB
{
    public class PlantOnSoil
    {
        public int PlantId { get; set; }
        public int SoilId { get; set; }
        [MaxLength(500)]
        public string Information { get; set; }
        public int? WateringPeriod { get; set; }
        
    }
}
