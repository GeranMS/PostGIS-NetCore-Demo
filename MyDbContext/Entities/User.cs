using System;
using System.Collections.Generic;
using System.Text;

namespace MyDbContext.Entities
{
    public class User
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public string Avatar { get; set; }
    }
}
