using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Services.Interfaces;
using Prism.Mvvm;
using System.Threading.Tasks;

namespace Blazor.Corona.View.ViewModels
{
    public class AnnounceCoronaInfoViewModel : BindableBase, IAsyncInitialization
    {
        #region Private fields Area
        private IBoard196Service _coronaInfoService;
        private Board196 _coronaInfo;
        private Board196 _nextCoronaInfo;
        private Board196 _prevCoronaInfo;
        private bool _canViewContent = false;
        #endregion

        public AnnounceCoronaInfoViewModel(IBoard196Service coronaInfoService)
        {
            _coronaInfoService = coronaInfoService;
            Initialization = InitializeAsync();
        }

        #region Property Area
        public Board196 CoronaInfo
        {
            get
            {
                return _coronaInfo;
            }
            set
            {
                SetProperty(ref _coronaInfo, value);
            }
        }

        public Board196 NextCoronaInfo
        {
            get
            {
                return _nextCoronaInfo;
            }
            set
            {
                SetProperty(ref _nextCoronaInfo, value);
            }
        }

        public bool CanViewContent
        {
            get
            {
                return _canViewContent;
            }
            set
            {
                var ret = SetProperty(ref _canViewContent, value);
                if (ret && _canViewContent)
                {
                    Initialization = updateReadNumAsync();
                }
            }
        }

        public Board196 PrevCoronaInfo
        {
            get
            {
                return _prevCoronaInfo;
            }
            set
            {
                SetProperty(ref _prevCoronaInfo, value);
            }
        }
        #endregion

        #region IAsyncInitialization Interface Implement
        public Task Initialization { get; private set; }
        #endregion

        #region Public Method
        public async Task GetPrevCoronoInfo()
        {
            if(PrevCoronaInfo != null)
            {
                await getCoronaInfoAsync(PrevCoronaInfo.Seq);
            }
        }
        public async Task GetNextCoronoInfo()
        {
            if (NextCoronaInfo != null)
            {
                await getCoronaInfoAsync(NextCoronaInfo.Seq);
            }
        }

        public void ToggleContent()
        {
            CanViewContent = !_canViewContent;
        }
        #endregion

        #region Private Method
        private async Task InitializeAsync()
        {
            await getCoronaInfoAsync(null);
        }

        private async Task updateReadNumAsync()
        {
            if(CoronaInfo != null)
            {
                await _coronaInfoService.UpdateReadNumAsync(CoronaInfo);
            }
        }

        private async Task getCoronaInfoAsync(int? seq)
        {
            CoronaInfo = await _coronaInfoService.GetBoardAsync(seq);
            if (CoronaInfo != null)
            {
                NextCoronaInfo = await _coronaInfoService.GetNextBoardAsync(CoronaInfo.Seq);
                PrevCoronaInfo = await _coronaInfoService.GetPrevBoardAsync(CoronaInfo.Seq);
                if (CanViewContent)
                {
                    await updateReadNumAsync();
                }
            }
        }
        #endregion
    }
}
