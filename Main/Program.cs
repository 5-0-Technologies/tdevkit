using SDK;
using SDK.Communication;
using SDK.Contracts.Communication;
using SDK.Contracts.Data;
using SDK.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using tDevkit;

namespace Main
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //http://twin.develop.rtls.solutions:8080/api/
            //https://twin.rtls.solutions/api/
            //https://jsonplaceholder.typicode.com/todos

            Console.WriteLine("Hello World!");
            ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
            ConnectionOptions connectionOptions = optionsBuilder
                .Url("http://twin.develop.rtls.solutions:8080/api/")
                //.Token("K169z9mIQ2Ln3UG34jOobsytFGGqYRwzCundpeM67G4=")
                .Client("Infotech")
                .ClientGuid("00000000-0000-0000-0000-000000000001")
                .BranchGuid("00000000-0000-0000-0000-000000000003")
                .Timeout(1000)
                .ApiKey("X1fprPtlkvolW1Bl47UQV4SoW8siY3n8QDQkDsGJ")
                .Version(ConnectionOptions.VERSION_3)
                .Login("ondrejicka")
                .Password("zJz1sJRUMNr4b4M")
                .Build();
            //FeF/lTE9ZBPYMvKkQZnRMRK7loOXdfeD1qOcVMr00uQ=
            //Console.WriteLine("Url: " + connectionOptions.Url);
            Console.WriteLine("Token: " + connectionOptions.Token);
            Console.WriteLine("Client: " + connectionOptions.Client);
            Console.WriteLine("ClientGuid: " + connectionOptions.ClientGuid);
            Console.WriteLine("BranchGuid: " + connectionOptions.BranchGuid);
            Console.WriteLine("Timeout: " + connectionOptions.Timeout);
            Console.WriteLine("ApiKey: " + connectionOptions.ApiKey);
            Console.WriteLine("Version: " + connectionOptions.Version);
            Console.WriteLine("Login: " + connectionOptions.Login);
            Console.WriteLine("Password: " + connectionOptions.Password);

            DevkitConnectorV3 devkitConnector = (DevkitConnectorV3)DevkitFactory.CreateDevkitConnector(connectionOptions);

            //-------------------------------------------------------------------

            AuthenticationResponseContract auth = await devkitConnector.Authenticate(true);
            Console.WriteLine(auth);

            //AuthenticationResponseContract auth2 = await devkitConnector.GetToken();
            //Console.WriteLine(auth2);

            //HttpResponseMessage auth3 = await devkitConnector.DeleteCurrentToken();
            //Console.WriteLine(auth3);

            //----------AREAS

            //List<AreaContract> area1 = await devkitConnector.GetAreas();
            //Console.WriteLine(area1);

            //AreaContract area2 = await devkitConnector.GetArea(1);
            //Console.WriteLine(area2);

            //----------BEACONS

            //List<BeaconContract> beacon1 = await devkitConnector.GetBeacons();
            //Console.WriteLine(beacon1);

            //BeaconContract beacon2 = await devkitConnector.AddBeacon(TestData.GetBeacon());
            //Console.WriteLine(beacon2);

            //HttpResponseMessage beacon3 = await devkitConnector.DeleteBeacon(beacon2.Id);
            //Console.WriteLine(beacon3);

            //BeaconContract beacon4 = await devkitConnector.GetBeacon(34);
            //Console.WriteLine(beacon4);

            //var beacon5 = await devkitConnector.UpdateBeacon(TestData.GetBeaconPatch());
            //Console.WriteLine(beacon5);

            //----------BRANCHES

            //List<BranchContract> branch1 = await devkitConnector.GetBranches();
            //Console.WriteLine(branch1);

            //BranchContract branch2 = await devkitConnector.GetBranch(1);
            //Console.WriteLine(branch2);

            //----------CLIENTS

            //List<ClientContract> client1 = await devkitConnector.GetClients();
            //Console.WriteLine(client1);

            //----------CONFIGURATION

            //ConfigurationContract config1 = await devkitConnector.GetBranchConfiguration("3D_APP");
            //Console.WriteLine(config1);

            //AuthenticationResponseContract auth3 = await devkitConnector.Authenticate("sdk-device", "awMMSgtzhZ8X29l", false);
            //Console.WriteLine(auth3);

            //ConfigurationContract config2 = await devkitConnector.GetAccountConfiguration("3D_APP");
            //Console.WriteLine(config2);

            //long config3 = await devkitConnector.GetConfigurationLastChange("3D_APP");
            //Console.WriteLine(config3);

            //----------DEVICES

            //AuthenticationResponseContract auth4 = await devkitConnector.Authenticate("sdk-device", "awMMSgtzhZ8X29l", false);
            //Console.WriteLine(auth4);

            //List<DeviceContract> device1 = await devkitConnector.GetDevices();
            //Console.WriteLine(device1);

            //DeviceContract device2 = await devkitConnector.GetDevice(3);
            //Console.WriteLine(device2);

            //DeviceContract device3 = await devkitConnector.GetDevice("RTU1");
            //Console.WriteLine(device3);

            //List<DynamicDeviceContract> device4 = await devkitConnector.GetDynamicDevices();
            //Console.WriteLine(device4);

            //List<DynamicDeviceContract> device5 = await devkitConnector.GetDynamicDevicesShort();
            //Console.WriteLine(device5);

            //----------LAYERS

            //List<LayerContract> layer1 = await devkitConnector.GetLayers();
            //Console.WriteLine(layer1);

            //LayerContract layer2 = await devkitConnector.GetLayer(1);
            //Console.WriteLine(layer2);

            //----------LOCALIZATION

            //PostResponseContract[] local1 = await devkitConnector.AddLocalizationData(TestData.GetLocalizationDataBatch());
            //Console.WriteLine(local1);


            //PostResponseContract[] local2 = await devkitConnector.AddLocalizationData(TestData.GetLocalizationData());
            //Console.WriteLine(local2);

            //----------SECTORS

            //List<SectorContract> sector1 = await devkitConnector.GetSectors();
            //Console.WriteLine(sector1);

            //SectorContract sector2 = await devkitConnector.GetSector(1);
            //Console.WriteLine(sector2);

            //----------SENSORS

            //AuthenticationResponseContract auth5 = await devkitConnector.Authenticate("sdk-sensor", "PtfnmktJucgkP9t", false);
            //Console.WriteLine(auth5);

            //List<SensorDataContract> dataList = new List<SensorDataContract>();
            //SensorDataContract data1 = new SensorDataContract
            //{
            //    Quantity = "Temperature",
            //    Value = "16",
            //    Unit = "°C",
            //    DataType = "Single"
            //};
            //SensorDataContract data2 = new SensorDataContract
            //{
            //    Quantity = "Humidity",
            //    Value = "31",
            //    Unit = "%",
            //    DataType = "Single"
            //};
            //dataList.Add(data1);
            //dataList.Add(data2);
            //List<SensorContract> sensorList = new List<SensorContract>();
            //SensorContract sensor = new SensorContract
            //{
            //    Login = "sdk-sensor",
            //    SectorId = 2,
            //    SensorData = dataList,
            //    AreaId = 24
            //};
            //sensorList.Add(sensor);


            //List<SensorContract> sensor1 = await devkitConnector.GetSensors();
            //Console.WriteLine(sensor1);

            //SensorContract sensor6 = await devkitConnector.AddSensor(TestData.GetSensor());
            //Console.WriteLine(sensor6);

            //SensorContract sensor7 = await devkitConnector.GetSensor(7351);
            //Console.WriteLine(sensor7);

            PatchResponseContract sensor8 = await devkitConnector.UpdateSensor(TestData.GetSensorUpdate());
            Console.WriteLine(sensor8);

            //DeviceContract sensor2 = await devkitConnector.GetDevice(3);
            //Console.WriteLine(sensor2);

            //SensorAppInfoContract sensor3 = await devkitConnector.GetSensorAppInfo();
            //Console.WriteLine(sensor3);

            //PostResponseContract sensor4 = await devkitConnector.AddSensorData(sensorList);
            //Console.WriteLine(sensor4);

            //PostResponseContract sensor5 = await devkitConnector.AddSensorData(dataList);
            //Console.WriteLine(sensor5);

            //----------USERS

            //AuthenticationResponseContract auth6 = await devkitConnector.Authenticate("sdk-user", "K0H4k0gal2gyqem", false);
            //Console.WriteLine(auth6);

            //UserContract user1 = await devkitConnector.GetUserInfo();
            //Console.WriteLine(user1);

            //----------UTILS

            //FileInfoContract[] utils1 = await devkitConnector.GetDemoFilesInfo();
            //Console.WriteLine(utils1);

            //byte[] utils2 = await devkitConnector.GetFile("00000000-0000-0000-0000-000000000001-android-manifest");
            //Console.WriteLine(utils2);

            //byte[] utils3 = await devkitConnector.GetDemoFile("showcaseoffice-thumbnail");
            //Console.WriteLine(utils3);

            //string utils4 = await devkitConnector.GetUnityLastVersion("windows");
            //Console.WriteLine(utils4);

            //FileInfoContract utils5 = await devkitConnector.GetUnityBundleInfo();
            //Console.WriteLine(utils5);
        }

    }
}
