using Blazor.Corona.DAL.Infrastructure;
using Blazor.Corona.DAL.Interfaces;
using Blazor.Corona.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Corona.DAL.Repositories
{
    public class CoronaStatusInfoRepository : RepositoryBase<CoronaStatusInfo> , ICoronaStatusInfoRepository
    {
        public CoronaStatusInfoRepository(CoronaContext context) : base(context)
        {

        }
    }
}
