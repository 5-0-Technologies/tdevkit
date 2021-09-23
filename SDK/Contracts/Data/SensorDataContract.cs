namespace SDK.Models
{
    public class SensorDataContract
    {
        public int Id { get; set; }

        public string Quantity { get; set; }

        public string Value { get; set; }

        public string Unit { get; set; }

        public string DataType { get; set; }

        public long Timestamp { get; set; }

        //public object Range { get; set; }
    }
}
