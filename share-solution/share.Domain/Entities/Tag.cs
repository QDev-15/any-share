﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Entities
{
    public class Tag : BaseEntities
    {
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; } = new List<Article>();
    }
}
