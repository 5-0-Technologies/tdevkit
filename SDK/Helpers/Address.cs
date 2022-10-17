using System.Linq;

namespace SDK.Models
{
    public static class Address
    {
        public const string AosOrders = "aos/orders/";
        public const string AosNodeInfo = "aos/node-info/";
        public const string AosWorkGroups = "aos/work-groups/";
        public const string AosTargets = "aos/targets/";
        public const string AosAbort = "aos/abort/";
        public const string AosAccept = "aos/accept/";
        public const string AosCreate = "aos/create/";
        public const string AosConnect = "aos/connect/";
        public const string AosDiscard = "aos/discard/";
        public const string AosSendTo = "aos/send-to/";
        public const string AosComplete = "aos/complete/";
        public const string AosSendBack = "aos/send-back/";
        public const string AosDisconnect = "aos/disconnect/";
        public const string AosCreateSplit = "aos/create-split/";
        public const string AosSendToBatch = "aos/send-to/batch/";

        public const string Areas = "areas/";

        public const string AuthorizationAuthenticate = "Authorization/Authenticate/";
        public const string AuthorizationToken = "Authorization/Token/";

        public const string Beacons = "beacons/";

        public const string Branches = "branches/";

        public const string Clients = "clients/";

        public const string Configuration = "configuration/";
        public const string ConfigurationBranch = "configuration/branch/";
        public const string ConfigurationAccount = "configuration/account/";

        public const string Devices = "devices/";
        public const string DevicesLogin = "devices/login/";
        public const string DevicesDynamicLocations = "devices/dynamic-locations/";
        public const string DevicesDynamicLocationsShort = "devices/dynamic-locations-short/";
        public const string DevicesRegister = "devices/register/";

        public const string Layers = "layers/";
        public const string LayersNoGo = "layers/device/";
        public const string Layerslocalization = "layers/localization/";

        public const string LocalizationAddData = "localization/";
        public const string LocalizationAddDataBatch = "localization/batch/";

        public const string LogAdd = "logs";

        public const string Sectors = "sectors/";

        public const string Sensors = "sensors/";
        public const string SensorsAppFile = "sensors/app-file/";
        public const string SensorsAppInfo = "sensors/app-info/";
        public const string SensorsAddDataBatch = "sensors/batch/";
        public const string SensorsAddData = "sensors/sensor-data/";
        public const string SensorsLogin = "sensors/login/";

        public const string Shifts = "shifts/";

        public const string Users = "users/detail";

        public const string UtilsDemoFilesInfo = "utils/demo-files-info/";
        public const string UtilsFile = "utils/file/";
        public const string UtilsDemoFile = "utils/demo-file/";
        public const string UtilsUnityLastVersion = "utils/unity-last-version/";
        public const string UtilsUnityBundleInfo = "utils/unity-bundle-info/";

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
