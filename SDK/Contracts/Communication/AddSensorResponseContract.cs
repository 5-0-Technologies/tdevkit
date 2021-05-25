using SDK.Communication;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Communication
{
    class AddSensorResponseContract : PostResponseContract
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Title { get; set; }

        public string Mac { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public int SectorId { get; set; }

        public SensorDataContract[] SensorData { get; set; }

        public int AreaId { get; set; }

        public static explicit operator SensorContract(AddSensorResponseContract addBeaconResponseContract)
        {
            return new SensorContract
            {
                Id = addBeaconResponseContract.Id,
                Login = addBeaconResponseContract.Login,
                Password = addBeaconResponseContract.Password,
                Salt = addBeaconResponseContract.Salt,
                Title = addBeaconResponseContract.Title,
                Mac = addBeaconResponseContract.Mac,
                X = addBeaconResponseContract.X,
                Y = addBeaconResponseContract.Y,
                SectorId = addBeaconResponseContract.SectorId,
                SensorData = addBeaconResponseContract.SensorData,
                AreaId = addBeaconResponseContract.AreaId
            };
        }
    }
}
