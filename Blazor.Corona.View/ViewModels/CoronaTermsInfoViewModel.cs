using Blazor.Corona.View.Common;
using Blazor.Corona.Domain.Entity;
using Blazor.Corona.Services.Interfaces;
using Blazor.Corona.View.Utils;
using Microsoft.Extensions.Logging;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Blazor.Corona.View.ViewModels
{
    public class CoronaTermsInfoViewModel : BindableBase, IAsyncInitialization
    {
        #region Private Fields Area
        private IBoard195Service _coronaTermsInfoService;
        private PaginationModel _pagination = new PaginationModel();
        private IList<Board195> _coronaTermsInfos = new List<Board195>();
        private ILogger<CoronaTermsInfoViewModel> _logger;
        private bool _canViewContent = false;
        private bool _isMobile = false;
        private Board195 _viewContent;
        private IServiceProvider _services;
        #endregion

        public CoronaTermsInfoViewModel(IBoard195Service coronaTermsInfoService,
                                        ILogger<CoronaTermsInfoViewModel> logger,
                                        IServiceProvider services,
                                        IEventAggregator ea)
        {
            _coronaTermsInfoService = coronaTermsInfoService;
            _logger = logger;
            _services = services;
            ea.GetEvent<ToggleMobileCoronaTermsEvent>().Subscribe(toggleMobileToronaTerms);
            Initialization = InitializeAsync();
        }

        #region Public Property Area
        //public ObservableRangeCollection<Board195> CoronaTermsInfos { get; set; } = new ObservableRangeCollection<Board195>();

        public IList<Board195> CoronaTermsInfos
        {
            get
            {
                return _coronaTermsInfos;
            }
            set
            {
                SetProperty(ref _coronaTermsInfos, value);
            }
        }

        public PaginationModel Pagination
        {
            get
            {
                return _pagination;
            }
            set
            {
                SetProperty(ref _pagination, value);
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
            }
        }

        public Board195 ViewContent
        {
            get
            {
                return _viewContent;
            }
            set
            {
                var ret = SetProperty(ref _viewContent, value);
                if (ret)
                {
                    CanViewContent = true;
                }
                else
                {
                    CanViewContent = !_canViewContent;
                }
                if(CanViewContent)
                {
                    Initialization = updateReadNumAsync();
                }

            }
        }
        #endregion

        #region IAsyncInitialization Interface Implement
        public Task Initialization { get; private set; }
        #endregion

        #region Public Method Area
        public void GetCoronaTermsInfo(int page)
        {
            Initialization = getCoronaTermsInfoAsync(page);
        }

        public void ToggleContent(Board195 content)
        {
            ViewContent = content;
        }

        #endregion

        #region Private Method
        private async Task InitializeAsync()
        {
            try
            {
                _isMobile = Util.BrowserIsMobile(_services);
                if (!_isMobile)
                {
                    await getCoronaTermsInfoAsync();
                }
            }
            catch (InvalidOperationException ex)
            {
                _logger.LogDebug(ex, ex.Message);
                await getCoronaTermsInfoAsync();
            }
            catch (Exception ex)
            {
                _logger.LogDebug(ex, ex.Message);
            }
        }

        private async Task getCoronaTermsInfoAsync(int? page = 1, int? pageSize = 5, CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await _coronaTermsInfoService.GetListWithCountAsync(page, pageSize, cancellationToken);
            if (result.List?.Count() > 0)
            {
                //CoronaTermsInfos.ReplaceRange(result.List);
                //OnPropertyChanged(nameof(CoronaTermsInfos));
                CoronaTermsInfos = result.List.ToList();

                var pagination = new PaginationModel();
                pagination.TotalCount = result.TotalCount;
                pagination.CurrentPage = page.Value;
                pagination.RowsPerPage = pageSize.Value;
                Pagination = pagination;
            }
        }

        private async Task updateReadNumAsync()
        {
            if (ViewContent != null)
            {
                await _coronaTermsInfoService.UpdateReadNumAsync(ViewContent);
            }
        }

        private void toggleMobileToronaTerms(bool canView)
        {
            if (canView && _coronaTermsInfos.Count == 0)
            {
                GetCoronaTermsInfo(Pagination.CurrentPage);
            }
        }
        #endregion
    }
}
