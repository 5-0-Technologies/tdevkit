using SDK.Communication;
using System;

namespace Test.TestData
{
    public static class Authorization
    {
        public static AuthenticationResponseContract GetAuthenticationResponse()
        {
            return new AuthenticationResponseContract
            {
                Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c",
                Client = "00000000-0000-0000-0000-000000000001",
                Branch = "00000000-0000-0000-0000-000000000003",
                Expiration = DateTimeOffset.Now.AddHours(24).ToUnixTimeMilliseconds(),
                Created = DateTimeOffset.Now.ToUnixTimeMilliseconds()
            };
        }
    }
} 