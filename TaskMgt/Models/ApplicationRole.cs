using Microsoft.AspNetCore.Identity;

namespace TaskMgt.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string role) : base(role)
        {

        }

        public ApplicationRole()
        {

        }
    }
}
