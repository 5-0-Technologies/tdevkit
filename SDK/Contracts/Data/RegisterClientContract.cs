namespace SDK.Models
{
    public class RegisterClientContract
    {
        public string ClientName { get; set; }

        public string BranchName { get; set; }

        public string Timezone { get; set; }

        public string RegistrationValidationToken { get; set; }
    }

    public class FirebaseTokenContract
    {
        public string Value { get; set; }
    }

    public class AreaImageInfoContract
    {
        public int AreaId { get; set; }

        public System.Guid AreaGuid { get; set; }

        public string UploadUrl { get; set; }

        public string DownloadUrl { get; set; }
    }

    public class UsersRegistrationContract
    {
        public string[] Emails { get; set; }

        public string RegistrationValidationToken { get; set; }
    }

    public class UserWriteContract
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Color { get; set; }

        public string Login { get; set; }

        public int RoleId { get; set; }
    }
}
