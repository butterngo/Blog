namespace Blog.Core
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using System;

    public class User: IdentityUser
    {
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvataUrl { get; set; }
        public DateTime Birthday { get; set; }
    }
}
