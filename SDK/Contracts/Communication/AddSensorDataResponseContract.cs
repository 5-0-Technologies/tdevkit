namespace SDK.Communication
{
    public class AddSensorDataResponseContract : PostResponseContract
    {
        public string Login { get; set; }

        public SensorDataResponseContract[] SensorData { get; set; }
    }
}
