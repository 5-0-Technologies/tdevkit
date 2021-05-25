using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Communication
{
    public class PatchResponseContract
    {
        public bool Success { get; set; } = true;

        public string ErrorMessage { get; set; }
    }
}
