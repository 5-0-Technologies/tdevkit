using SDK.Contracts.Data;
using System;

namespace Test.TestData
{
    public static class Users
    {
        public static UserContract GetUser()
        {
            return new UserContract
            {
                Id = 1,
                BranchId = 1,
                Name = "Test",
                Surname = "User",
                Email = "test@example.com",
                Phone = "+1234567890",
                AllowDemo = true
            };
        }

        public static UserContract[] GetUsers()
        {
            return new UserContract[]
            {
                new UserContract
                {
                    Id = 1,
                    BranchId = 1,
                    Name = "Test",
                    Surname = "User1",
                    Email = "test1@example.com",
                    Phone = "+1234567890",
                    AllowDemo = true
                },
                new UserContract
                {
                    Id = 2,
                    BranchId = 1,
                    Name = "Test",
                    Surname = "User2",
                    Email = "test2@example.com",
                    Phone = "+1234567891",
                    AllowDemo = false
                }
            };
        }
    }
} 