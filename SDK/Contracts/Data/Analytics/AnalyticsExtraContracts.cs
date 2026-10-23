using SDK.Enum;
using System.Collections.Generic;

namespace SDK.Contracts.Data.Analytics
{
    public class KeyValueContract<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    public class SerieKeyValueContract<TKey, TValue>
    {
        public string Serie { get; set; }
        public TKey Key { get; set; }
        public TValue Value { get; set; }
    }

    public class MovingPointContract
    {
        public string Object { get; set; }
        public double Moving { get; set; }
        public double Idle { get; set; }
        public double NoData { get; set; }
    }

    public class OnlinePointContract
    {
        public string Object { get; set; }
        public double Online { get; set; }
        public double Offline { get; set; }
    }

    public class MovingWaitingOrderPointContract
    {
        public int DeviceId { get; set; }
        public string Object { get; set; }
        public double MovingWithOrder { get; set; }
        public double MovingWithoutOrder { get; set; }
        public double WaitingWithOrder { get; set; }
        public double WaitingWithoutOrder { get; set; }
        public double NoData { get; set; }
    }

    public class PercentageAssignedAosOrderContract
    {
        public double AssignedOrder { get; set; }
        public double UnassignedOrder { get; set; }
        public double NoData { get; set; }
        public string Object { get; set; }
    }

    public class DevicesActivityContract
    {
        public List<SerieKeyValueContract<long, double>> DeviceMovingPerGranularity { get; set; }
        public List<MovingPointContract> TotalMovingPerDevice { get; set; }
        public List<OnlinePointContract> TotalOnlinePerDevice { get; set; }
        public List<PercentageAssignedAosOrderContract> TotalAssignedOrderPerDevice { get; set; }
        public List<KeyValueContract<string, double>> TotalMoving { get; set; }
        public List<KeyValueContract<string, double>> TotalOnline { get; set; }
        public List<KeyValueContract<string, double>> TotalAssignedOrder { get; set; }
        public List<MovingWaitingOrderPointContract> TotalMovingWaitingOrderPerDevice { get; set; }
        public List<KeyValueContract<string, double>> TotalMovingWaitingOrder { get; set; }
        public double TotalMean { get; set; }
        public double TotalMedian { get; set; }
        public long Granularity { get; set; }
        public long StartDate { get; set; }
        public long StopDate { get; set; }
        public long TimeRange { get; set; }
    }

    public class DevicePerShiftContract
    {
        public long RealTimestamp { get; set; }
        public long DayTimestamp { get; set; }
        public long ArgumentTimestamp { get; set; }
        public bool DeviceData { get; set; }
        public Dictionary<string, double> Properties { get; set; }
    }

    public class DevicePerShiftResponseContract
    {
        public List<DevicePerShiftContract> data { get; set; }
    }

    public class OrdersActionsDataContract
    {
        public int CreatedBy { get; set; }
        public int? WorkRoleId { get; set; }
        public byte Status { get; set; }
        public long? Duration { get; set; }
        public long Created { get; set; }
        public string Note { get; set; }
    }

    public class OrdersItemsDataContract
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public long Created { get; set; }
        public int Pieces { get; set; }
    }

    public class AosOrderCountsWorkflowContract
    {
        public int FromWorkRoleId { get; set; }
        public int ToWorkRoleId { get; set; }
        public OrderStatus2 Status { get; set; }
        public int Count { get; set; }
    }

    public class AssignedAosOrderContract
    {
        public long Date { get; set; }
        public long AssignedOrder { get; set; }
        public long UnassignedOrder { get; set; }
        public long NoData { get; set; }
        public string Object { get; set; }
    }

    public class DeviceActivityOrderInfoContract
    {
        public int OrderId { get; set; }
        public string PackageTitle { get; set; }
        public string WorkRoleTitle { get; set; }
        public long CreatedAt { get; set; }
        public long AcceptedAt { get; set; }
        public long? CompletedAt { get; set; }
        public int Status { get; set; }
        public string AreaTitle { get; set; }
    }

    public class DeviceFirstLastActivityContract
    {
        public DeviceActivityOrderInfoContract FirstActivity { get; set; }
        public DeviceActivityOrderInfoContract LastActivity { get; set; }
        public string FirstAreaInRange { get; set; }
        public string LastAreaInRange { get; set; }
    }

    public class PackageItemRideContract
    {
        public int OrderId { get; set; }
        public int DeviceId { get; set; }
        public string DeviceTitle { get; set; }
        public int PackageId { get; set; }
        public string PackageTitle { get; set; }
        public string Items { get; set; }
        public long Start { get; set; }
        public long Stop { get; set; }
    }
}
