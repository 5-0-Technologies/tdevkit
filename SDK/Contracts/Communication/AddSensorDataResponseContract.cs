using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Communication
{
    public class AddSensorDataResponseContract : PostResponseContract
    {
        public string Login { get; set; }

        public SensorDataResponseContract[] SensorData { get; set; }
    }
}
