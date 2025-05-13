using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public  class Localization : BaseEntities
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public Guid LanguageId { get; set; }
        public Language? Language { get; set; }
    }
}
