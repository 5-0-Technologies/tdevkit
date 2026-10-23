using SDK.Contracts.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SDK.Models
{
    public class SensorContract : AccountContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Mac { get; set; }

        public string Note { get; set; }

        public float? X { get; set; }

        public float? Y { get; set; }

        public float? Battery { get; set; }

        public int? SectorId { get; set; }

        public SectorContract Sector { get; set; }

        public SensorDataContract[] SensorData { get; set; }

        public int? AreaId { get; set; }

        public AreaContract Area { get; set; }

        public string Password { get; set; }

        public string Color { get; set; }

        public string ExternalId { get; set; }

        public int? SensorTypeId { get; set; }

        public string Tags { get; set; }

        public static explicit operator SensorContract(SensorWriteContract contract)
        {
            return new SensorContract
            {
                Login = contract.Login,
                Title = contract.Title,
                Mac = contract.Mac,
                Note = contract.Note,
                X = contract.X,
                Y = contract.Y,
                Battery = contract.Battery,
                SectorId = contract.SectorId,
                AreaId = contract.AreaId,
                Password = contract.Password,
                Color = contract.Color,
                ExternalId = contract.ExternalId,
                SensorTypeId = contract.SensorTypeId,
                Tags = contract.Tags
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

        public int? SensorTypeId { get; set; }

        public string Tags { get; set; }
    }

    public class SensorWritePatchContract : AccountContract
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

        public HashSet<int> SensorData { get; set; }

        public int? AreaId { get; set; }

        public string Password { get; set; }

        [StringLength(25)]
        public string Color { get; set; }

        [StringLength(50)]
        public string ExternalId { get; set; }

        public int? SensorTypeId { get; set; }

        public string Tags { get; set; }
    }

    public class SensorBatchContract
    {
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        public SensorDataBatchContract[] SensorData { get; set; }

        public string Title { get; set; }

        public string Mac { get; set; }

        public string Note { get; set; }

        public float? X { get; set; }

        public float? Y { get; set; }

        public float? Battery { get; set; }

        public int? SectorId { get; set; }

        public int? AreaId { get; set; }

        public string Password { get; set; }

        public string Color { get; set; }

        public string ExternalId { get; set; }

        public int? SensorTypeId { get; set; }
    }

    public class SensorDataBatchContract
    {
        public long Timestamp { get; set; }

        [Required]
        [StringLength(255)]
        public string Quantity { get; set; }

        [StringLength(1000)]
        public string Value { get; set; }

        [StringLength(15)]
        public string Unit { get; set; }

        [StringLength(15)]
        public string DataType { get; set; }

        public bool? ValueOK { get; set; }
    }

    public class SensorQuantityContract
    {
        public string Quantity { get; set; }

        public string Unit { get; set; }

        public string DataType { get; set; }

        public TimeValueAggregationContract[] Data { get; set; }
    }

    public class TimeValueAggregationContract
    {
        public long Timestamp { get; set; }

        public string Value { get; set; }

        public int Aggregation { get; set; }
    }
}
