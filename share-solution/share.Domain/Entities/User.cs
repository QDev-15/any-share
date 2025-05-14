using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class User : BaseEntities
    {
        public string Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }
        public DateTime? BoD { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Token { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
