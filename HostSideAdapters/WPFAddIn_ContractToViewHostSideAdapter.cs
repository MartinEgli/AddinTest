using System.AddIn.Pipeline;
using System.Windows;
using Contracts;
using HostViews;

namespace HostSideAdapters
{
    /// <summary>
    ///     Adapts the add-in contract to the host's view of the add-in
    /// </summary>
    namespace HostSideAdapters
    {
        /// <summary>
        ///     Adapts the add-in contract to the host's view of the add-in
        /// </summary>
        [HostAdapter]
        public class WPFAddIn_ContractToViewHostSideAdapter : IWPFAddInHostView
        {
            private readonly IWPFAddInContract _iwpfAddInContract;
            private ContractHandle wpfAddInContractHandle;

            public WPFAddIn_ContractToViewHostSideAdapter(IWPFAddInContract iwpfAddInContract)
            {
                // Adapt the contract (IWPFAddInContract) to the host application's
                // view of the contract (IWPFAddInHostView)
                _iwpfAddInContract = iwpfAddInContract;

                // Prevent the reference to the contract from being released while the
                // host application uses the add-in
                wpfAddInContractHandle = new ContractHandle(iwpfAddInContract);
            }

            public FrameworkElement GetAddInUi()
            {
                // Convert the INativeHandleContract that was passed from the add-in side
                // of the isolation boundary to a FrameworkElement
                var inhc = _iwpfAddInContract.GetAddInUi();
                var fe = FrameworkElementAdapters.ContractToViewAdapter(inhc);
                return fe;
            }
        }
    }
}