using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class SeoMeta : BaseEntities
    {
        public Guid ArticleId { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public Article? Article { get; set; }
    }
}
