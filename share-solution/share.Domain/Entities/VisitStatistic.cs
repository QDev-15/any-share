using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class VisitStatistic : BaseEntities
    {
        public DateTime Date { get; set; }
        public int ViewCount { get; set; }
        public string? Url { get; set; }
    }
}
