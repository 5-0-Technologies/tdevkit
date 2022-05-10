using System.Runtime.Serialization;

namespace SDK.Contracts.Data
{
    public class FileInfoContract
    {
        public string Version { get; set; }

        public long Size { get; set; }

        public string Name { get; set; }
    }
}
