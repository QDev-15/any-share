using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Rating : BaseEntities
    {
        public Guid ArticleId { get; set; }
        public int Stars { get; set; } // 1–5
        public string UserIdentifier { get; set; }   // IP hoặc UserId nếu đã đăng nhập
        public Article? Article { get; set; }
    }
}
