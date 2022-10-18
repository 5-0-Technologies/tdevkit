using System;

namespace SDK.Models
{
    public class ClientContract
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Title { get; set; }

        public string DBName { get; set; }
    }
}
