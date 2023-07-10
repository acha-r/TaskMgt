using Microsoft.AspNetCore.Identity;

namespace TaskMgt.Models
{
    public class ApplicationUser : IdentityUser
    {      
        public ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
