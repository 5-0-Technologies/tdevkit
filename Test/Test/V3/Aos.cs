using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDK;
using SDK.Contracts.Data.Aos;
using SDK.Contracts.Data.Aos.V4;
using SDK.Exceptions;
using SDK.Models;
using System;
using System.Threading.Tasks;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;

namespace Test.V3
{
    [TestClass]
    public class Aos : Requests
    {
        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosConnect_ErrorHandling_ShouldThrowsException()
        {
            var bodyContent = new ProblemDetails { Title = "Aos error", Detail = "Failed." };

            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/connect/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(400).WithBodyAsJson(bodyContent));
            await Assert.ThrowsExceptionAsync<ServerResponseException>(
                async () => await devkitConnector.AosConnect(new AOS_ConnectContract()));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetOrders_V5_ShouldUseAnalyticsPath()
        {
            server.Reset();
            server.Given(Request.Create()
                    .WithPath(PATH_BASE + "analytics/aos/orders")
                    .WithParam("start", "1")
                    .WithParam("stop", "2")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(TestData.Aos.GetOrders()));

            var response = await devkitConnector.GetOrders(1, 2);
            Assert.IsInstanceOfType(response, typeof(OrderDataContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetOrders_V3_ShouldUseLegacyPath()
        {
            var options = new ConnectionOptionsBuilder()
                .Url(URL + "/api")
                .Client("Infotech")
                .ClientGuid("00000000-0000-0000-0000-000000000001")
                .BranchGuid("00000000-0000-0000-0000-000000000003")
                .Timeout(1000)
                .ApiKey("X1fprPtlkvolW1Bl47UQV4SoW8siY3n8QDQkDsGJ")
                .Version(ConnectionOptions.VERSION_3)
                .Build();
            var v3 = (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(options);

            server.Reset();
            server.Given(Request.Create()
                    .WithPath("/api/v3/aos/v2/data/orders/")
                    .WithParam("start", "1")
                    .WithParam("stop", "2")
                    .UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(TestData.Aos.GetOrders()));

            var response = await v3.GetOrders(1, 2);
            Assert.IsInstanceOfType(response, typeof(OrderDataContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosConnect_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/connect/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_NodeInfoContract()));

            var response = await devkitConnector.AosConnect(new AOS_ConnectContract());
            Assert.IsInstanceOfType(response, typeof(AOS_NodeInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosDisconnect_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/disconnect/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200));

            await devkitConnector.AosDisconnect();
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosCreate_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/create/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosCreate(new AOS_CreateActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosCreateAndSplit_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/create-and-split/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract[0]));

            var response = await devkitConnector.AosCreateAndSplit(new AOS_CreateActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosSendTo_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/send-to/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosSendTo(new AOS_SendToActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosSendToBatch_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/send-to/batch/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract[0]));

            var response = await devkitConnector.AosSendToBatch(new[] { new AOS_SendToActionContract() });
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosAccept_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/accept/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosAccept(new AOS_AcceptActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosAbort_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/abort/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosAbort(new AOS_AbortActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosDeliver_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/deliver/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosDeliver(new AOS_DeliverActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosComplete_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/complete/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosComplete(new AOS_CompleteActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosDiscard_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/discard/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosDiscard(new AOS_DiscardActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosMemberOrders_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/member/orders").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract[0]));

            var response = await devkitConnector.GetAosMemberOrders();
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosOrders_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/orders").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract[0]));

            var response = await devkitConnector.GetAosOrders();
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosOrder_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/order").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new OrderInfoContract[0]));

            var response = await devkitConnector.GetAosOrder();
            Assert.IsInstanceOfType(response, typeof(OrderInfoContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosOrderHistory_ShouldReturn200()
        {
            var guid = Guid.Parse("00000000-0000-0000-0000-0000000000aa");
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/orders/" + guid + "/history").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderEventContract[0]));

            var response = await devkitConnector.GetAosOrderHistory(guid);
            Assert.IsInstanceOfType(response, typeof(AOS_OrderEventContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosNodeInfo_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/node-info/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_NodeInfoContract()));

            var response = await devkitConnector.GetAosNodeInfo();
            Assert.IsInstanceOfType(response, typeof(AOS_NodeInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosTargets_ShouldReturn200()
        {
            var guid = Guid.Parse("00000000-0000-0000-0000-0000000000bb");
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/targets/" + guid).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_WorkRoleContract[0]));

            var response = await devkitConnector.GetAosTargets(guid);
            Assert.IsInstanceOfType(response, typeof(AOS_WorkRoleContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosWorkRoles_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/work-roles/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_WorkRoleContract[0]));

            var response = await devkitConnector.GetAosWorkRoles();
            Assert.IsInstanceOfType(response, typeof(AOS_WorkRoleContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosWorkGroups_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/work-groups/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new WorkGroupContract[0]));

            var response = await devkitConnector.GetAosWorkGroups();
            Assert.IsInstanceOfType(response, typeof(WorkGroupContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosItemAreas_ShouldReturn200()
        {
            const int ItemId = 5;
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/items/" + ItemId + "/areas").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AreaContract[0]));

            var response = await devkitConnector.GetAosItemAreas(ItemId);
            Assert.IsInstanceOfType(response, typeof(AreaContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleCreate_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/create/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosMultiRoleCreate(new AOS_MultiRoleCreateActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleCreateAndSplit_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/create-and-split/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract[0]));

            var response = await devkitConnector.AosMultiRoleCreateAndSplit(new AOS_MultiRoleCreateActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleSendTo_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/send-to/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosMultiRoleSendTo(new AOS_MultiRoleSendToActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleSendToBatch_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/send-to/batch/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract[0]));

            var response = await devkitConnector.AosMultiRoleSendToBatch(new[] { new AOS_MultiRoleSendToActionContract() });
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleAccept_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/accept/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosMultiRoleAccept(new AOS_MultiRoleAcceptActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleAbort_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/abort/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosMultiRoleAbort(new AOS_MultiRoleAbortActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleDeliver_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/deliver/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosMultiRoleDeliver(new AOS_MultiRoleDeliverActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleComplete_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/complete/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosMultiRoleComplete(new AOS_MultiRoleCompleteActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleDiscard_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/discard/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract()));

            var response = await devkitConnector.AosMultiRoleDiscard(new AOS_MultiRoleDiscardActionContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleOrders_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/orders/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_OrderInfoContract[0]));

            var response = await devkitConnector.AosMultiRoleOrders(new AOS_ConnectIdContract());
            Assert.IsInstanceOfType(response, typeof(AOS_OrderInfoContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosMultiRoleNodeInfo_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/node-info/1/login1").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new NodeInfoContract()));

            var response = await devkitConnector.GetAosMultiRoleNodeInfo(1, "login1");
            Assert.IsInstanceOfType(response, typeof(NodeInfoContract));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task AosMultiRoleConnectionMembers_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/connection/members/").UsingPost())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_MemberContract[0]));

            var response = await devkitConnector.AosMultiRoleConnectionMembers(new AOS_ConnectIdContract());
            Assert.IsInstanceOfType(response, typeof(AOS_MemberContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosMultiRoleTargets_ShouldReturn200()
        {
            var guid = Guid.Parse("00000000-0000-0000-0000-0000000000cc");
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/targets/" + guid).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_WorkRoleContract[0]));

            var response = await devkitConnector.GetAosMultiRoleTargets(guid);
            Assert.IsInstanceOfType(response, typeof(AOS_WorkRoleContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosMultiRoleWorkRoles_ShouldReturn200()
        {
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/work-roles/").UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_WorkRoleContract[0]));

            var response = await devkitConnector.GetAosMultiRoleWorkRoles();
            Assert.IsInstanceOfType(response, typeof(AOS_WorkRoleContract[]));
        }

        [TestCategory("Aos")]
        [TestMethod]
        public async Task GetAosMultiRoleWorkRoles_ByOrderGuid_ShouldReturn200()
        {
            var guid = Guid.Parse("00000000-0000-0000-0000-0000000000dd");
            server.Reset();
            server.Given(Request.Create().WithPath(PATH_BASE + "aos/multirole/work-roles/" + guid).UsingGet())
                .RespondWith(Response.Create().WithStatusCode(200).WithBodyAsJson(new AOS_WorkRoleContract[0]));

            var response = await devkitConnector.GetAosMultiRoleWorkRoles(guid);
            Assert.IsInstanceOfType(response, typeof(AOS_WorkRoleContract[]));
        }
    }
}
