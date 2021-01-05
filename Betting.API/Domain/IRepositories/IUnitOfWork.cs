using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Betting.API.Domain.IRepositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
