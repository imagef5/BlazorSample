using Blazor.Corona.DAL.Interfaces;
using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.Services.Services
{
    public class Board195Service : IBoard195Service
    {
        #region
        IBoard195Repository board195Reposiroty;
        #endregion

        public Board195Service(IBoard195Repository repository)
        {
            board195Reposiroty = repository;
        }

        /// <summary>
        /// 게시판 리스트 가져오기
        /// </summary>
        /// <param name="page">페이지 번호</param>
        /// <param name="pageSize">페이지 사이즈</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<(IEnumerable<Board195> List, int TotalCount)> GetListWithCountAsync(
            int? page = 1,
            int? pageSize = 5,
            CancellationToken cancellationToken = default)
        {
            page = (page < 0) ? 1 : page.Value;
            pageSize = (pageSize < 0) ? 5 : pageSize.Value;

            var totalCount = await board195Reposiroty.CountAsync(null);
            var list = await board195Reposiroty.SelectAsync(orderBy: x => x.OrderByDescending(m => m.Seq), page: page, pageSize: pageSize);

            return (list, totalCount);
        }
        /// <summary>
        /// 게시판 조회수 증가 하기
        /// </summary>
        /// <param name="seq">게시판 번호</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateReadNumAsync(Board195 board, CancellationToken cancellationToken = default)
        {
            board.ReadNum += 1;
            await board195Reposiroty.UpdateReadNumAsync(board, cancellationToken);
        }
    }
}
