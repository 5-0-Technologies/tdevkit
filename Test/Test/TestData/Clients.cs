using SDK.Models;
using System;

namespace Test.TestData
{
    public static class Clients
    {
        public static ClientContract GetClient()
        {
            return new ClientContract
            {
                Id = 1,
                Guid = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Title = "Test Client"
            };
        }

        public static ClientContract[] GetClients()
        {
            return new ClientContract[]
            {
                new ClientContract
                {
                    Id = 1,
                    Guid = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                    Title = "Test Client 1"
                },
                new ClientContract
                {
                    Id = 2,
                    Guid = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                    Title = "Test Client 2"
                }
            };
        }
    }
} 