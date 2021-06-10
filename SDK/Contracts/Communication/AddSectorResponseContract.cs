using SDK.Communication;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Communication
{
    class AddSectorResponseContract : PostResponseContract
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public int BranchId { get; set; }

        public string Title { get; set; }

        public double BarrierWidth { get; set; }

        public double BarrierHeight { get; set; }

        public double SectorWidth { get; set; }

        public double SectorHeight { get; set; }

        public long Modified { get; set; }

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
                GpsItems = addSectorResponseContract.GpsItems,
                Areas = addSectorResponseContract.Areas,
                Barriers = addSectorResponseContract.Barriers,
                Beacons = addSectorResponseContract.Beacons,
                Sensors = addSectorResponseContract.Sensors
            };
        }
    }
}
