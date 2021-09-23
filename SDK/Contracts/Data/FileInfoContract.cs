using System.Runtime.Serialization;

namespace SDK.Contracts.Data
{
    public class FileInfoContract
    {
        [DataMember(Order = 1)]
        public string Version { get; set; }

        [DataMember(Order = 2)]
        public long Size { get; set; }

        [DataMember(Order = 3)]
        public string Name { get; set; }
    }
}
