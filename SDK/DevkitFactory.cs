using SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tDevkit
{
    public static class DevkitFactory
    {
        public static DevkitConnector CreateDevkitConnector(ConnectionOptions connectionOptions)
        {

            switch (connectionOptions.Version)
            {
                //case ConnectionOptions.VERSION_2:
                //    return new DevkitConnectorV2(connectionOptions);
                case ConnectionOptions.VERSION_3:
                    return new DevkitConnectorV3(connectionOptions);
                default:
                    return null;
            }
        }
    }
}
