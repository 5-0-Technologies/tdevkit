using SDK.Communication;
using SDK.Models;

namespace SDK.Contracts.Communication
{
    public class AddBeaconResponseContract : PostResponseContract
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

        public static explicit operator BeaconContract (AddBeaconResponseContract addBeaconResponseContract)
        {
            return new BeaconContract
            {
                Id = addBeaconResponseContract.Id,
                SectorId = addBeaconResponseContract.SectorId,
                BranchId = addBeaconResponseContract.BranchId,
                Mac = addBeaconResponseContract.Mac,
                X = addBeaconResponseContract.X,
                Y = addBeaconResponseContract.Y,
                Z = addBeaconResponseContract.Z,
                Title = addBeaconResponseContract.Title,
                Active = addBeaconResponseContract.Active,
                Position = addBeaconResponseContract.Position,
                TypeId = addBeaconResponseContract.TypeId,
                Geofence = addBeaconResponseContract.Geofence,
                GeofenceRange = addBeaconResponseContract.GeofenceRange,
                Cluster = addBeaconResponseContract.Cluster,
                LastTimeOnline = addBeaconResponseContract.LastTimeOnline,
                UseGps = addBeaconResponseContract.UseGps,
                CFUUID = addBeaconResponseContract.CFUUID,
                Created = addBeaconResponseContract.Created,
                Update = addBeaconResponseContract.Update,
            };
        }
    }
}
