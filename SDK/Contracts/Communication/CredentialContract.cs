using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

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
