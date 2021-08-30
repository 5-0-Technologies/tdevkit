using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Models
{
    public class DynamicDeviceContract
    {
        public string Id { get; set; }

        public string Login { get; set; }

        public string Title { get; set; }

        public int SectorId { get; set; }

        public string Type { get; set; }

        public double X { get; set; }

        public double Y { get; set; }

        public int FallStatus { get; set; }
    }
}
