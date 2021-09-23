namespace SDK.Contracts.Data
{
    public class ShiftContract
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int BranchId { get; set; }

        public long StartTime { get; set; }

        public long StopTime { get; set; }
    }
}
