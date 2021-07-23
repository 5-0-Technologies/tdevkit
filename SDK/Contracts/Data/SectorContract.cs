using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Models
{
    public class SectorContract
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public int BranchId { get; set; }

        public string Title { get; set; }

        public double BarrierWidth { get; set; }

        public double BarrierHeight { get; set; }

        public double SectorWidth { get; set; }

        public double SectorHeight { get; set; }

        public long Modified { get; set; }

        public string Configuration { get; set; }

        public GpsItemContract[]? GpsItems { get; set; }

        public AreaContract[]? Areas { get; set; }

        public BarrierContract[]? Barriers { get; set; }

        public BeaconContract[]? Beacons { get; set; }

        public SensorContract[]? Sensors { get; set; }
    }

    public class BarrierContract
    {
        public int X { get; set; }
        
        public int Y { get; set; }
        
        public int SectorId { get; set; }      
        
        public int BranchId { get; set; }        
    }

    public class GpsItemContract
    {
        public int Id { get; set; }

        public int SectorId { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
