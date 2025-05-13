using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Message : BaseEntities
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
    }
}
