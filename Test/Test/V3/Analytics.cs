using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK.Contracts.Data.Analytics;
using SDK.Contracts.Data.Aos;
using SDK.Exceptions;
using SDK.Models;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Analytics : Requests
    {
        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDeviceStatistics_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails { Title = "Analytics error", Detail = "Failed." };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/device-statistics").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(
                async () => await devkitConnector.GetDeviceStatistics(1, 2));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDeviceStatistics_ShouldReturn200_WithDeviceIdsAndFlags()
        {
            server.Reset();
            server.Given(Request.Create()
                    .WithPath(PATH_BASE + "analytics/device-statistics")
                    .WithParam("start", "1")
                    .WithParam("stop", "2")
                    .WithParam("deviceIds", "10", "20")
                    .WithParam("includeOrderStats", "True")
                    .WithParam("includePallet", "True")
                    .WithParam("includeOrderCompletionStats", "True")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new[] { new DeviceStatContract() }));

            var response = await devkitConnector.GetDeviceStatistics(1, 2, new[] { 10, 20 });
            Assert.IsInstanceOfType(response, typeof(DeviceStatContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDowntimeBundle_ShouldReturn200_WithoutDeviceIds()
        {
            server.Reset();
            server.Given(Request.Create()
                    .WithPath(PATH_BASE + "analytics/downtime-bundle")
                    .WithParam("start", "1")
                    .WithParam("stop", "2")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AosDowntimeBundleContract()));

            var response = await devkitConnector.GetDowntimeBundle(1, 2);
            Assert.IsInstanceOfType(response, typeof(AosDowntimeBundleContract));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetSectorOccurrence_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/sector-occurrence").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new SectorOccurrenceContract[0]));

            var response = await devkitConnector.GetSectorOccurrence(1, 1, 2);
            Assert.IsInstanceOfType(response, typeof(SectorOccurrenceContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetGridSectorOccurrence_ShouldReturn200_WithIdArrays()
        {
            server.Reset();
            server.Given(Request.Create()
                    .WithPath(PATH_BASE + "analytics/grid-sector-occurrence")
                    .WithParam("start", "1")
                    .WithParam("stop", "2")
                    .WithParam("deviceIds", "10", "20")
                    .WithParam("shiftIds", "3", "4")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new SectorOccurrenceContract[0]));

            var response = await devkitConnector.GetGridSectorOccurrence(1, 2, new[] { 10, 20 }, new[] { 3, 4 });
            Assert.IsInstanceOfType(response, typeof(SectorOccurrenceContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetAreaOccurrence_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/area-occurrence").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AreaOccurrence[0]));

            var response = await devkitConnector.GetAreaOccurrence(1, 1, 2);
            Assert.IsInstanceOfType(response, typeof(AreaOccurrence[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetAnalyticsGridAreaOccurrence_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/grid-area-occurrence").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AreaOccurrence[0]));

            var response = await devkitConnector.GetAnalyticsGridAreaOccurrence(1, 2);
            Assert.IsInstanceOfType(response, typeof(AreaOccurrence[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDeviceActivity_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/device-activity").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new ActivityContract[0]));

            var response = await devkitConnector.GetDeviceActivity(1, 1, 2);
            Assert.IsInstanceOfType(response, typeof(ActivityContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDeviceActivityStatus_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/device-activity-status").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new ActivityStatusContract[0]));

            var response = await devkitConnector.GetDeviceActivityStatus(1, 1, 2);
            Assert.IsInstanceOfType(response, typeof(ActivityStatusContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetActivitySummary_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/activity-summary").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new ActivitySummaryContract[0]));

            var response = await devkitConnector.GetActivitySummary(1, 2);
            Assert.IsInstanceOfType(response, typeof(ActivitySummaryContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetActivityDuration_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/activity-duration").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new ActivityDurationContract[0]));

            var response = await devkitConnector.GetActivityDuration(1, 2);
            Assert.IsInstanceOfType(response, typeof(ActivityDurationContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDevicesActivity_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/devices-activity").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new DevicesActivityContract()));

            var response = await devkitConnector.GetDevicesActivity(1, 2);
            Assert.IsInstanceOfType(response, typeof(DevicesActivityContract));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDevicePerShift_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/device-per-shift").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new DevicePerShiftResponseContract()));

            var response = await devkitConnector.GetDevicePerShift(1, 2, 60);
            Assert.IsInstanceOfType(response, typeof(DevicePerShiftResponseContract));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetShiftSummary_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/shift-summary").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new ShiftSummaryContract[0]));

            var response = await devkitConnector.GetShiftSummary(1, 2, 60);
            Assert.IsInstanceOfType(response, typeof(ShiftSummaryContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDeviceOverview_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/device-overview").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new DeviceOverviewContract[0]));

            var response = await devkitConnector.GetDeviceOverview(1, 2);
            Assert.IsInstanceOfType(response, typeof(DeviceOverviewContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetAosOrderAnalytics_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/aos/orders").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new OrderDataContract[0]));

            var response = await devkitConnector.GetAosOrderAnalytics(1, 2);
            Assert.IsInstanceOfType(response, typeof(OrderDataContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetAosDowntimeOrders_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/aos/downtime-orders").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AosDowntimeOrderContract[0]));

            var response = await devkitConnector.GetAosDowntimeOrders(1, 2);
            Assert.IsInstanceOfType(response, typeof(AosDowntimeOrderContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetAosOrderActions_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/aos/orders-actions").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new OrdersActionsDataContract[0]));

            var response = await devkitConnector.GetAosOrderActions(1);
            Assert.IsInstanceOfType(response, typeof(OrdersActionsDataContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetAosOrderItems_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/aos/orders-items").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new OrdersItemsDataContract[0]));

            var response = await devkitConnector.GetAosOrderItems(1);
            Assert.IsInstanceOfType(response, typeof(OrdersItemsDataContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetAosOrderCounts_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/aos/order-counts").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AosOrderCountsWorkflowContract[0]));

            var response = await devkitConnector.GetAosOrderCounts(new OrderCountsRequest { Start = 1, Stop = 2 });
            Assert.IsInstanceOfType(response, typeof(AosOrderCountsWorkflowContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDeviceAssignedOrdersHourly_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/aos/device-assigned-orders-hourly").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AssignedAosOrderContract[0]));

            var response = await devkitConnector.GetDeviceAssignedOrdersHourly(1, 2, 3);
            Assert.IsInstanceOfType(response, typeof(AssignedAosOrderContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDeviceFirstLastActivity_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/aos/device-first-last-activity").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new DeviceFirstLastActivityContract()));

            var response = await devkitConnector.GetDeviceFirstLastActivity(1, 2, 3);
            Assert.IsInstanceOfType(response, typeof(DeviceFirstLastActivityContract));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetDeviceOrderWorkIntervals_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/aos/device-order-work-intervals").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new DeviceActivityOrderInfoContract[0]));

            var response = await devkitConnector.GetDeviceOrderWorkIntervals(1, 2, 3);
            Assert.IsInstanceOfType(response, typeof(DeviceActivityOrderInfoContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetPackageItemLocations_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create()
                    .WithPath(PATH_BASE + "analytics/aos/package-item-locations")
                    .WithParam("packageId", "9")
                    .WithParam("itemIds", "1", "2")
                    .WithParam("sectorIds", "3", "4")
                    .WithParam("start", "1")
                    .WithParam("stop", "2")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new SimpleLocationContract[0]));

            var response = await devkitConnector.GetPackageItemLocations(9, new[] { 1, 2 }, new[] { 3, 4 }, 1, 2);
            Assert.IsInstanceOfType(response, typeof(SimpleLocationContract[]));
        }

        [TestCategory("Analytics")]
        [TestMethod]
        public async Task GetPackageItemRides_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "analytics/aos/package-item-rides").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new PackageItemRideContract[0]));

            var response = await devkitConnector.GetPackageItemRides(9, new[] { 1, 2 }, 1, 2);
            Assert.IsInstanceOfType(response, typeof(PackageItemRideContract[]));
        }
    }
}
