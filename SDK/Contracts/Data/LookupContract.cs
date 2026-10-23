namespace SDK.Models
{
    public class LookupContract
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }
    }

    public class LookupWriteContract
    {
        public int? ParentId { get; set; }

        public string Title { get; set; }

        public string Icon { get; set; }
    }

    public class GpsItemWriteContract
    {
        public int? SectorId { get; set; }

        public float? X { get; set; }

        public float? Y { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }
    }

    public class AnswerWrapperContract
    {
        public int Role { get; set; }

        public long Timestamp { get; set; }

        public AnswerContract[] Fields { get; set; }
    }

    public class AnswerContract
    {
        public string Version { get; set; }

        public System.Guid Guid { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }

    public class QuestionContract
    {
        public int Id { get; set; }

        public System.Guid Guid { get; set; }

        public string Version { get; set; }

        public string Label { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }
    }

    public class QuestionWrapperContract
    {
        public int WorkRoleId { get; set; }

        public long SurveyTimeout { get; set; }

        public QuestionContract[] Fields { get; set; }
    }

    public class DriverContract
    {
        public string DriverName { get; set; }

        public string PlateNumber { get; set; }

        public string OrderStatus { get; set; }

        public string Gate { get; set; }
    }
}
