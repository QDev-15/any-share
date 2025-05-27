using share.Application.Interfaces;
using share.Domain.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace share.Infrastructure.Logging
{
    public class LogQueue : ILogQueue
    {
        private readonly ConcurrentQueue<Log> _queue = new();

        public void Enqueue(Log log) => _queue.Enqueue(log);

        public bool TryDequeue(out Log log) => _queue.TryDequeue(out log);
    }
}
