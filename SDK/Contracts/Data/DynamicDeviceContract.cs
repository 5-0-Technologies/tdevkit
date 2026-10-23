using Core.Enum;

namespace SDK.Models
{
    /// <summary>Matches server <c>DynamicLocationContract</c>.</summary>
    public class DynamicDeviceContract
    {
        public string Id { get; set; }

        public string Login { get; set; }

        public string Title { get; set; }

        public int SectorId { get; set; }

        public string Type { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public FallType FallStatus { get; set; }

        public float? Z { get; set; }
    }

    /// <summary>Alias for swagger/server naming.</summary>
    public class DynamicLocationContract : DynamicDeviceContract
    {
    }
}
