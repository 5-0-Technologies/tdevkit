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

        public PathEdgeContract[] PathEdges { get; set; }

        public string Description { get; set; }

        public long Created { get; set; }

        public long Updated { get; set; }

        public string Tags { get; set; }
    }

    public class PathPointContract
    {
        public int Id { get; set; }

        public int PathId { get; set; }

        public int BranchId { get; set; }

        public int Index { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public float Z { get; set; }

        public int? AreaId { get; set; }
    }

    public class PathEdgeContract
    {
        public int Id { get; set; }

        public int PathId { get; set; }

        public int BranchId { get; set; }

        public int FromPathPointId { get; set; }

        public int ToPathPointId { get; set; }

        public bool IsBidirectional { get; set; }

        public bool IsSequential { get; set; }

        public float? Weight { get; set; }
    }
}