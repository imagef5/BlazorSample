using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Services.Interfaces;
using System.Threading.Tasks;

namespace Blazor.Corona.View.ViewModels
{
    public class LocalStateViewModel : BaseViewModel , IAsyncInitialization
    {
        #region Private fields Area
        private ICoronaStatusForLocalService _statusInfoService;
        private CoronaStatusForLocal _localStatus;
        #endregion

        public LocalStateViewModel(ICoronaStatusForLocalService statusInfoService)
        {
            _statusInfoService = statusInfoService;
            Initialization = InitializeAsync();
        }

        #region Property Area
        public CoronaStatusForLocal LocalStatus
        {
            get
            {
                return _localStatus;
            }
            private set
            {
                SetProperty(ref _localStatus, value);
            }
        }

        public Task Initialization { get; private set; }
        #endregion

        private async Task InitializeAsync()
        {
            LocalStatus = await _statusInfoService.GetCoronaStatusForLocalAsync();
        }
    }
}
