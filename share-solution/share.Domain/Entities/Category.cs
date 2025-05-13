using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Category : BaseEntities
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public Guid? ParentId { get; set; }
        public Category? Parent { get; set; }
        public ICollection<Category> Childrens { get; set; } = new List<Category>();
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
