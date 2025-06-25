using System.Runtime.Serialization;

namespace SDK.Models
{
    [DataContract]
    public class AreaOccurrence
    {
        [DataMember]
        public long Start { get; set; }

        [DataMember]
        public long Stop { get; set; }

        [DataMember]
        public long Date { get; set; }

        [DataMember]
        public string Shift { get; set; }

        [DataMember]
        public string Device { get; set; }

        [DataMember]
        public string Layer { get; set; }

        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public bool IsNoGo { get; set; }

        [DataMember]
        public long Duration { get; set; }

        [DataMember]
        public int Occurrences { get; set; }
    }
}
