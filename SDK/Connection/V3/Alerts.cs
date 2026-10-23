using SDK.Contracts.Data.Alerts;
using SDK.Models;
using System;
using System.Threading.Tasks;

namespace SDK
{
    public partial class DevkitConnectorV3
    {
        public async Task<CheckContract[]> GetAlertChecks(string queryString = "")
        {
            return await GetRequest<CheckContract[]>(Address.UrlCombine(Address.AlertsChecks, queryString));
        }

        public async Task<CheckContract> GetAlertCheck(int id, string queryString = "")
        {
            return await GetRequest<CheckContract>(Address.UrlCombine(Address.AlertsChecks, Convert.ToString(id), queryString));
        }

        public async Task<CheckContract> AddAlertCheck(CheckWriteContract contract)
        {
            return await PostRequest<CheckContract>(Address.AlertsChecks, contract);
        }

        public async Task UpdateAlertCheck(int id, object changes)
        {
            await PatchRequest(Address.UrlCombine(Address.AlertsChecks, id.ToString()), changes);
        }

        public async Task DeleteAlertCheck(int id)
        {
            await DeleteRequest(Address.UrlCombine(Address.AlertsChecks, Convert.ToString(id)));
        }

        public async Task<NotificationContract[]> GetAlertNotifications(string queryString = "")
        {
            return await GetRequest<NotificationContract[]>(Address.UrlCombine(Address.AlertsNotifications, queryString));
        }

        public async Task<NotificationContract> GetAlertNotification(int id, string queryString = "")
        {
            return await GetRequest<NotificationContract>(Address.UrlCombine(Address.AlertsNotifications, Convert.ToString(id), queryString));
        }

        public async Task<NotificationContract> AddAlertNotification(NotificationWriteContract contract)
        {
            return await PostRequest<NotificationContract>(Address.AlertsNotifications, contract);
        }

        public async Task UpdateAlertNotification(int id, object changes)
        {
            await PatchRequest(Address.UrlCombine(Address.AlertsNotifications, id.ToString()), changes);
        }

        public async Task DeleteAlertNotification(int id)
        {
            await DeleteRequest(Address.UrlCombine(Address.AlertsNotifications, Convert.ToString(id)));
        }
    }
}
