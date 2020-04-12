using Blazor.Corona.View.Common;
using Prism.Events;
using Prism.Mvvm;

namespace Blazor.Corona.View.ViewModels
{
    public class IndexPopupViewModel : BindableBase
    {
        public IndexPopupViewModel(IEventAggregator ea)
        {
            ea.GetEvent<TogglePopupEvent>().Subscribe(OpenPop);
        }
        private IndexPop _indexPop = IndexPop.None;

        #region Public Property Area
        public IndexPop IndexPop
        {
            get
            {
                return _indexPop;
            }
            set
            {
                SetProperty(ref _indexPop, value);
            }
        }
        #endregion

        #region Public Method
        public void OpenPop(IndexPop indexPop)
        {
            IndexPop = indexPop;
        }

        public void ClosePop()
        {
            IndexPop = IndexPop.None;
        }
        #endregion
    }
}
