using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Data
{
    public class LayerNoGoContract : LayerContract
    {
        public bool IsNoGO { get; set; }
    }
}
