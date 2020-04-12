using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Domain.Entity.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.Services.Interfaces
{
    public interface IBoard195Service
    {
        /// <summary>
        /// 게시판 리스트 가져오기
        /// </summary>
        /// <param name="page">페이지 번호</param>
        /// <param name="pageSize">페이지 사이즈</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<(IEnumerable<Board195> List, int TotalCount)> GetListWithCountAsync(int? page = 1,
                                                                                 int? pageSize = 5,
                                                                                 CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// 게시판 조회수 증가 하기
        /// </summary>
        /// <param name="seq">게시판 번호</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateReadNumAsync(Board195 board, CancellationToken cancellationToken = default);
    }
}
