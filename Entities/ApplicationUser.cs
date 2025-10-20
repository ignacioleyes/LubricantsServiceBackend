using Microsoft.AspNetCore.Identity;

namespace LubricantsServiceBackend.Entities;
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public UserTypeEnum UserType { get; set; }
    }

    public enum UserTypeEnum
    {
        Admin
    }
