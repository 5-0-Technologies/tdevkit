using System;

namespace SDK.Models
{
    public class PathContract
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Title { get; set; }

        public int SectorId { get; set; }


        public int BranchId { get; set; }


        public int? LayerId { get; set; }


        public string Color { get; set; }

        public PathPointContract[] PathPoints { get; set; }

        public string Description { get; set; }

        public long Created { get; set; }

        public long Updated { get; set; }
    }

    public class PathPointContract
    {
        public int Id { get; set; }

        public int PathId { get; set; }

        public int BranchId { get; set; }

        public int Index { get; set; }

        public float X { get; set; }

        public float Y { get; set; }
    }
}