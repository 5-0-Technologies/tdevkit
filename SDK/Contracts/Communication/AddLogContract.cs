using SDK.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    public class LogWriteContract
    {
        /// <summary>
        /// If not provided, make sure to provide <b>Login</b> property, which is the <i>Login</i> of the <i>Account</i>
        /// you want to associate this <i>Log</i> with. The system will find its AccountId.
        /// </summary>
        [DataMember(Order = 1)]
        public int? AccountId { get; set; }

        [DataMember(Order = 2)]
        [StringLength(5000)]
        public string Message { get; set; }

        [DataMember(Order = 3)]
        [StringLength(20)]
        public string Level { get; set; }

        /// <summary>
        /// Provide a unix miliseconds UTC value. If not provided, current time will be used.
        /// </summary>
        [DataMember(Order = 4)]
        public long? Timestamp { get; set; }

        /// <summary>
        /// If <b>AccountId</b> is not provided, this property is used to find the <i>Account</i> to associate this <i>Log</i> with.
        /// </summary>
        [DataMember(Order = 5)]
        public string Login { get; set; }
    }
}
