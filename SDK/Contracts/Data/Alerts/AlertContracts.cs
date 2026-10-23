using SDK.Contracts.Data;
using SDK.Enum;
using SDK.Models;
using System.Collections.Generic;

namespace SDK.Contracts.Data.Alerts
{
    public class CheckContract
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string RuleLevel { get; set; }
        public List<SensorContract> Sensors { get; set; }
        public bool Active { get; set; }
        public object[] Rule { get; set; }
    }

    public class CheckWriteContract
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string RuleLevel { get; set; }
        public HashSet<int> Sensors { get; set; }
        public bool Active { get; set; }
        public object[] Rule { get; set; }
    }

    public class NotificationContract
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public int CheckId { get; set; }
        public string ToLevel { get; set; }
        public string FromLevel { get; set; }
        public string WhenStatus { get; set; }
        public List<UserContract> Users { get; set; }
        public bool Active { get; set; }
        public int? LayerId { get; set; }
        public NotificationDeliveryType DeliveryType { get; set; }
    }

    public class NotificationWriteContract
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int CheckId { get; set; }
        public string ToLevel { get; set; }
        public string FromLevel { get; set; }
        public string WhenStatus { get; set; }
        public HashSet<int> Users { get; set; }
        public bool Active { get; set; }
        public int? LayerId { get; set; }
        public NotificationDeliveryType DeliveryType { get; set; }
    }
}
