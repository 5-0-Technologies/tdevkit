using SDK.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Communication
{
    public class ManDownBatchResponseContract
    {
        public string Login { get; set; }

        public long Timestamp { get; set; }

        public ActionType Action { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }
}
