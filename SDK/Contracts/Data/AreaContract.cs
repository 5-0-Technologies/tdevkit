using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Models
{
    public class AreaContract
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Title { get; set; }

        public int SectorId { get; set; }

        public int BranchId { get; set; }

        public int LayerId { get; set; }

        public string Color { get; set; }

        public PointContract[] Coordinates { get; set; }

        public string Description { get; set; }

        public long Created { get; set; }

        public long Updated { get; set; }
    }

    public class PointContract
    {
        public double X { get; set; }

        public double Y { get; set; }
    }
}
