using SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Data
{
    public class LayerContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }

        public int BranchId { get; set; }

        public bool Visible { get; set; }

        public bool Localization { get; set; }

        public long Created { get; set; }

        public long Updated { get; set; }

        public AreaContract[] Areas { get; set; }

        public DeviceContract[] Devices { get; set; }

        public bool IsNoGO { get; set; }
    }
}
