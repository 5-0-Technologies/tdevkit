﻿using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SDK.Models
{
    public class BeaconContract
    {
        public int Id { get; set; }

        public int? SectorId { get; set; }

        public int BranchId { get; set; }

        public string Mac { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Z { get; set; }

        public string Title { get; set; }

        public bool Active { get; set; }

        public bool Position { get; set; }

        public int? TypeId { get; set; }

        public bool Geofence { get; set; }

        public double? GeofenceRange { get; set; }

        public string Cluster { get; set; }

        public long? LastTimeOnline { get; set; }

        public bool UseGps { get; set; }

        public string CFUUID { get; set; }

        public long Created { get; set; }

        public long Update { get; set; }
    }

    public class BeaconWriteContract
    {
        public int? SectorId { get; set; }

        [Required]
        [StringLength(17)]
        public string Mac { get; set; }

        public float? X { get; set; }

        public float? Y { get; set; }

        public float? Z { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public bool Active { get; set; }

        public int? TypeId { get; set; }

        public bool Position { get; set; }

        public bool Geofence { get; set; }

        public float? GeofenceRange { get; set; }

        [StringLength(10)]
        public string Cluster { get; set; }

        public long? LastTimeOnline { get; set; }

        public bool UseGps { get; set; }
    }
}
