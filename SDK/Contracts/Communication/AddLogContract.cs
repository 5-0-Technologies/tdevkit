using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Communication
{
    [DataContract]
    public class LogContract
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public int AccountId { get; set; }

        [DataMember(Order = 3)]
        public string Message { get; set; }

        [DataMember(Order = 4)]
        public string Level { get; set; }

        [DataMember(Order = 5)]
        public long Timestamp { get; set; }

        [DataMember(Order = 6)]
        public int BranchId { get; set; }

        [DataMember(Order = 8)]
        public string Login { get; set; }
    }
}
