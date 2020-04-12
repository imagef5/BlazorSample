using Blazor.Corona.DAL.Infrastructure;
using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Domain.Entity.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.DAL.Interfaces
{
    public interface IBoard196Repository : IRepository<Board196>
    {
        Task<bool> UpdateReadNumAsync(Board196 board, CancellationToken cancellationToken);
    }
}
