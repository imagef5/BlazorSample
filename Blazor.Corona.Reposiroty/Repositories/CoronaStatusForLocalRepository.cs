using Blazor.Corona.DAL.Infrastructure;
using Blazor.Corona.DAL.Interfaces;
using Blazor.Corona.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor.Corona.DAL.Repositories
{
    public class CoronaStatusForLocalRepository : RepositoryBase<CoronaStatusForLocal> , ICoronaStatusForLocalRepository
    {
        public CoronaStatusForLocalRepository(CoronaContext context) : base(context)
        {

        }
    }
}
