using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.model
{
    public class Account(string username, string email, string id)
    {
        public string Username { get; } = username;
        public string Email { get; } = email;
        public string Id { get; } = id;

        public Village? Village { get; set; } = null;

        public Clan? Clan { get; set; } = null;
    }
}
