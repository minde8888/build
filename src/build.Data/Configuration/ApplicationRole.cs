using Microsoft.AspNetCore.Identity;

namespace build.Data.Configuration
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole() : base()
        {
        }
        public ApplicationRole(string roleName) : base(roleName)
        {
        }
    }
}
