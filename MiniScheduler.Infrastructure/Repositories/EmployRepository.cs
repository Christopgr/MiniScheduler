using MiniScheduler.Domain.Models;
using MiniScheduler.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniScheduler.DataAccessLayer.Repositories
{
    public class EmployRepository : RepositoryBase<Employ>, IEmployRepository
    {
        public EmployRepository(MiniSchedulerContext context) : base(context)
        {
        }
    }
}
