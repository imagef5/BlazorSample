using Blazor.Corona.DAL.Interfaces;
using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.Services.Services
{
    public class CoronaStatusForLocalService : ICoronaStatusForLocalService
    {
        #region
        ICoronaStatusForLocalRepository localRepository;
        #endregion

        public CoronaStatusForLocalService(ICoronaStatusForLocalRepository repository)
        {
            localRepository = repository;
        }

        /// <summary>
        /// 인천시 코로나 바이러스 감염증 대응 현황 정보 가져오기
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<CoronaStatusForLocal> GetCoronaStatusForLocalAsync(CancellationToken cancellationToken = default)
        {
            return await localRepository.Queryable().FirstOrDefaultAsync();
        }
    }
}
