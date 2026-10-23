using System.Linq;

namespace SDK.Models
{
    public static class Address
    {
        public const string AosOrders = "aos/orders/";
        public const string AosOrder = "aos/order/";
        public const string AosDataOrders = "aos/v2/data/orders/";
        public const string AosNodeInfo = "aos/node-info/";
        public const string AosWorkGroups = "aos/work-groups/";
        public const string AosWorkRoles = "aos/work-roles/";
        public const string AosTargets = "aos/targets/";
        public const string AosItems = "aos/items/";
        public const string AosMemberOrders = "aos/member/orders/";
        public const string AosAbort = "aos/abort/";
        public const string AosAccept = "aos/accept/";
        public const string AosCreate = "aos/create/";
        public const string AosConnect = "aos/connect/";
        public const string AosDiscard = "aos/discard/";
        public const string AosSendTo = "aos/send-to/";
        public const string AosComplete = "aos/complete/";
        public const string AosDeliver = "aos/deliver/";
        public const string AosDisconnect = "aos/disconnect/";
        public const string AosCreateSplit = "aos/create-and-split/";
        public const string AosSendToBatch = "aos/send-to/batch/";

        public const string AosMultiRoleCreate = "aos/multirole/create/";
        public const string AosMultiRoleCreateSplit = "aos/multirole/create-and-split/";
        public const string AosMultiRoleSendTo = "aos/multirole/send-to/";
        public const string AosMultiRoleSendToBatch = "aos/multirole/send-to/batch/";
        public const string AosMultiRoleAccept = "aos/multirole/accept/";
        public const string AosMultiRoleAbort = "aos/multirole/abort/";
        public const string AosMultiRoleDeliver = "aos/multirole/deliver/";
        public const string AosMultiRoleComplete = "aos/multirole/complete/";
        public const string AosMultiRoleDiscard = "aos/multirole/discard/";
        public const string AosMultiRoleOrders = "aos/multirole/orders/";
        public const string AosMultiRoleNodeInfo = "aos/multirole/node-info/";
        public const string AosMultiRoleConnectionMembers = "aos/multirole/connection/members/";
        public const string AosMultiRoleTargets = "aos/multirole/targets/";
        public const string AosMultiRoleWorkRoles = "aos/multirole/work-roles/";

        public const string Areas = "areas/";
        public const string AreasGridAreaOccurence = "areas/grid-area-occurrence";

        public const string AlertsChecks = "alerts/checks/";
        public const string AlertsNotifications = "alerts/notifications/";

        public const string AnalyticsActivityDuration = "analytics/activity-duration";
        public const string AnalyticsActivitySummary = "analytics/activity-summary";
        public const string AnalyticsAreaOccurrence = "analytics/area-occurrence";
        public const string AnalyticsDeviceActivity = "analytics/device-activity";
        public const string AnalyticsDeviceActivityStatus = "analytics/device-activity-status";
        public const string AnalyticsDeviceOverview = "analytics/device-overview";
        public const string AnalyticsDevicePerShift = "analytics/device-per-shift";
        public const string AnalyticsDeviceStatistics = "analytics/device-statistics";
        public const string AnalyticsDevicesActivity = "analytics/devices-activity";
        public const string AnalyticsDowntimeBundle = "analytics/downtime-bundle";
        public const string AnalyticsGridAreaOccurrence = "analytics/grid-area-occurrence";
        public const string AnalyticsGridSectorOccurrence = "analytics/grid-sector-occurrence";
        public const string AnalyticsSectorOccurrence = "analytics/sector-occurrence";
        public const string AnalyticsShiftSummary = "analytics/shift-summary";
        public const string AnalyticsAosOrders = "analytics/aos/orders";
        public const string AnalyticsAosDowntimeOrders = "analytics/aos/downtime-orders";
        public const string AnalyticsAosOrdersActions = "analytics/aos/orders-actions";
        public const string AnalyticsAosOrdersItems = "analytics/aos/orders-items";
        public const string AnalyticsAosOrderCounts = "analytics/aos/order-counts";
        public const string AnalyticsAosDeviceAssignedOrdersHourly = "analytics/aos/device-assigned-orders-hourly";
        public const string AnalyticsAosDeviceFirstLastActivity = "analytics/aos/device-first-last-activity";
        public const string AnalyticsAosDeviceOrderWorkIntervals = "analytics/aos/device-order-work-intervals";
        public const string AnalyticsAosPackageItemLocations = "analytics/aos/package-item-locations";
        public const string AnalyticsAosPackageItemRides = "analytics/aos/package-item-rides";

