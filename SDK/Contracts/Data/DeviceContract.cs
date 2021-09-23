using Core.Enum;
using SDK.Contracts.Data;

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
    }
}
