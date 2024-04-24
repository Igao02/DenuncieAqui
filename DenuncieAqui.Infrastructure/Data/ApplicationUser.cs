using DenuncieAqui.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DenuncieAqui.Infrastructure.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Reports> Reports { get; set; } = new List<Reports>();

        public List<Comments> Comments { get; set; } = new List<Comments>();

        public List<Likes> Likes { get; set; } = new List<Likes>();
        
    }

}
