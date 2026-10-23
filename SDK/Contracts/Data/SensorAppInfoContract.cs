using System;

namespace SDK.Models
{
    public class SensorAppInfoContract
    {
        public string Version { get; set; }

        public long Size { get; set; }

        public string Name { get; set; }

        public Guid? Branch { get; set; }
    }

    public class FileContract
    {
        public string Version { get; set; }

        public long Size { get; set; }

        public string Name { get; set; }

        public Guid? Branch { get; set; }
    }
}
