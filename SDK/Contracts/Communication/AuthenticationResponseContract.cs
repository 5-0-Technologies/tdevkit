namespace SDK.Communication
{
    public class AuthenticationResponseContract : PostResponseContract
    {
        public string Token { get; set; }

        public long Expiration { get; set; }

        public long Created { get; set; }

        public string Client { get; set; }

        public string Branch { get; set; }
    }
}
