using SDK.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

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

        public bool IsNoGo { get; set; }
        public string ExternalId { get; set; }

        public static explicit operator LayerWriteContract(LayerContract contract)
        {
            return new LayerWriteContract
            {
                Title = contract.Title,
                Created = contract.Created,
                Icon = contract.Icon,
                Visible = contract.Visible,
                Localization = contract.Localization,
                Updated = contract.Updated,
                ExternalId = contract.ExternalId,
                Areas = contract.Areas.Select(area => area.Id).ToHashSet(),
                Paths = contract.Devices.Select(device => device.Id).ToHashSet(),
            };
        }
    }

    public class LayerWriteContract
    {
        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        public string Icon { get; set; }

        public bool Visible { get; set; }

        public bool Localization { get; set; }

        public long Created { get; set; }

        public long Updated { get; set; }
        /// <summary>
        /// An array of <b>Area Ids</b> to associate with this <b>Layer</b>.
        /// </summary>
        public HashSet<int> Areas { get; set; }

        /// <summary>
        /// An array of <b>Device Ids</b> to associate with this <b>Layer</b>.
        /// </summary>
        public HashSet<int> Devices { get; set; }

        /// <summary>
        /// An array of <b>Path Ids</b> to associate with this <b>Layer</b>.
        /// </summary>
        public HashSet<int> Paths { get; set; }

        /// <summary>
        /// An array of <b>Layer Ids</b> that are children of this <b>Layer</b>.
        /// </summary>
        public HashSet<int> Children { get; set; }

        [StringLength(255)]
        public string ExternalId { get; set; }
    }
}
