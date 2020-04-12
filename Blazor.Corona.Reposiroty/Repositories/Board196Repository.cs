using Blazor.Corona.DAL.Infrastructure;
using Blazor.Corona.DAL.Interfaces;
using Blazor.Corona.Domain.Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.DAL.Repositories
{
    public class Board196Repository : RepositoryBase<Board196> , IBoard196Repository
    {
        private readonly ILogger _logger;
        public Board196Repository(CoronaContext context, ILogger<Board196Repository> logger) : base(context)
        {
            _logger = logger;
        }

        public async Task<bool> UpdateReadNumAsync(Board196 board, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            
            bool isUpdate = false;
            try
            {
                //var commandText = "UPDATE board_196 SET READNUM = READNUM + 1 WHERE SEQ = @Seq";
                //var param = new SqlParameter("@Seq", board.Seq);
                //await Context.Database.ExecuteSqlRawAsync(commandText, param, cancellationToken);
                Context.Board196.Attach(board);
                Context.Entry(board).Property(m => m.ReadNum).IsModified = true;
                await Context.SaveChangesAsync(cancellationToken);
                isUpdate = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                isUpdate = false;
            }

            return isUpdate;
        }
    }
}
