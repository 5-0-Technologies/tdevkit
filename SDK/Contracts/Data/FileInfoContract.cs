using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Contracts.Data
{
    public class FileInfoContract
    {
        public string Version { get; set; }

        public long Size { get; set; }

        public string Name { get; set; }
    }
}
