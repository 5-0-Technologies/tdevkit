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

```C# 
ConnectionOptionsBuilder ConnectionOptionsBuilder = new ConnectionOptionsBuilder();
ConnectionOptions connectionOptions = optionsBuilder\
	.Url("https://twin.rtls.solutions/api")\
	.Client("YourClient")\
	.BranchGuid("YourBranchGuid")\
	.Timeout(1000)\
	.ApiKey("YourApiKey")\
	.Version(ConnectionOptions.VERSION_3)\
	.Build();\
	
DevkitConnectorV3 devkitConnector = (DevkitConnectorV3) DevkitFactory.CreateDevkitConnector(connectionOptions);
```

Through the `DevkitConnectorV3` object are accessible all the functions implemented in tDevkit.

### List of functions
TBA

## Future features
- **protobuffers** serialization
- automated order system(AOS) for logistics integration
- **MQTT** communication protocol implementation
