using SDK.Communication;
using SDK.Models;
using System;

namespace SDK.Contracts.Communication
{
    class AddSectorResponseContract : PostResponseContract
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

        public static explicit operator SectorContract(AddSectorResponseContract addSectorResponseContract)
        {
            return new SectorContract
            {
                Id = addSectorResponseContract.Id,
                Guid = addSectorResponseContract.Guid,
                BranchId = addSectorResponseContract.BranchId,
                Title = addSectorResponseContract.Title,
                BarrierHeight = addSectorResponseContract.BarrierHeight,
                BarrierWidth = addSectorResponseContract.BarrierWidth,
                SectorWidth = addSectorResponseContract.SectorWidth,
                SectorHeight = addSectorResponseContract.SectorHeight,
                Modified = addSectorResponseContract.Modified,
                Configuration = addSectorResponseContract.Configuration,
                GpsItems = addSectorResponseContract.GpsItems,
                Areas = addSectorResponseContract.Areas,
                Barriers = addSectorResponseContract.Barriers,
                Beacons = addSectorResponseContract.Beacons,
                Sensors = addSectorResponseContract.Sensors
            };
        }
    }
}
