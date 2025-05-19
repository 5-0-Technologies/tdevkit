using Core.Enum;
using SDK.Contracts.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SDK.Models
{
    public class DeviceContract : AccountContract
    {
        public int Id { get; set; }

        public string Mac { get; set; }

        public int BranchId { get; set; }

        public int? SectorId { get; set; }

        public int? ValidSectorId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        public long? LastTimeOnline { get; set; }

        public long? ValidLastTimeOnline { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public float? ValidX { get; set; }

        public float? ValidY { get; set; }

        public string AppVersion { get; set; }

        public bool IsMoving { get; set; }

        public FallType FallStatus { get; set; }

        public float? Battery { get; set; }

        public int DeviceTypeId { get; set; }

        public string DeviceType { get; set; }

        public bool Position { get; set; }

        public bool Geofence { get; set; }

        public float? GeofenceRange { get; set; }

        public static explicit operator DeviceWriteContract(DeviceContract contract)
        {
            return new DeviceWriteContract
            {
                Title = contract.Title,
                Note = contract.Note,
                Mac = contract.Mac,
                SectorId = contract.SectorId,
                LastTimeOnline = contract.LastTimeOnline,
                X = (float?)contract?.X,
                Y = (float?)contract?.Y,
                AppVersion = contract.AppVersion,
                IsMoving = contract.IsMoving,
                FallStatus = contract.FallStatus,
                Battery = contract.Battery,
                DeviceTypeId = contract.DeviceTypeId,
                Position = contract.Position,
                Geofence = contract.Geofence,
                GeofenceRange = contract.GeofenceRange,
                Login = contract.Login,
            };
        }
    }

    public class DeviceWriteContract : AccountContract
    {
        [StringLength(17)]
        public string Mac { get; set; }

        public int? SectorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public string Note { get; set; }

        public long? LastTimeOnline { get; set; }

        public float? X { get; set; }

        public float? Y { get; set; }

        public float? Z { get; set; }

        [StringLength(17)]
        public string AppVersion { get; set; }

        public bool IsMoving { get; set; }

        public FallType FallStatus { get; set; }

        public float? Battery { get; set; }

        public int? DeviceTypeId { get; set; }

        public bool Position { get; set; }

        public bool Geofence { get; set; }

        public float? GeofenceRange { get; set; }

        public string Password { get; set; }
        /// <summary>
        /// An array of <b>Layer Ids</b> that are NoGo Layers for this <b>Device</b>.
        /// </summary>
        public HashSet<int> Layers { get; set; }

        [StringLength(17)]
        public string DeviceStatus { get; set; }

        public long? Heartbeat { get; set; }

        public string Color { get; set; }
    }
}
