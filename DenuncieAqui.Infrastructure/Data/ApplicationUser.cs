using DenuncieAqui.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DenuncieAqui.Infrastructure.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {

        public List<Report> Reports { get; set; } = new List<Report>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<Like> Likes { get; set; } = new List<Like>();

    }

}
