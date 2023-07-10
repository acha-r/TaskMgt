using Microsoft.AspNetCore.Identity;

namespace TaskMgt.Models
{
    public class ApplicationUser : IdentityUser
    {      
        public IEnumerable<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
