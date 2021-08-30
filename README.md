# Twinzo C# development kit
.NET 5 SDK for digital twin developers used to connect your C# code with twinzo platform.

Providing whole API Endpoint communication methods and data contracts for easy serialization and transporting.

## Nuget package
SDK Nuget package is publicly available for developers to use twinzo platform API right from Visual Studio IDE. 

Please read [Package & Repository - tDevKit](https://gitlab.twinzo.eu/digital-twin/twinzo/tdevkit/-/packages) section for more informations and instructions do get known, how to install SDK. 

## API
Rest json/protobuf API for registered twinzo clients and partners provides fully capable interface for bidirectional digital twin integration.

[API Endpoint](https://twin.rtls.solutions/api/swagger/ui/index#/) for each digital twin module uses same authorization methods to provide all system unification into single instance - twinzo.

## Documentation & Examples (V3)

  

### Initialization
The first thing you need to do is create the base object by which the functionality will be accessible:
```c# 
ConnectionOptionsBuilder ConnectionOptionsBuilder = new ConnectionOptionsBuilder();
ConnectionOptions connectionOptions = optionsBuilder
	.Url("https://twin.rtls.solutions/api")
	.Client("YourClient")
	.BranchGuid("YourBranchGuid")
	.Timeout(1000)
	.ApiKey("YourApiKey")
	.Version(ConnectionOptions.VERSION_3)
	.Build();
	
DevkitConnectorV3 devkitConnector = (DevkitConnectorV3) DevkitFactory.CreateDevkitConnector(connectionOptions);
```
Through the `DevkitConnectorV3` object are accessible all the functions implemented in tDevkit. As of **V3**, Most of the functionality is ready to be used after specifying the Api Key in `ConnectionOptions` object. However, there is a small number of functions you need to be authenticated for due to their nature. These functions are mentioned in the 
[Full list of functions](#full-list-of-functions-v3).
### Examples
Below are a few examples with dummy data.
#### Getting objects
Getting all objects (f.e. Area type):
```c#
AreaContract[] areas = await devkitConnector.GetAreas();
```

Getting an object by ID:
```c#
DeviceContract device = await devkitConnector.GetDevice(3);
```

Getting an object by login (if said object's class has `login` property):
```c#
SensorContract sensor = await devkitConnector.GetSensor("login");
```
\
Most of the `GET` functions are able to be further customized to your needs by taking in `queryString` parameter. With this parameter you can specify additional query options (order, limit, expand etc.) according to the [OData standard](https://www.odata.org/documentation/odata-version-3-0/url-conventions/).\
Ordering by property:
```c#
LayerContract[] layers = await devkitConnector.GetLayers("?$orderby=Updated");
```
Expanding by another related data model:
```c#
SectorContract sector = await devkitConnector.GetSector(1, "?$expand=Beacons");
```
#### Adding objects
Successfully adding an object returns it with its alocated ID (and with freshly generated GUID, if such object is in question).
```c#
DeviceContract deviceDummy = new DeviceContract
{
    Mac = "00:00:00:00:00:00",
    BranchId = 1,
    SectorId = 1,
    Login = "login",
    Title = "login",
    X = 100.0,
    Y = 100.0,
    IsMoving = false,
    FallStatus = FallType.OK,
    DeviceTypeId = 8,
    Position = false,
    Geofence = false
};

DeviceContract device = await devkitConnector.AddDevice(deviceDummy);
```
```c#
SensorDataContract data1 = new SensorDataContract
{
    Quantity = "Temperature",
    Value = "16",
    Unit = "°C",
    DataType = "Single"
};
SensorDataContract data2 = new SensorDataContract
{
    Quantity = "Humidity",
    Value = "31",
    Unit = "%",
    DataType = "Single"
};
SensorDataContract[] sensorDataContracts = new SensorDataContract[] { data1, data2 };

SensorContract sensorDummy = new SensorContract
{
    Login = "login",
    Title = "title",
    SectorId = 2,
    SensorData = sensorDataContracts,
};

SensorContract sensor = await devkitConnector.AddSensor(sensorDummy);
```
#### Localization
```c#
DistanceContract[] distanceContract1 = new DistanceContract[] 
{
	new DistanceContract {BeaconId = 34, RSSI= -55},
	new DistanceContract {BeaconId = 35, RSSI= -60},
	new DistanceContract {BeaconId = 36, RSSI= -45}
};

LocationContract[] locationContract = new LocationContract[]
{
	new LocationContract {SectorId = 1, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
        X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
    new LocationContract {SectorId = 2, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
        X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
    new LocationContract {SectorId = 3, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
        X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
    new LocationContract {SectorId = 4, Battery = 100, IsMoving = true, Timestamp = 1599644652178,
        X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
};

DeviceLocationContract[] deviceLocationContract = new DeviceLocationContract[] { new DeviceLocationContract { Login = "login", Locations = locationContract } };

await devkitConnector.AddLocalizationData(deviceLocationContract);
```
#### Sensor Data
```c#
SensorDataContract data1 = new SensorDataContract
{
    Quantity = "Temperature",
    Value = "16",
    Unit = "°C",
    DataType = "Single"
};
SensorDataContract data2 = new SensorDataContract
{
    Quantity = "Humidity",
    Value = "31",
    Unit = "%",
    DataType = "Single"
};
SensorDataContract data3 = new SensorDataContract
{
    Quantity = "CO2",
    Timestamp = 1614599484673,
    Value = "800",
    DataType = "Int32",
    Unit = "unit"
};
SensorDataContract[] sensorDataContracts = new SensorDataContract[] { data1, data2, data3 };

SensorContract sensor = new SensorContract
{
    Login = "login",
    SensorData = sensorDataContracts,
};
SensorContract[] sensorContracts = new SensorContract[] { sensor };

await devkitConnector.AddSensorData(sensorContracts);
```
### Full list of functions
* Areas
	* GetAreas()
	* GetArea(id)
* Authorization
	* Authenticate(login, password)
* Beacons
	* GetBeacons()
	* GetBeacon(id)
	* AddBeacon(beaconContract)
	* UpdateBeacon(beaconContract)
	* DeleteBeacon(id)
* Branches
	* GetBranches()
	* GetBranch(id)
* Clients
	* GetClients()
* Configuration
	* GetBranchConfiguration(key)
	* GetAccountConfiguration(key)
	* GetConfigurationLastChange(key)
* Devices
	* GetDevices()
	* GetDevice(id)
	* GetDevice(login)
	* GetDynamicDevices()
	* GetDynamicDevicesShort()
	* AddDevice(deviceContract)
	* UpdateDevice(deviceContract)
	* DeleteDevice(id)
* Layers
	* GetLayers()
	* GetLayer(id)
* Localization
	* AddLocalizationData(deviceLocationContract)
	* AddLocalizationData(locationContract)
* Sectors
	* GetSectors()
	* GetSector(id)
	* AddSector(sectorContract)
	* UpdateSector(sectorContract)
	* DeleteSector(id)
* Sensors
	* GetSensors()
	* GetSensor(id)
	* GetSensor(login)
	* AddSensor(sensorContract)
	* UpdateSensor(sensorContract)
	* DeleteSensor(id)
	* AddSensorData(sensors)
	* AddSensorData(sensorData)
	* GetSensorAppInfo()
* Shifts
	* GetShifts()
	* GetShift(id)
* Users
	* GetUserInfo()
* Utils
	* GetDemoFilesInfo()
	* GetFile(fileName)
	* GetDemoFile(fileName)
	* GetUnityLastVersion(platform)
	* GetUnityBundleInfo(bundleName)


## Future features
- **protobuffers** serialization
- automated order system(AOS) for logistics integration
- **MQTT** communication protocol implementation
