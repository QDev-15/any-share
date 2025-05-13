using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Role : BaseEntities
    {
        public string Name { get; set; }
        public string Type { get; set; } // System, Admin, User, etc.
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
