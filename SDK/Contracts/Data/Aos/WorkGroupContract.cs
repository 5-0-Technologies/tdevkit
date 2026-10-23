using System;
using System.Collections.Generic;

namespace SDK.Contracts.Data.Aos
{
    public class WorkGroupContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<NodeContract> Nodes { get; set; }
    }

    public class NodeContract
    {
        public Guid NodeGuid { get; set; }

        public string WorkRole { get; set; }

        public bool IsStartNode { get; set; }

        public bool IsStartNodeLock { get; set; }
    }

    public class NodeInfoContract
    {
        public Guid Guid { get; set; }

        public string WorkRole { get; set; }

        public int WorkRoleId { get; set; }

        public bool Order { get; set; }

        public bool SendTo { get; set; }

        public bool SendBack { get; set; }

        public bool Accept { get; set; }

        public bool Abort { get; set; }

        public bool Complete { get; set; }

        public bool Discard { get; set; }

        public bool AutoSend { get; set; }

        public bool AutoItemSelection { get; set; }

        public List<PackageContract> Packages { get; set; }
    }

    public class PackageContract
    {
        public string Title { get; set; }

        public List<ItemContract> Items { get; set; }

        public int SortIndex { get; set; }
    }
}
