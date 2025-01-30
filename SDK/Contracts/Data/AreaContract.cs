using System;
using System.ComponentModel.DataAnnotations;

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
        public string ExternalId { get; set; }

        public static explicit operator AreaWriteContract(AreaContract contract)
        {
            return new AreaWriteContract
            {
                Title = contract.Title,
                Created = contract.Created,
                Updated = contract.Updated,
                ExternalId = contract.ExternalId,
                Description = contract.Description,
                Coordinates = contract.Coordinates,
                Color = contract.Color,
                LayerId = contract.LayerId,
                SectorId = contract.SectorId,
                Guid = contract.Guid,
            };
        }
    }

    public class PointContract
    {
        public double X { get; set; }

        public double Y { get; set; }
    }

    public class AreaWriteContract
    {
        public Guid Guid { get; set; }

        [Required]
        public string Title { get; set; }

        public int SectorId { get; set; }

        public int? LayerId { get; set; }

        [StringLength(25)]
        public string Color { get; set; }

        public PointContract[] Coordinates { get; set; }

        public string Description { get; set; }

        public long Created { get; set; }

        public long Updated { get; set; }

        public int? TargetBranchId { get; set; }

        [StringLength(25)]
        public string ExternalId { get; set; }
    }
}
