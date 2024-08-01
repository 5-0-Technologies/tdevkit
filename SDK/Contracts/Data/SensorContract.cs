using SDK.Contracts.Data;

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
    }
}
