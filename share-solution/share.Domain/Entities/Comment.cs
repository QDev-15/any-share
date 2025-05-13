using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Comment : BaseEntities
    {
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public Article? Article { get; set; }
        public User? User { get; set; }
    }
}
