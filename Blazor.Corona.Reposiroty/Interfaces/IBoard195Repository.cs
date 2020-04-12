using Blazor.Corona.DAL.Infrastructure;
using Blazor.Corona.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.DAL.Interfaces
{
    public interface IBoard195Repository : IRepository<Board195>
    {
        Task<bool> UpdateReadNumAsync(Board195 board, CancellationToken cancellationToken);
    }
}