        public const string AnswersSubmit = "answers/submit/";
        public const string QuestionsWorkRole = "questions/work-role/";

        public const string AuthorizationAuthenticate = "Authorization/Authenticate/";
        public const string AuthorizationToken = "Authorization/Token/";
        public const string AuthorizationFirebaseToken = "Authorization/FirebaseToken/";
        public const string AuthorizationFirebaseTokens = "Authorization/FirebaseTokens/";

        public const string Beacons = "beacons/";

        public const string Branches = "branches/";

        public const string Clients = "clients/";
        public const string ClientsAll = "clients/all/";
        public const string ClientsEmailValidation = "clients/emailValidation/";
        public const string ClientsExists = "clients/exists/";
        public const string ClientsGetByLogin = "clients/getByLogin/";
        public const string ClientsLogin = "clients/login/";
        public const string ClientsValidateToken = "clients/validateToken/";

        public const string Configuration = "configuration/";
        public const string ConfigurationBranch = "configuration/branch/";
        public const string ConfigurationAccount = "configuration/account/";

        public const string Devices = "devices/";
        public const string DevicesLogin = "devices/login/";
        public const string DevicesDynamicLocations = "devices/dynamic-locations/";
        public const string DevicesDynamicLocationsShort = "devices/dynamic-locations-short/";
        public const string DevicesRegister = "devices/register/";
        public const string DevicesLocations = "devices/locations/";
        public const string DevicesHeartbeat = "devices/heartbeat/";
        public const string DevicesDeviceStatus = "devices/device-status/";
        public const string DevicesEvent = "devices/event/";
        public const string DevicesHeatmap = "devices/heatmap/";
        public const string DevicesApk = "devices/apk/";
        public const string DevicesVersion = "devices/version/";
        public const string DevicesVersionsTConnect = "devices/versions/tConnect/";

        public const string File = "file/";
        public const string FileInfo = "file/info/";
        public const string FileLogo = "file/logo/";
        public const string FileAreaImage = "file/area-image/";
        public const string FileTviewerBundle = "file/tviewer-bundle/";
        public const string FileTviewerBundleInfo = "file/tviewer-bundle-info/";
        public const string FileTviewerThumbnail = "file/tviewer-thumbnail/";
        public const string FileTviewerThumbnailInfo = "file/tviewer-thumbnail-info/";
        public const string FileTviewerThumbnailInfos = "file/tviewer-thumbnail-infos/";
        public const string FileTmindMd = "file/tmind-md/";
        public const string FileModeljobRawModel = "file/modeljob-raw-model/";

        public const string GpsItems = "gps-items/";

        public const string Layers = "layers/";
        public const string LayersNoGo = "layers/device/";
        public const string Layerslocalization = "layers/localization/";

        public const string LocalizationAddData = "localization/";
        public const string LocalizationAddDataBatch = "localization/batch/";

        public const string LogAdd = "logs";
        public const string Logs = "logs/";

        public const string Lookups = "lookups/";

        public const string Paths = "paths/";

        public const string Sectors = "sectors/";
        public const string SectorsLayout = "sectors/layout/";
        public const string SectorsLayouts = "sectors/layouts/";

        public const string Sensors = "sensors/";
        public const string SensorsAppFile = "sensors/app-file/";
        public const string SensorsAppInfo = "sensors/app-info/";
        public const string SensorsAddDataBatch = "sensors/batch/";
        public const string SensorsAddData = "sensors/sensor-data/";
        public const string SensorsLogin = "sensors/login/";

        public const string SensorDatas = "sensor-datas/";

        public const string Shifts = "shifts/";

        public const string TcsDriverInfo = "tcs/driver-info/";

        public const string Users = "users/";
        public const string UsersDetail = "users/detail";
        public const string UsersRegister = "users/register/";

        public const string UtilsDemoFilesInfo = "utils/demo-files-info/";
        public const string UtilsFile = "utils/file/";
        public const string UtilsDemoFile = "utils/demo-file/";
        public const string UtilsUnityLastVersion = "utils/unity-last-version/";
        public const string UtilsUnityBundleInfo = "utils/unity-bundle-info/";

        public const string Quantities = "quantities/";

        public static string UrlCombine(params string[] items)
        {
            if (items?.Any() != true)
            {
                return string.Empty;
            }

            return string.Join("/", items.Where(u => !string.IsNullOrWhiteSpace(u)).Select(u => u.Trim('/', '\\')));
        }
    }
}
