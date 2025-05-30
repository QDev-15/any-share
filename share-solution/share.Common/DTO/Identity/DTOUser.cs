using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace share.Common.DTO.Identity
{
    public class DTOUser : DTOBase
    {
        public string Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }
        public DateTime? BoD { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Token { get; set; }
        public ICollection<DTORole> Roles { get; set; } = new List<DTORole>();
        public ICollection<DTOComment> Comments { get; set; } = new List<DTOComment>();
    }
}
