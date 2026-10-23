using System;
using System.Collections.Generic;

namespace SDK.Contracts.Data.Analytics
{
    public class DeviceStatContract
    {
        public int DeviceId { get; set; }
        public string DeviceTitle { get; set; }
        public int? DeviceTypeId { get; set; }
        public float? Battery { get; set; }
        public long? LastTimeOnline { get; set; }
        public long? Moving { get; set; }
        public long? Waiting { get; set; }
        public long? Online { get; set; }
        public long? Offline { get; set; }
        public long? Pallet { get; set; }
        public long? MovingWithOrder { get; set; }
        public long? WaitingWithOrder { get; set; }
        public long? MovingWithoutOrder { get; set; }
        public long? WaitingWithoutOrder { get; set; }
        public long? AverageOrderTimeMs { get; set; }
        public long? AverageOrderWorkTimeMs { get; set; }
        public float? OEE { get; set; }
        public float? TargetOEE { get; set; }
        public float? KPI { get; set; }
        public float? BranchOeeCoef { get; set; }
        public float? DeviceOeeCoef { get; set; }
    }

    public class ActivitySummaryContract
    {
        public DateTime Date { get; set; }
        public double? Value { get; set; }
        public string Shift { get; set; }
        public string Device { get; set; }
        public string Type { get; set; }
    }

    public class ActivityDurationContract
    {
        public DateTime Date { get; set; }
        public string Device { get; set; }
        public long Start { get; set; }
        public long Stop { get; set; }
        public bool IsMoving { get; set; }
        public long Duration { get; set; }
    }

    public class ActivityContract
    {
        public long Date { get; set; }
        public long Timestamp { get; set; }
        public long DrivingPallet { get; set; }
        public long DrivingNoPallet { get; set; }
        public long WaitingPallet { get; set; }
        public long WaitingNoPallet { get; set; }
        public long NoData { get; set; }
    }

    public class ActivityStatusContract
    {
        public long Date { get; set; }
        public double Driving { get; set; }
        public double Online { get; set; }
        public double Pallet { get; set; }
    }

    public class ShiftSummaryContract
    {
        public DateTime Date { get; set; }
        public double TotalOEE { get; set; }
    }

    public class DeviceOverviewContract
    {
        public int DeviceId { get; set; }
        public int? DeviceTypeId { get; set; }
        public long Date { get; set; }
        public string Shift { get; set; }
        public double? Oee { get; set; }
        public int? AreaId { get; set; }
        public int? LayerId { get; set; }
        public int? AcceptedCount { get; set; }
        public int? DeliveredCount { get; set; }
        public long? AverageDeliveryTime { get; set; }
    }

    public class SectorOccurrenceContract
    {
        public long Date { get; set; }
        public string Shift { get; set; }
        public string Device { get; set; }
        public string Sector { get; set; }
        public long Duration { get; set; }
        public int Occurrences { get; set; }
    }

    public class AosDowntimeTrendPointContract
    {
        public long? Timestamp { get; set; }
        public string Day { get; set; }
        public double Utilization { get; set; }
    }

    public class AosDowntimeTrendsContract
    {
        public List<AosDowntimeTrendPointContract> Granularity { get; set; }
        public List<AosDowntimeTrendPointContract> DailyCurrent { get; set; }
        public List<AosDowntimeTrendPointContract> DailyPrevious { get; set; }
    }

    public class AosDowntimeBundleContract
    {
        public List<DeviceStatContract> DeviceStats { get; set; }
        public AosDowntimeTrendsContract Trends { get; set; }
    }

    public class AosDowntimeOrderContract
    {
        public byte Kind { get; set; }
        public int OrderId { get; set; }
        public byte Status { get; set; }
        public long Created { get; set; }
        public long? WaitMs { get; set; }
        public int? ItemCount { get; set; }
        public string ItemList { get; set; }
    }

    public class OrderCountsRequest
    {
        public long Start { get; set; }
        public long Stop { get; set; }
        public IEnumerable<int> OrderStatuses { get; set; }
        public IEnumerable<int> WorkRoles { get; set; }
        public IEnumerable<int> FromWorkRoles { get; set; }
        public IEnumerable<int> ToWorkRoles { get; set; }
    }
}
