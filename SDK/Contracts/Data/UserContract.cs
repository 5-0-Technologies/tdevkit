using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Data
{
    public class UserContract
    {
        public int Id { get; set; }

        public int BranchId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool AllowDemo { get; set; }
    }
}
