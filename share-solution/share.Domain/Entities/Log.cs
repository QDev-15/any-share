using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Log : BaseEntities
    {
        public string Level { get; set; }
        public string Message { get; set; }
        public string? StackTrace { get; set; }
        public DateTime LoggedAt { get; set; } = DateTime.UtcNow;
    }
}
