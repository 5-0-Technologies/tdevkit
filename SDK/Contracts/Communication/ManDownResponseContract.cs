using SDK.Enum;

namespace SDK.Contracts.Communication
{
    public class ManDownResponseContract
    {
        public string Login { get; set; }

        public long Timestamp { get; set; }

        public ActionType Action { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; }
    }
}
