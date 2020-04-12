using Blazor.Corona.View.Common;
using Prism.Events;

namespace Blazor.Corona.View.ViewModels
{
    public class IndexViewModel : BaseViewModel
    {
        #region Private Fields Area
        private IEventAggregator _ea;
        private bool _canViewMobileCoronaTerms;
        #endregion

        public IndexViewModel(IEventAggregator ea)
        {
            _ea = ea;
        }

        #region Public Property Area
        public bool CanViewMobileCoronaTerms
        {
            get
            {
                return _canViewMobileCoronaTerms;
            }
            set
            {
                if(SetProperty(ref _canViewMobileCoronaTerms, value))
                {
                    _ea.GetEvent<ToggleMobileCoronaTermsEvent>().Publish(_canViewMobileCoronaTerms);
                }
            }
        }

        #endregion

        #region Public Method
        public void OpenPop(IndexPop indexPop)
        {
            _ea.GetEvent<TogglePopupEvent>().Publish(indexPop);
        }

        public void ToggleMobileCoronaTerms()
        {
            CanViewMobileCoronaTerms = !_canViewMobileCoronaTerms;
        }
        #endregion
    }
}
