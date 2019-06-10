using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CozyCo.Domain.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public ICollection<Lease> Leases { get; set; }
    }
}