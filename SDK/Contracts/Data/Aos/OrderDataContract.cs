namespace SDK.Contracts.Data.Aos
{
    public class OrderDataContract
    {
        public int OrderId { get; set; }

        public byte Status { get; set; }

        public int? CreatedBy { get; set; }

        public int? LastUpdatedBy { get; set; }

        public long? Duration { get; set; }

        public int? ItemCount { get; set; }

        public string ItemList { get; set; }

        public long Created { get; set; }

        public long Updated { get; set; }

        public string Notes { get; set; }
    }
}