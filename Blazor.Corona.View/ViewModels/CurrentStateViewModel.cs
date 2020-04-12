using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Services.Interfaces;
using Prism.Mvvm;
using System.Threading.Tasks;

namespace Blazor.Corona.View.ViewModels
{
    public class CurrentStateViewModel : BindableBase, IAsyncInitialization
    {
        #region Private fields Area
        private ICoronaStatusInfoService _statusInfoService;
        private CoronaStatusInfo _currentStatus;
        #endregion

        public CurrentStateViewModel(ICoronaStatusInfoService statusInfoService)
        {
            _statusInfoService = statusInfoService;
            Initialization = InitializeAsync();
        }

        #region Property Area
        public CoronaStatusInfo CurrentStatus
        {
            get
            {
                return _currentStatus;
            }
            private set
            {
                SetProperty(ref _currentStatus, value);
            }
        }

        public Task Initialization { get; private set; }
        #endregion

        private async Task InitializeAsync()
        {
            CurrentStatus = await _statusInfoService.GetCoronaStatusInfoAsync();
        }
    }
}
