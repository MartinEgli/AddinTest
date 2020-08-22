using System.AddIn.Contract;
using System.AddIn.Pipeline;
using AddInViews2;
using Contracts2;

namespace AddInSideAdapters2
{
    /// <summary>
    ///     Adapts the add-in's view of the contract to the add-in contract
    /// </summary>
    [AddInAdapter]
    public class WpfAddInView2ToContractAddInSideAdapter : ContractBase, IWPFAddInContract2
    {
        /// <summary>
        /// The WPF add in view
        /// </summary>
        private readonly IWPFAddInView2 view;

        /// <summary>
        /// Initializes a new instance of the <see cref="WpfAddInView2ToContractAddInSideAdapter" /> class.
        /// </summary>
        /// <param name="view">The WPF add in view.</param>
        public WpfAddInView2ToContractAddInSideAdapter(IWPFAddInView2 view)
        {
            // Adapt the add-in view of the contract (IWPFAddInView)
            // to the contract (IWPFAddInContract)
            this.view = view;
        }

        /// <summary>
        /// Gets the add in UI.
        /// </summary>
        /// <returns></returns>
        public INativeHandleContract GetAddInUi()
        {
            // Convert the FrameworkElement from the add-in to an INativeHandleContract
            // that will be passed across the isolation boundary to the host application.
            var frameworkElement = view.GetAddInUi();
            if (frameworkElement == null)
            {
                return null;
            }

            var nativeHandleContract = FrameworkElementAdapters.ViewToContractAdapter(frameworkElement);
            return nativeHandleContract;
        }
    }
}