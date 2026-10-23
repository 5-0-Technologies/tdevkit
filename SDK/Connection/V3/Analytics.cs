using SDK.Contracts.Data.Analytics;
using SDK.Contracts.Data.Aos;
using SDK.Models;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        private static string BuildQuery(params (string key, object value)[] pairs)
        {
            var parts = new System.Collections.Generic.List<string>();
            foreach (var (key, value) in pairs)
            {
                if (value == null) continue;
                if (value is int[] ids)
                {
                    foreach (var id in ids)
                        parts.Add($"{key}={id}");
                }
                else if (value is string[] strs)
                {
                    foreach (var s in strs)
                        parts.Add($"{key}={System.Uri.EscapeDataString(s)}");
                }
                else
                {
                    parts.Add($"{key}={value}");
                }
            }
            return parts.Count == 0 ? "" : "?" + string.Join("&", parts);
        }

        public async Task<DeviceStatContract[]> GetDeviceStatistics(long start, long stop, int[] deviceIds = null,
            bool includeOrderStats = true, bool includePallet = true, bool includeOrderCompletionStats = true)
        {
            string qs = BuildQuery(
                ("start", start), ("stop", stop), ("deviceIds", deviceIds),
                ("includeOrderStats", includeOrderStats), ("includePallet", includePallet),
                ("includeOrderCompletionStats", includeOrderCompletionStats));
            return await GetRequest<DeviceStatContract[]>(Address.AnalyticsDeviceStatistics + qs);
        }

        public async Task<AosDowntimeBundleContract> GetDowntimeBundle(long start, long stop, int[] deviceIds = null)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("deviceIds", deviceIds));
            return await GetRequest<AosDowntimeBundleContract>(Address.AnalyticsDowntimeBundle + qs);
        }

        public async Task<SectorOccurrenceContract[]> GetSectorOccurrence(int deviceId, long start, long stop)
        {
            string qs = BuildQuery(("deviceId", deviceId), ("start", start), ("stop", stop));
            return await GetRequest<SectorOccurrenceContract[]>(Address.AnalyticsSectorOccurrence + qs);
        }

        public async Task<SectorOccurrenceContract[]> GetGridSectorOccurrence(long start, long stop, int[] deviceIds = null, int[] shiftIds = null)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("deviceIds", deviceIds), ("shiftIds", shiftIds));
            return await GetRequest<SectorOccurrenceContract[]>(Address.AnalyticsGridSectorOccurrence + qs);
        }

        public async Task<AreaOccurrence[]> GetAreaOccurrence(int deviceId, long start, long stop, int[] layerIds = null)
        {
            string qs = BuildQuery(("deviceId", deviceId), ("start", start), ("stop", stop), ("layerIds", layerIds));
            return await GetRequest<AreaOccurrence[]>(Address.AnalyticsAreaOccurrence + qs);
        }

        public async Task<AreaOccurrence[]> GetAnalyticsGridAreaOccurrence(long start, long stop, int[] deviceIds = null, int[] shiftIds = null)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("deviceIds", deviceIds), ("shiftIds", shiftIds));
            return await GetRequest<AreaOccurrence[]>(Address.AnalyticsGridAreaOccurrence + qs);
        }

        public async Task<ActivityContract[]> GetDeviceActivity(int deviceId, long start, long stop)
        {
            string qs = BuildQuery(("deviceId", deviceId), ("start", start), ("stop", stop));
            return await GetRequest<ActivityContract[]>(Address.AnalyticsDeviceActivity + qs);
        }

        public async Task<ActivityStatusContract[]> GetDeviceActivityStatus(int deviceId, long start, long stop)
        {
            string qs = BuildQuery(("deviceId", deviceId), ("start", start), ("stop", stop));
            return await GetRequest<ActivityStatusContract[]>(Address.AnalyticsDeviceActivityStatus + qs);
        }

        public async Task<ActivitySummaryContract[]> GetActivitySummary(long start, long stop, int[] deviceIds = null, int[] shiftIds = null)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("deviceIds", deviceIds), ("shiftIds", shiftIds));
            return await GetRequest<ActivitySummaryContract[]>(Address.AnalyticsActivitySummary + qs);
        }

        public async Task<ActivityDurationContract[]> GetActivityDuration(long start, long stop, int[] deviceIds = null, int[] shiftIds = null)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("deviceIds", deviceIds), ("shiftIds", shiftIds));
            return await GetRequest<ActivityDurationContract[]>(Address.AnalyticsActivityDuration + qs);
        }

        public async Task<DevicesActivityContract> GetDevicesActivity(long start, long stop, int[] deviceIds = null)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("deviceIds", deviceIds));
            return await GetRequest<DevicesActivityContract>(Address.AnalyticsDevicesActivity + qs);
        }

        public async Task<DevicePerShiftResponseContract> GetDevicePerShift(long start, long stop, int granularity, int[] deviceIds = null, int[] shiftIds = null)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("granularity", granularity), ("deviceIds", deviceIds), ("shiftIds", shiftIds));
            return await GetRequest<DevicePerShiftResponseContract>(Address.AnalyticsDevicePerShift + qs);
        }

        public async Task<ShiftSummaryContract[]> GetShiftSummary(long start, long stop, int granularity, int[] deviceIds = null)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("granularity", granularity), ("deviceIds", deviceIds));
            return await GetRequest<ShiftSummaryContract[]>(Address.AnalyticsShiftSummary + qs);
        }

        public async Task<DeviceOverviewContract[]> GetDeviceOverview(long start, long stop)
        {
            string qs = BuildQuery(("start", start), ("stop", stop));
            return await GetRequest<DeviceOverviewContract[]>(Address.AnalyticsDeviceOverview + qs);
        }

        public async Task<OrderDataContract[]> GetAosOrderAnalytics(long start, long stop)
        {
            string qs = BuildQuery(("start", start), ("stop", stop));
            return await GetRequest<OrderDataContract[]>(Address.AnalyticsAosOrders + qs);
        }

        public async Task<AosDowntimeOrderContract[]> GetAosDowntimeOrders(long start, long stop)
        {
            string qs = BuildQuery(("start", start), ("stop", stop));
            return await GetRequest<AosDowntimeOrderContract[]>(Address.AnalyticsAosDowntimeOrders + qs);
        }

        public async Task<OrdersActionsDataContract[]> GetAosOrderActions(int orderId)
        {
            string qs = BuildQuery(("orderId", orderId));
            return await GetRequest<OrdersActionsDataContract[]>(Address.AnalyticsAosOrdersActions + qs);
        }

        public async Task<OrdersItemsDataContract[]> GetAosOrderItems(int orderId)
        {
            string qs = BuildQuery(("orderId", orderId));
            return await GetRequest<OrdersItemsDataContract[]>(Address.AnalyticsAosOrdersItems + qs);
        }

        public async Task<AosOrderCountsWorkflowContract[]> GetAosOrderCounts(OrderCountsRequest request)
        {
            return await PostRequest<AosOrderCountsWorkflowContract[]>(Address.AnalyticsAosOrderCounts, request);
        }

        public async Task<AssignedAosOrderContract[]> GetDeviceAssignedOrdersHourly(long start, long stop, int deviceId)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("deviceId", deviceId));
            return await GetRequest<AssignedAosOrderContract[]>(Address.AnalyticsAosDeviceAssignedOrdersHourly + qs);
        }

        public async Task<DeviceFirstLastActivityContract> GetDeviceFirstLastActivity(long start, long stop, int deviceId)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("deviceId", deviceId));
            return await GetRequest<DeviceFirstLastActivityContract>(Address.AnalyticsAosDeviceFirstLastActivity + qs);
        }

        public async Task<DeviceActivityOrderInfoContract[]> GetDeviceOrderWorkIntervals(long start, long stop, int deviceId)
        {
            string qs = BuildQuery(("start", start), ("stop", stop), ("deviceId", deviceId));
            return await GetRequest<DeviceActivityOrderInfoContract[]>(Address.AnalyticsAosDeviceOrderWorkIntervals + qs);
        }

        public async Task<SimpleLocationContract[]> GetPackageItemLocations(int packageId, int[] itemIds, int[] sectorIds, long start, long stop)
        {
            string qs = BuildQuery(("packageId", packageId), ("itemIds", itemIds), ("sectorIds", sectorIds), ("start", start), ("stop", stop));
            return await GetRequest<SimpleLocationContract[]>(Address.AnalyticsAosPackageItemLocations + qs);
        }

        public async Task<PackageItemRideContract[]> GetPackageItemRides(int packageId, int[] itemIds, long start, long stop)
        {
            string qs = BuildQuery(("packageId", packageId), ("itemIds", itemIds), ("start", start), ("stop", stop));
            return await GetRequest<PackageItemRideContract[]>(Address.AnalyticsAosPackageItemRides + qs);
        }
    }
}
