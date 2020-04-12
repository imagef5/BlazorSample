using Blazor.Corona.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.Services.Interfaces
{
    public interface ICoronaStatusInfoService
    {
        /// <summary>
        /// 코로나 상황 정보 가져오기
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>코로나 상황 정보</returns>
        CoronaStatusInfo GetCoronaStatus();
        /// <summary>
        /// 코로나 상황 정보 가져오기
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>코로나 상황 정보</returns>
        Task<CoronaStatusInfo> GetCoronaStatusInfoAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
