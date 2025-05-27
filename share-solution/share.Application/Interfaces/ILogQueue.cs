using share.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Application.Interfaces
{
    public interface ILogQueue
    {
        void Enqueue(Log log);
        bool TryDequeue(out Log log);
    }
}
