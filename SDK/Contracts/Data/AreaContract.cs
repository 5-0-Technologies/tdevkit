using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Models
{
    [DataContract]
    public class AreaContract
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Title { get; set; }

        public int SectorId { get; set; }

        public int BranchId { get; set; }

        public int LayerId { get; set; }

        public string Color { get; set; }

        public CoordinatesContract[] Coordinates { get; set; }
    }

    public class CoordinatesContract
    {
        public double X { get; set; }

        public double Y { get; set; }
    }
}
