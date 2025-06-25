using SDK.Contracts.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace SDK.Models
{
    public class SensorContract : AccountContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Mac { get; set; }

        public string Note { get; set; }

        public double? X { get; set; }

        public double? Y { get; set; }

        public float? Battery { get; set; }

        public int SectorId { get; set; }

        public SensorDataContract[] SensorData { get; set; }

        public int? AreaId { get; set; }
        public string ExternalId { get; set; }

        public static explicit operator SensorContract(SensorWriteContract contract)
        {
            return new SensorContract
            {
                Title = contract.Title,
                Mac = contract.Mac,
                Note = contract.Note,
                X = contract.X,
                Y = contract.Y,
                Battery = contract.Battery,
                SectorId = contract.SectorId ?? 0,
                //SensorData = contract.SensorData,
                AreaId = contract.AreaId,
                ExternalId = contract.ExternalId
            };
        }
    }

    public class SensorWriteContract : AccountContract
    {
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(17)]
        public string Mac { get; set; }

        public string Note { get; set; }

        public float? X { get; set; }

        public float? Y { get; set; }

        public float? Battery { get; set; }

        public int? SectorId { get; set; }

        public SensorDataWriteContract[] SensorData { get; set; }

        public int? AreaId { get; set; }

        public string Password { get; set; }

        [StringLength(25)]
        public string Color { get; set; }

        [StringLength(50)]
        public string ExternalId { get; set; }
    }
}
