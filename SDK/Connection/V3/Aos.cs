using SDK.Contracts.Data;
using SDK.Contracts.Data.Aos;
using SDK.Contracts.Data.Aos.V4;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        /// <summary>Legacy v3 path (aos/v2/data/orders). Prefer analytics/aos/orders on v5.</summary>
        public virtual async Task<OrderDataContract[]> GetOrders(long start, long stop)
        {
            string subUrl = $"{Address.AosDataOrders}?start={start}&stop={stop}";
            return await GetRequest<OrderDataContract[]>(subUrl);
        }

        public async Task<AOS_NodeInfoContract> AosConnect(AOS_ConnectContract contract)
        {
            return await PostRequest<AOS_NodeInfoContract>(Address.AosConnect, contract);
        }

        public async Task AosDisconnect()
        {
            await PostRequest(Address.AosDisconnect);
        }

        public async Task<AOS_OrderInfoContract> AosCreate(AOS_CreateActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosCreate, contract);
        }

        public async Task<AOS_OrderInfoContract[]> AosCreateAndSplit(AOS_CreateActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract[]>(Address.AosCreateSplit, contract);
        }

        public async Task<AOS_OrderInfoContract> AosSendTo(AOS_SendToActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosSendTo, contract);
        }

        public async Task<AOS_OrderInfoContract[]> AosSendToBatch(AOS_SendToActionContract[] contracts)
        {
            return await PostRequest<AOS_OrderInfoContract[]>(Address.AosSendToBatch, contracts);
        }

        public async Task<AOS_OrderInfoContract> AosAccept(AOS_AcceptActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosAccept, contract);
        }

        public async Task<AOS_OrderInfoContract> AosAbort(AOS_AbortActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosAbort, contract);
        }

        public async Task<AOS_OrderInfoContract> AosDeliver(AOS_DeliverActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosDeliver, contract);
        }

        public async Task<AOS_OrderInfoContract> AosComplete(AOS_CompleteActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosComplete, contract);
        }

        public async Task<AOS_OrderInfoContract> AosDiscard(AOS_DiscardActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosDiscard, contract);
        }

        public async Task<AOS_OrderInfoContract[]> GetAosMemberOrders(string queryString = "")
        {
            return await GetRequest<AOS_OrderInfoContract[]>(Address.UrlCombine(Address.AosMemberOrders, queryString));
        }

        public async Task<AOS_OrderInfoContract[]> GetAosOrders(string queryString = "")
        {
            return await GetRequest<AOS_OrderInfoContract[]>(Address.UrlCombine(Address.AosOrders, queryString));
        }

        /// <summary>Legacy AOS order list (V3 <c>OrderInfoContract</c>) at <c>aos/order</c>.</summary>
        public async Task<OrderInfoContract[]> GetAosOrder(string queryString = "")
        {
            return await GetRequest<OrderInfoContract[]>(Address.UrlCombine(Address.AosOrder, queryString));
        }

        public async Task<AOS_OrderEventContract[]> GetAosOrderHistory(Guid orderGuid)
        {
            return await GetRequest<AOS_OrderEventContract[]>(Address.UrlCombine(Address.AosOrders, orderGuid.ToString(), "history"));
        }

        public async Task<AOS_NodeInfoContract> GetAosNodeInfo()
        {
            return await GetRequest<AOS_NodeInfoContract>(Address.AosNodeInfo);
        }

        public async Task<AOS_WorkRoleContract[]> GetAosTargets(Guid orderGuid)
        {
            return await GetRequest<AOS_WorkRoleContract[]>(Address.UrlCombine(Address.AosTargets, orderGuid.ToString()));
        }

        public async Task<AOS_WorkRoleContract[]> GetAosWorkRoles()
        {
            return await GetRequest<AOS_WorkRoleContract[]>(Address.AosWorkRoles);
        }

        public async Task<WorkGroupContract[]> GetAosWorkGroups()
        {
            return await GetRequest<WorkGroupContract[]>(Address.AosWorkGroups);
        }

        public async Task<AreaContract[]> GetAosItemAreas(int itemId)
        {
            return await GetRequest<AreaContract[]>(Address.UrlCombine(Address.AosItems, itemId.ToString(), "areas"));
        }

        public async Task<AOS_OrderInfoContract> AosMultiRoleCreate(AOS_MultiRoleCreateActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosMultiRoleCreate, contract);
        }

        public async Task<AOS_OrderInfoContract[]> AosMultiRoleCreateAndSplit(AOS_MultiRoleCreateActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract[]>(Address.AosMultiRoleCreateSplit, contract);
        }

        public async Task<AOS_OrderInfoContract> AosMultiRoleSendTo(AOS_MultiRoleSendToActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosMultiRoleSendTo, contract);
        }

        public async Task<AOS_OrderInfoContract[]> AosMultiRoleSendToBatch(AOS_MultiRoleSendToActionContract[] contracts)
        {
            return await PostRequest<AOS_OrderInfoContract[]>(Address.AosMultiRoleSendToBatch, contracts);
        }

        public async Task<AOS_OrderInfoContract> AosMultiRoleAccept(AOS_MultiRoleAcceptActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosMultiRoleAccept, contract);
        }

        public async Task<AOS_OrderInfoContract> AosMultiRoleAbort(AOS_MultiRoleAbortActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosMultiRoleAbort, contract);
        }

        public async Task<AOS_OrderInfoContract> AosMultiRoleDeliver(AOS_MultiRoleDeliverActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosMultiRoleDeliver, contract);
        }

        public async Task<AOS_OrderInfoContract> AosMultiRoleComplete(AOS_MultiRoleCompleteActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosMultiRoleComplete, contract);
        }

        public async Task<AOS_OrderInfoContract> AosMultiRoleDiscard(AOS_MultiRoleDiscardActionContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract>(Address.AosMultiRoleDiscard, contract);
        }

        public async Task<AOS_OrderInfoContract[]> AosMultiRoleOrders(AOS_ConnectIdContract contract)
        {
            return await PostRequest<AOS_OrderInfoContract[]>(Address.AosMultiRoleOrders, contract);
        }

        public async Task<NodeInfoContract> GetAosMultiRoleNodeInfo(int id, string login)
        {
            return await GetRequest<NodeInfoContract>(Address.UrlCombine(Address.AosMultiRoleNodeInfo, id.ToString(), login));
        }

        public async Task<AOS_MemberContract[]> AosMultiRoleConnectionMembers(AOS_ConnectIdContract contract)
        {
            return await PostRequest<AOS_MemberContract[]>(Address.AosMultiRoleConnectionMembers, contract);
        }

        public async Task<AOS_WorkRoleContract[]> GetAosMultiRoleTargets(Guid orderGuid)
        {
            return await GetRequest<AOS_WorkRoleContract[]>(Address.UrlCombine(Address.AosMultiRoleTargets, orderGuid.ToString()));
        }

        public async Task<AOS_WorkRoleContract[]> GetAosMultiRoleWorkRoles()
        {
            return await GetRequest<AOS_WorkRoleContract[]>(Address.AosMultiRoleWorkRoles);
        }

        public async Task<AOS_WorkRoleContract[]> GetAosMultiRoleWorkRoles(Guid orderGuid)
        {
            return await GetRequest<AOS_WorkRoleContract[]>(Address.UrlCombine(Address.AosMultiRoleWorkRoles, orderGuid.ToString()));
        }
    }
}
