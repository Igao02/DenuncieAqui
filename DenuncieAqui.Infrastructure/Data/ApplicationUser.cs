using DenuncieAqui.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace DenuncieAqui.Infrastructure.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public List<Reports> Reports { get; set; }
        
    }

}
