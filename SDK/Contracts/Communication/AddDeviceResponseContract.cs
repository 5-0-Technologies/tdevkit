using Core.Enum;
using SDK.Communication;
using SDK.Models;

namespace SDK.Contracts.Communication
{
    class AddDeviceResponseContract : PostResponseContract
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

        public float? X { get; set; }

        public float? Y { get; set; }

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

        public string Login { get; set; }

        //public string Password { get; set; }

        //public string Salt { get; set; }

        public static explicit operator DeviceContract(AddDeviceResponseContract addDeviceResponseContract)
        {
            return new DeviceContract
            {
                Id = addDeviceResponseContract.Id,
                Mac = addDeviceResponseContract.Mac,
                BranchId = addDeviceResponseContract.BranchId,
                SectorId = addDeviceResponseContract.SectorId,
                ValidSectorId = addDeviceResponseContract.ValidSectorId,
                Title = addDeviceResponseContract.Title,
                Note = addDeviceResponseContract.Note,
                LastTimeOnline = addDeviceResponseContract.LastTimeOnline,
                ValidLastTimeOnline = addDeviceResponseContract.ValidLastTimeOnline,
                X = addDeviceResponseContract.X,
                Y = addDeviceResponseContract.Y,
                ValidX = addDeviceResponseContract.ValidX,
                ValidY = addDeviceResponseContract.ValidY,
                AppVersion = addDeviceResponseContract.AppVersion,
                IsMoving = addDeviceResponseContract.IsMoving,
                FallStatus = addDeviceResponseContract.FallStatus,
                Battery = addDeviceResponseContract.Battery,
                DeviceTypeId = addDeviceResponseContract.DeviceTypeId,
                DeviceType = addDeviceResponseContract.DeviceType,
                Position = addDeviceResponseContract.Position,
                Geofence = addDeviceResponseContract.Geofence,
                GeofenceRange = addDeviceResponseContract.GeofenceRange,
                Login = addDeviceResponseContract.Login,
            };
        }
    }
}
