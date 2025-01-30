using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SDK.Models
{
    public class SectorContract
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public int BranchId { get; set; }

        public string Title { get; set; }

        public float BarrierWidth { get; set; }

        public float BarrierHeight { get; set; }

        public float SectorWidth { get; set; }

        public float SectorHeight { get; set; }

        public long Modified { get; set; }

        public string Configuration { get; set; }

        public GpsItemContract[] GpsItems { get; set; }

        public AreaContract[] Areas { get; set; }

        public BarrierContract[] Barriers { get; set; }

        public BeaconContract[] Beacons { get; set; }

        public SensorContract[] Sensors { get; set; }

        public int? Floor { get; set; }
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

    public class SectorWriteContract
    {
        public Guid Guid { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public float BarrierHeight { get; set; }

        public float BarrierWidth { get; set; }

        public float SectorWidth { get; set; }

        public float SectorHeight { get; set; }

        public long Modified { get; set; }

        /// <summary>
        /// An Array of <b>GpsItem Ids</b> that are in this sector.
        /// </summary>
        public HashSet<int> GpsItems { get; set; }

        /// <summary>
        /// An Array of <b>Area Ids</b> that are in this sector.
        /// </summary>
        public HashSet<int> Areas { get; set; }

        /// <summary>
        /// An Array of <b>Barrier Ids</b> that are in this sector.
        /// </summary>
        public HashSet<int> Barriers { get; set; }

        /// <summary>
        /// An Array of <b>Beacon Ids</b> that are in this sector.
        /// </summary>
        public HashSet<int> Beacons { get; set; }

        /// <summary>
        /// An Array of <b>Sensor Ids</b> that are in this sector.
        /// </summary>
        public HashSet<int> Sensors { get; set; }

        public string Configuration { get; set; }
        /// <summary>
        /// An Array of <b>Path Ids</b> that are in this sector.
        /// </summary>
        public HashSet<int> Paths { get; set; }

        public int? Floor { get; set; }
    }
}
