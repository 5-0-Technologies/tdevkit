using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SDK
{
    [DataContract]
    public class CredentialContract
    {
        [DataMember(Order = 1)]
        public string Client { get; set; }

        [Required]
        [DataMember(Order = 2)]
        public string Login { get; set; }

        [Required]
        [DataMember(Order = 3)]
        public string Password { get; set; }
    }
}
