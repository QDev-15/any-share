using share.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Domain.Interfaces.Repositories
{
    public interface IRoleInterface
    {
        Task<Role?> GetByIdAsync(Guid id);
        Task<IList<Role>> GetRolesByUserIdAsync(Guid userId);
    }
}
