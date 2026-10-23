using Core.Enum;
using System.Collections.Generic;

namespace SDK.Contracts.Data
{
    /// <summary>Matches server <c>DynamicLocationWrapperContract</c>.</summary>
    public class DynamicDeviceShortContract
    {
        public int SectorId { get; set; }

        public List<DynamicDeviceShort> Locations { get; set; }
    }

    /// <summary>Matches server <c>DynamicLocationShortContract</c>.</summary>
    public class DynamicDeviceShort
    {
        public string Id { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public FallType FallStatus { get; set; }

        public float? Z { get; set; }
    }

    public class DynamicLocationWrapperContract : DynamicDeviceShortContract
    {
    }

    public class DynamicLocationShortContract : DynamicDeviceShort
    {
    }
}
