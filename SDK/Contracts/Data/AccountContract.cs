using System.ComponentModel.DataAnnotations;

namespace SDK.Contracts.Data
{
    public class AccountContract
    {
        [Required]
        [StringLength(255)]
        public string Login { get; set; }

        //public string Password { get; set; }

        //public string Salt { get; set; }
    }
}
