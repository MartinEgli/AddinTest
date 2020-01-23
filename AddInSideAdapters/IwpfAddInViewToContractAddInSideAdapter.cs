using System.AddIn.Contract;
using System.AddIn.Pipeline;
using AddInViews;
using Contracts;

namespace AddInSideAdapters
{
    /// <summary>
    ///     Adapts the add-in's view of the contract to the add-in contract
    /// </summary>
    [AddInAdapter]
    public class IwpfAddInViewToContractAddInSideAdapter : ContractBase, IWPFAddInContract
    {
        private readonly IWpfAddInView wpfAddInView;

        public IwpfAddInViewToContractAddInSideAdapter(IWpfAddInView wpfAddInView)
        {
            // Adapt the add-in view of the contract (IWPFAddInView)
            // to the contract (IWPFAddInContract)
            this.wpfAddInView = wpfAddInView;
        }

        public INativeHandleContract GetAddInUi()
        {
            // Convert the FrameworkElement from the add-in to an INativeHandleContract
            // that will be passed across the isolation boundary to the host application.
            var fe = wpfAddInView.GetAddInUi();
            var inhc = FrameworkElementAdapters.ViewToContractAdapter(fe);
            return inhc;
        }
    }
}