# Twinzo C# development kit
.NET 8/9 SDK for digital twin developers used to connect your C# code with twinzo platform.

Providing whole API Endpoint communication methods and data contracts for easy serialization and transporting.

## Nuget package
SDK Nuget package is publicly available for developers to use twinzo platform API right from Visual Studio IDE. 

Please read 
[Package & Repository - tDevKit](https://gitlab.twinzo.eu/digital-twin/twinzo/tdevkit/-/packages) section
and [Developers Twinzo Documentation](https://twinzo.atlassian.net/wiki/spaces/PUBD/pages/232652871/Developers) for more informations and instructions do get known, how to install SDK. 

## API
Rest json/protobuf API for registered twinzo clients and partners provides fully capable interface for bidirectional digital twin integration.

[API Endpoint](https://twin.rtls.solutions/api/swagger/ui/index#/) for each digital twin module uses same authorization methods to provide all system unification into single instance - twinzo.

## Documentation & Examples (V3)

### Initialization
The first thing you need to do is create the base object by which the functionality will be accessible:
```c# 
ConnectionOptionsBuilder optionsBuilder = new ConnectionOptionsBuilder();
ConnectionOptions connectionOptions = optionsBuilder
	.Url("https://api.platform.twinzo.eu/")
	.Client("YourClient")
	.BranchGuid("YourBranchGuid")
	.Timeout(1000)
	.ApiKey("YourApiKey")
	.Version(ConnectionOptions.VERSION_3)
	.Build();
	
DevkitConnectorV3 devkitConnector = (DevkitConnectorV3) DevkitFactory.CreateDevkitConnector(connectionOptions);
```
You can find api links at: https://twinzo.atlassian.net/wiki/spaces/PUBD/pages/72712207/Basics.

Through the `DevkitConnectorV3` object are accessible all the functions implemented in tDevkit. As of **V3**, Most of the functionality is ready to be used after specifying the Api Key in `ConnectionOptions` object. However, there is a small number of functions you need to be authenticated for due to their nature. These functions are mentioned in the 
[Full list of functions](#full-list-of-functions) section.

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

Most of the `GET` functions are able to be further customized to your needs by taking in `queryString` parameter. With this parameter you can specify additional query options (order, limit, expand etc.) according to the [OData standard](https://www.odata.org/documentation/odata-version-3-0/url-conventions/).\
Ordering by property:
```c#
LayerContract[] layers = await devkitConnector.GetLayers("?$orderby=Updated");
```
Expanding by another related data model:
```c#
SectorContract sector = await devkitConnector.GetSector(1, "?$expand=Beacons");
```
And more...

#### Adding objects
Successfully adding an object returns it back with its alocated ID (and with freshly generated GUID, if such object is in question).
```c#
DeviceWriteContract deviceDummy = new DeviceWriteContract
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
SensorDataWriteContract data1 = new SensorDataWriteContract
{
    Quantity = "Temperature",
    Value = "16",
    Unit = "°C",
    DataType = SensorDataType.Single,
	Index = 0
};
SensorDataWriteContract data2 = new SensorDataWriteContract
{
    Quantity = "Humidity",
    Value = "31",
    Unit = "%",
    DataType = SensorDataType.Single,
	Index = 1
};
SensorDataWriteContract[] sensorDataContracts = new SensorDataWriteContract[] { data1, data2 };

SensorWriteContract sensorDummy = new SensorWriteContract
{
    Login = "login",
    Title = "title",
    SectorId = 2,
    SensorData = sensorDataContracts,
};

SensorContract[] sensors = await devkitConnector.AddSensor(sensorDummy);
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
	new LocationContract {SectorId = 1, Battery = 100, IsMoving = true, Timestamp = 1599644652178,X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
	new LocationContract {SectorId = 2, Battery = 100, IsMoving = true, Timestamp = 1599644652178,X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
	new LocationContract {SectorId = 3, Battery = 100, IsMoving = true, Timestamp = 1599644652178,X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
	new LocationContract {SectorId = 4, Battery = 100, IsMoving = true, Timestamp = 1599644652178,X = 0, Y = 0, Z = 0, Interval = 300, Distances = distanceContract1 },
};

DeviceLocationContract[] deviceLocationContract = new DeviceLocationContract[] { new DeviceLocationContract { Login = "login", Locations = locationContract } };

await devkitConnector.AddLocalizationData(deviceLocationContract);
```

#### Sensor Data
```c#
SensorDataWriteContract data1 = new SensorDataWriteContract
{
    Quantity = "Temperature",
    Value = "16",
    Unit = "°C",
    DataType = SensorDataType.Single,
	Index = 0
};
SensorDataWriteContract data2 = new SensorDataWriteContract
{
    Quantity = "Humidity",
    Value = "31",
    Unit = "%",
    DataType = SensorDataType.Single,
	Index = 1
};
SensorDataWriteContract data3 = new SensorDataWriteContract
{
    Quantity = "CO2",
    Timestamp = 1614599484673,
    Value = "800",
    DataType = SensorDataType.Int32,
    Unit = "unit",
	Index = 2
};
SensorDataWriteContract[] sensorDataContracts = new SensorDataWriteContract[] { data1, data2, data3 };

SensorWriteContract sensor = new SensorWriteContract
{
    Login = "login",
    SensorData = sensorDataContracts,
};
SensorWriteContract[] sensorContracts = new SensorWriteContract[] { sensor };

await devkitConnector.AddSensorData(sensorContracts);
```

#### Man Down
```c#
ManDownContract manDownContract = new ManDownContract
{
    Login = "deviceLogin",
    FallStatus = FallType.ManDown,
    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
};

ManDownResponseContract response = await devkitConnector.ManDown(manDownContract);
```

#### Logs
```c#
LogWriteContract logContract = new LogWriteContract
{
    Login = "deviceLogin",
    Message = "Device started successfully",
    Level = "Info",
    Timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()
};

LogContract log = await devkitConnector.AddLog(logContract);
```

#### AOS (Automated Order System)
```c#
OrderDataContract[] orders = await devkitConnector.GetOrders(startTimestamp, stopTimestamp);
```

### Full list of functions
* **Areas**
	* `GetAreas(queryString)` - Get all areas
	* `GetArea(id, queryString)` - Get area by ID
	* `AddArea(areaWriteContract)` - Add an area with specified properties
	* `UpdateArea(id, changes)` - Update an existing area with new properties
	* `DeleteArea(id)` - Delete an existing area by ID
	* `GetGridAreaOccurence(deviceId, shiftId, start, stop)` - Get grid area occurrence data
* **Authorization**
	* `Authenticate(login, password, superUser)` - Authenticate with login and password as user/device/sensor
	* `Authenticate(superUser)` - Authenticate using connection options credentials
	* `GetToken()` - Get authentication token
	* `DeleteCurrentToken()` - Delete current authentication token
* **AOS (Automated Order System)**
	* `GetOrders(start, stop)` - Get orders within specified time range
* **Beacons**
	* `GetBeacons(queryString)` - Get all beacons
	* `GetBeacon(id, queryString)` - Get beacon by ID
	* `AddBeacon(beaconWriteContract)` - Add a beacon with specified properties
	* `UpdateBeacon(id, changes)` - Update an existing beacon with new properties
	* `DeleteBeacon(id)` - Delete an existing beacon by ID
* **Branches**
	* `GetBranches(queryString)` - Get all branches
	* `GetBranch(id, queryString)` - Get branch by ID
* **Clients**
	* `GetClients(queryString)` - Get all clients
* **Configuration**
	* `GetBranchConfiguration(key)` - Get branch configuration with specified key
	* `GetAccountConfiguration(key)` - Get account configuration with specified key
	* `GetAccountConfiguration(login, key)` - Get account configuration for specific login and key
	* `GetConfigurationLastChange(key)` - Get configuration last change timestamp
* **Devices**
	* `GetDevices(queryString)` - Get all devices
	* `GetDevice(id, queryString)` - Get device by ID
	* `GetDevice(login, queryString)` - Get device by login
	* `GetDynamicDevices(queryString)` - Get devices with dynamic position
	* `GetDynamicDevicesShort(queryString)` - Get shortened form of dynamic devices grouped by sectors
	* `AddDevice(deviceWriteContract)` - Add a device with specified properties
	* `UpdateDevice(id, changes)` - Update an existing device with new properties
	* `DeleteDevice(id)` - Delete an existing device by ID
	* `ManDown(manDownContract)` - Send man down alert for single device
	* `ManDownBatch(manDownBatchContracts)` - Send man down alerts for multiple devices
	* `GetDeviceLocations(deviceId, from, to, queryString)` - Get device location history
* **Layers**
	* `GetLayers(queryString)` - Get all layers
	* `GetLayer(id, queryString)` - Get layer by ID
	* `GetLocalizationLayers(deviceLogin, queryString)` - Get all localization layers for specified device
	* `AddLayer(layerWriteContract)` - Add a layer with specified properties
	* `UpdateLayer(id, changes)` - Update an existing layer with new properties
	* `DeleteLayer(id)` - Delete an existing layer by ID
* **Localization**
	* `AddLocalizationData(deviceLocationContract)` - Add localization data for multiple devices in batch mode
	* `AddLocalizationData(locationContract)` - Add localization data for single device (in order to do this you need to be **authenticated** as said device - this can be avoided when using the batch mode above - [Example](#localization))
* **Logs**
	* `AddLog(logWriteContract)` - Add a log entry
* **Quantities**
	* `GetQuantities(queryString)` - Get all quantities
	* `GetQuantity(id, queryString)` - Get quantity by ID
	* `AddQuantity(quantityWriteContract)` - Add a quantity with specified properties
	* `UpdateQuantity(quantityContract)` - Update an existing quantity with new properties
	* `DeleteQuantity(id)` - Delete an existing quantity by ID
* **Sectors**
	* `GetSectors(queryString)` - Get all sectors
	* `GetSector(id, queryString)` - Get sector by ID
	* `AddSector(sectorWriteContract)` - Add a sector with specified properties
	* `UpdateSector(id, changes)` - Update an existing sector with new properties
	* `DeleteSector(id)` - Delete an existing sector by ID
* **Sensors**
	* `GetSensors(queryString)` - Get all sensors
	* `GetSensor(id, queryString)` - Get sensor by ID
	* `GetSensor(login, queryString)` - Get sensor by login
	* `AddSensor(sensorWriteContract)` - Add a sensor with specified properties
	* `UpdateSensor(id, changes)` - Update an existing sensor with new properties
	* `DeleteSensor(id)` - Delete an existing sensor by ID
	* `AddSensorData(sensors)` - Add sensor data for multiple sensors in batch mode
	* `AddSensorData(sensorData)` - Add sensor data for single sensor (in order to do this you need to be **authenticated** as said sensor - this can be avoided when using the batch mode above - [Example](#sensor-data))
	* `GetSensorAppInfo()` - Get information (version, size) about the sensor app
* **SensorDatas**
	* `GetSensorDatas(queryString)` - Get all sensor datas
	* `GetSensorData(id, queryString)` - Get sensor data by ID
	* `AddSensorData(sensorDataContract)` - Add a sensor data with specified properties
	* `UpdateSensorData(id, changes)` - Update an existing sensor data with new properties
	* `DeleteSensorData(id)` - Delete an existing sensor data by ID
* **Shifts**
	* `GetShifts(queryString)` - Get all shifts
	* `GetShift(id, queryString)` - Get shift by ID
	* `AddShift(shiftWriteContract)` - Add a shift with specified properties
	* `UpdateShift(id, changes)` - Update an existing shift with new properties
	* `DeleteShift(id)` - Delete an existing shift by ID
* **Users**
	* `GetUserInfo()` - Get information about the current user (in order to do this you need to be **authenticated** as said user)
* **Utils**
	* `GetDemoFilesInfo()` - Get information (version, size, name) about all the demo files
	* `GetFile(fileName)` - Get byte representation of the specified file
	* `GetDemoFile(fileName)` - Get byte representation of the specified demo file
	* `GetUnityLastVersion(platform)` - Get the last version of the Unity app
	* `GetUnityBundleInfo(bundleName)` - Get information (version, size, name) about the Unity Bundle
	* **Generic methods**
		* `Get<T>(string subUrl)`
		* `Post<T>(string subUrl, object body)`
		* `Patch(string subUrl, object body)`
		* `Delete(string subUrl)`
* **Paths**
	* `GetPaths(queryString)` - Get all paths
	* `GetPath(id, queryString)` - Get path by ID

## Data Types and Enums

### Enums
* **FallType** - Device fall status enumeration
* **OrderStatus** - AOS order status enumeration  
* **SensorDataType** - Sensor data type enumeration
* **ActionType** - Action type enumeration

### Write Contracts
The SDK uses separate write contracts for creating and updating entities:
* `AreaWriteContract`
* `BeaconWriteContract`
* `DeviceWriteContract`
* `LayerWriteContract`
* `LogWriteContract`
* `QuantityWriteContract`
* `SectorWriteContract`
* `SensorWriteContract`
* `SensorDataWriteContract`
* `ShiftWriteContract`

## Future features
- **protobuffers** serialization
- TCS implementation
- **MQTT** communication protocol implementation
