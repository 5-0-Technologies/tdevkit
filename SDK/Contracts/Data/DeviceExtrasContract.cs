using System.Collections.Generic;

namespace SDK.Models
{
    public class DeviceStatusContract
    {
        public int Battery { get; set; }

        public string DeviceStatus { get; set; }

        public long Timestamp { get; set; }
    }

    public class EventContract
    {
        public long Timestamp { get; set; }

        public string EventType { get; set; }
    }

    public class HeatmapContract
    {
        public int SectorId { get; set; }

        public List<HeatmapPointContract> Points { get; set; }
    }

    public class HeatmapPointContract
    {
        public ushort X { get; set; }

        public ushort Y { get; set; }

        public int Count { get; set; }
    }

    public class SimpleLocationContract
    {
        public long Timestamp { get; set; }

        public int SectorId { get; set; }

        public int Interval { get; set; }

        public float? X { get; set; }

        public float? Y { get; set; }
    }

    public class DeviceRegistrationContract
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public string Mac { get; set; }

        public string Title { get; set; }
    }
}
