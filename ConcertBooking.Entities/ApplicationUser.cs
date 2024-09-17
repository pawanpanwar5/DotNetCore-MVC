using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Identity: membership program: Authentication-credentials(username and passwords)
//and Authorization(access rights)
// Authentication:
// Register: IdentityUser class- Id(Guid), UserName, Password, email, phone
// SignInManager - check User SignIn, signin
// UserManager: store user data in db, get userinfo from db, add role to user
// IdentityRole: Id, name
// claim: piece of information about user
// ClaimsIdentity: list of claims


namespace ConcertBooking.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? Address { get; set; }
        public string? Pincode { get; set; }
    }
}
