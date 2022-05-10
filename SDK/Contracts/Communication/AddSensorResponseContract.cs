using SDK.Communication;
using SDK.Models;

namespace SDK.Contracts.Communication
{
    class AddSensorResponseContract : PostResponseContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Mac { get; set; }

        public string Note { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public int? Battery { get; set; }

        public int SectorId { get; set; }

        public SensorDataContract[] SensorData { get; set; }

        public int? AreaId { get; set; }

        public string Login { get; set; }

        //public string Password { get; set; }

        //public string Salt { get; set; }

        public static explicit operator SensorContract(AddSensorResponseContract addSensorResponseContract)
        {
            return new SensorContract
            {
                Id = addSensorResponseContract.Id,
                Title = addSensorResponseContract.Title,
                Mac = addSensorResponseContract.Mac,
                Note = addSensorResponseContract.Note,
                X = addSensorResponseContract.X,
                Y = addSensorResponseContract.Y,
                Battery = addSensorResponseContract.Battery,
                SectorId = addSensorResponseContract.SectorId,
                SensorData = addSensorResponseContract.SensorData,
                AreaId = addSensorResponseContract.AreaId,
                Login = addSensorResponseContract.Login,
                //Password = addSensorResponseContract.Password,
                //Salt = addSensorResponseContract.Salt,
            };
        }
    }
}
