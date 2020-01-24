using Contracts;
using HostViews;
using System.AddIn.Pipeline;
using System.Windows;

/// <summary>
///     Adapts the add-in contract to the host's view of the add-in
/// </summary>
namespace HostSideAdapters
{
    /// <summary>
    /// Adapts the add-in contract to the host's view of the add-in
    /// </summary>
    /// <seealso cref="HostViews.IWPFAddInHostView" />
    [HostAdapter]
    public class ContractToViewHostSideAdapter : IWPFAddInHostView
    {
        /// <summary>
        /// The WPF add in contract
        /// </summary>
        private readonly IWPFAddInContract contract;

        /// <summary>
        /// The WPF add in contract handle
        /// </summary>
        private ContractHandle contractHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContractToViewHostSideAdapter" /> class.
        /// </summary>
        /// <param name="contract">The contract.</param>
        public ContractToViewHostSideAdapter(IWPFAddInContract contract)
        {
            // Adapt the contract (IWPFAddInContract) to the host application's
            // view of the contract (IWPFAddInHostView)
            this.contract = contract;

            // Prevent the reference to the contract from being released while the
            // host application uses the add-in
            if (contract == null)
            {
                return;
            }
            this.contractHandle = new ContractHandle(contract);
        }

        /// <summary>
        /// Gets the add in UI.
        /// </summary>
        /// <returns></returns>
        public FrameworkElement GetAddInUi()
        {
            // Convert the INativeHandleContract that was passed from the add-in side
            // of the isolation boundary to a FrameworkElement
            var nativeHandleContract = this.contract.GetAddInUi();
            if (nativeHandleContract == null)
            {
                return null;
            }

            var frameworkElement = FrameworkElementAdapters.ContractToViewAdapter(nativeHandleContract);
            return frameworkElement;
        }
    }
}