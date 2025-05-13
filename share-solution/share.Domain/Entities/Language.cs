using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Language : BaseEntities
    {
        public string Code { get; set; } // en, vi, ja, ko, etc.
        public string Name { get; set; }
    }
}
