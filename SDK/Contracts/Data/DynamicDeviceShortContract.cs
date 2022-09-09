using Core.Enum;

namespace SDK.Contracts.Data
{
    public class DynamicDeviceShortContract
    {
        public int SectorId { get; set; }

        public DynamicDeviceShort[] Locations { get; set; }
    }

    public class DynamicDeviceShort
    {
        public string Id { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public FallType FallStatus { get; set; }
    }
}
