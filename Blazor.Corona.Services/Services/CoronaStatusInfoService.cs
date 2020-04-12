using Blazor.Corona.DAL.Interfaces;
using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.Services.Services
{
    public class CoronaStatusInfoService : ICoronaStatusInfoService
    {
        #region
        ICoronaStatusInfoRepository coronaStatusInfoService;
        #endregion

        public CoronaStatusInfoService(ICoronaStatusInfoRepository repository)
        {
            coronaStatusInfoService = repository;
        }

        public CoronaStatusInfo GetCoronaStatus()
        {
            return coronaStatusInfoService.Queryable().FirstOrDefault();
        }

        /// <summary>
        /// 코로나 상황 정보 가져오기
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CoronaStatusInfo> GetCoronaStatusInfoAsync(CancellationToken cancellationToken = default)
        {
            return await coronaStatusInfoService.Queryable().FirstOrDefaultAsync(cancellationToken);
        }
    }
}
