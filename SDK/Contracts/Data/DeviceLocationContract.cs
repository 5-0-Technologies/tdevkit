using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Data
{
    [DataContract]
    public class DeviceLocationContract
    {
        [Required]
        [StringLength(255)]
        public string Login { get; set; }

        public LocationContract[] Locations { get; set; }
    }

    [DataContract]
    public class LocationContract
    {
        [Required]
        [DataMember(Order = 1)]
        public long Timestamp { get; set; }

        [DataMember(Order = 1)]
        public int? SectorId { get; set; }

        [DataMember(Order = 2)]
        public float? X { get; set; }

        [DataMember(Order = 4)]
        public float? Y { get; set; }

        [DataMember(Order = 5)]
        public float? Z { get; set; }

        [DataMember(Order = 7)]
        public int? Interval { get; set; }

        [DataMember(Order = 9)]
        public byte? Battery { get; set; } = 0;

        [DataMember(Order = 10)]
        public bool IsMoving { get; set; }

        [DataMember(Order = 12)]
        public DistanceContract[] Distances { get; set; }
    }

    [DataContract]
    public class DistanceContract
    {
        [DataMember(Order = 1)]
        public int BeaconId { get; set; }

        [DataMember(Order = 2)]
        public float Distance { get; set; }

        [DataMember(Order = 3)]
        public int RSSI { get; set; }
    }
}
