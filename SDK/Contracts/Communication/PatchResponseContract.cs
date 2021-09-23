namespace SDK.Contracts.Communication
{
    public class PatchResponseContract
    {
        public bool Success { get; set; } = true;

        public string ErrorMessage { get; set; }
    }
}
