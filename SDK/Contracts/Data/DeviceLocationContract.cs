﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Data
{
    public class DeviceLocationContract
    {
        [Required]
        public string Login { get; set; }

        public LocationContract[] Locations { get; set; }
    }

    public class LocationContract
    {
        [Required]
        public long Timestamp { get; set; }

        public int? SectorId { get; set; }

        public float? X { get; set; }

        public float? Y { get; set; }

        public float? Z { get; set; }

        public int? Interval { get; set; }

        public byte? Battery { get; set; } = 0;

        public bool IsMoving { get; set; }

        public DistanceContract[] Distances { get; set; }
    }

    public class DistanceContract
    {
        public int BeaconId { get; set; }

        public float Distance { get; set; }

        public int RSSI { get; set; }
    }
}
