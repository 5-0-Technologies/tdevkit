namespace SDK.Communication
{
    public class SensorDataResponseContract
    {
        public string Quantity { get; set; }

        public long Timestamp { get; set; }

        public bool Success { get; set; }

        public string Action { get; set; }

        public string ErrorMessage { get; set; }
    }
}
