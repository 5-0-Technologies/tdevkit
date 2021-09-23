namespace SDK.Models
{
    public class BranchContract
    {
        public int Id { get; set; }

        public string Guid { get; set; }

        public string Title { get; set; }

        public string Timezone { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public SectorContract[] Sectors { get; set; }
    }
}
