using Blazor.Corona.DAL.Infrastructure;
using Blazor.Corona.DAL.Interfaces;
using Blazor.Corona.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.DAL.Repositories
{
    public class Board195Repository : RepositoryBase<Board195> , IBoard195Repository
    {
        public Board195Repository(CoronaContext context) : base(context)
        {

        }

        public async Task<bool> UpdateReadNumAsync(Board195 board, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            bool isUpdate = false;
            try
            {
                Context.Board195.Attach(board);
                Context.Entry(board).Property(m => m.ReadNum).IsModified = true;
                await Context.SaveChangesAsync(cancellationToken);
                isUpdate = true;
            }
            catch
            {
                isUpdate = false;
            }

            return isUpdate;
        }
    }
}
