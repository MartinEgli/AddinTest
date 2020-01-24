using AddInViews;
using Contracts;
using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace AddInSideAdapters
{
    /// <summary>
    ///     Adapts the add-in's view of the contract to the add-in contract
    /// </summary>
    [AddInAdapter]
    public class IWPFAddInViewToContractAddInSideAdapter : ContractBase, IWPFAddInContract
    {
        /// <summary>
        /// The WPF add in view
        /// </summary>
        private readonly IWPFAddInView view;

        /// <summary>
        /// Initializes a new instance of the <see cref="IWPFAddInViewToContractAddInSideAdapter" /> class.
        /// </summary>
        /// <param name="view">The WPF add in view.</param>
        public IWPFAddInViewToContractAddInSideAdapter(IWPFAddInView view)
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