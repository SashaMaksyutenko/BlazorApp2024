using System.Collections.Generic;
namespace BlazorApp2024.Utility
{
    public static class SD
    {
        public static readonly string Role_Admin = "Admin";
        public static readonly string Role_Customer = "Customer";
        public static List<string> GetRoles()
        {
            return new List<string> { Role_Admin, Role_Customer };
        }
    }
}
