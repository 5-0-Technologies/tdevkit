using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Models
{
    public class BeaconContract
    {
        public int Id { get; set; }

        public int SectorId { get; set; }

        public int BranchId { get; set; }

        public string Mac { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public bool Position { get; set; }

  public int BeaconTypeId {get; set;}

  public string BeaconType {get; set;}

        public bool Geofence { get; set; }
        
        public int GeofenceRange { get; set; }

        public string Cluster { get; set; }

        public long LastTimeOnline { get; set; }

        public bool UseGps { get; set; }
    }
}
