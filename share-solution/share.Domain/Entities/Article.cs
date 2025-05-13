using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Article : BaseEntities
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? Source { get; set; } // nếu là bài repost
        public string? Author { get; set; } // nếu là bài tự viết
        public ICollection<Category> Categories { get; set; } = new List<Category>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Like> Likes { get; set; } = new List<Like>();
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public SeoMeta? SeoMeta { get; set; }
    }
}
