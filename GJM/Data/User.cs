using Microsoft.AspNetCore.Identity;

namespace GJM.Data
{
    public class User : IdentityUser
    {
        public string? Image { get; set; }
        public virtual IList<Game>? Games { get; set; }
    }
}
