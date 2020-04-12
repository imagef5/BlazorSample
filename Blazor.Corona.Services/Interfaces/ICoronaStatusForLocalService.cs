using Blazor.Corona.Domain.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.Services.Interfaces
{
    public interface ICoronaStatusForLocalService
    {
        /// <summary>
        /// 인천시 코로나 바이러스 감염증 대응 현황 정보 가져오기
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<CoronaStatusForLocal> GetCoronaStatusForLocalAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
