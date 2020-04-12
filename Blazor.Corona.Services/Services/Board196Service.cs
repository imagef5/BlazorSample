using Blazor.Corona.DAL.Interfaces;
using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Blazor.Corona.Services.Services
{
    public class Board196Service : IBoard196Service
    {
        #region
        IBoard196Repository board196Reposiroty;
        #endregion

        public Board196Service(IBoard196Repository repository)
        {
            board196Reposiroty = repository;
        }

        /// <summary>
        /// 게시판 리스트 가져오기
        /// </summary>
        /// <param name="page">페이지 번호</param>
        /// <param name="pageSize">페이지 사이즈</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<(IEnumerable<Board196> List, int TotalCount)> GetListWithCountAsync(
            int? page = 1,
            int? pageSize = 5,
            CancellationToken cancellationToken = default)
        {
            page = (page < 0) ? 1 : page.Value;
            pageSize = (pageSize < 0) ? 5 : pageSize.Value;

            var totalCount = await board196Reposiroty.CountAsync(null);
            var list = await board196Reposiroty.SelectAsync(orderBy: x=> x.OrderByDescending(m => m.Seq) , page: page, pageSize: pageSize);

            return (list, totalCount);
        }

        /// <summary>
        /// 게시판 상세정보 가져오기
        /// </summary>
        /// <param name="seq">게시판 번호</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Board196> GetBoardAsync(int? seq = null, CancellationToken cancellationToken = default)
        {
            Board196 board = null;
            if (seq.HasValue)
            {
                board = await board196Reposiroty.FindByIdAsync(seq.Value, cancellationToken);
            }
            else
            {
                board = await board196Reposiroty.Queryable().AsNoTracking().OrderByDescending(x => x.Seq).FirstOrDefaultAsync(cancellationToken);
            }

            return board;
        }

        /// <summary>
        /// 이전 게시판 번호 가져오기
        /// </summary>
        /// <param name="seq">게시판 번호</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Board196> GetPrevBoardAsync(int seq, CancellationToken cancellationToken = default)
        {
            var board = await board196Reposiroty.Queryable().AsNoTracking().Where(x => x.Seq < seq).OrderByDescending(x => x.Seq)
                                .Select(x => new Board196
                                {
                                    Seq = x.Seq                                                           
                                })
                                .FirstOrDefaultAsync(cancellationToken);
            return board;
        }

        /// <summary>
        /// 다음 게시판 번호 가져오기
        /// </summary>
        /// <param name="seq">게시판 번호</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Board196> GetNextBoardAsync(int seq, CancellationToken cancellationToken = default)
        {
            var board = await board196Reposiroty.Queryable().AsNoTracking().Where(x => x.Seq > seq).OrderBy(x => x.Seq)
                                .Select(x => new Board196
                                {
                                    Seq = x.Seq
                                })
                                .FirstOrDefaultAsync(cancellationToken);
            return board;
        }
        /// <summary>
        /// 게시판 조회수 증가 하기
        /// </summary>
        /// <param name="seq">게시판 번호</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task UpdateReadNumAsync(Board196 board, CancellationToken cancellationToken = default)
        {
            board.ReadNum += 1;
            await board196Reposiroty.UpdateReadNumAsync(board, cancellationToken);
        }
    }
}
