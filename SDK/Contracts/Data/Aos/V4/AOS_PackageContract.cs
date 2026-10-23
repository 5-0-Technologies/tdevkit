using System.Collections.Generic;

namespace SDK.Contracts.Data.Aos.V4
{
    public class AOS_PackageContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Create { get; set; }

        public bool SendTo { get; set; }

        public bool Deliver { get; set; }

        public bool Accept { get; set; }

        public bool Abort { get; set; }

        public bool Complete { get; set; }

        public bool Discard { get; set; }

        public List<AOS_ItemContract> Items { get; set; }

        public int Index { get; set; }
    }
}
