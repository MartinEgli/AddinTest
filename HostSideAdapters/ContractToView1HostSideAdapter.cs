using System.AddIn.Pipeline;
using System.Windows;
using Contracts1;
using HostViews1;

/// <summary>
///     Adapts the add-in contract to the host's view of the add-in
/// </summary>
namespace HostSideAdapters1
{
    /// <summary>
    ///     Adapts the add-in contract to the host's view of the add-in
    /// </summary>
    /// <seealso cref="IWpfAddInHostView1" />
    [HostAdapter]
    public class ContractToView1HostSideAdapter : IWpfAddInHostView1
    {
        /// <summary>
        ///     The WPF add in contract
        /// </summary>
        private readonly IWPFAddInContract1 contract;

        /// <summary>
        ///     The WPF add in contract handle
        /// </summary>
        private ContractHandle contractHandle;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContractToView1HostSideAdapter" /> class.
        /// </summary>
        /// <param name="contract">The contract.</param>
        public ContractToView1HostSideAdapter(IWPFAddInContract1 contract)
        {
            // Adapt the contract (IWPFAddInContract) to the host application's
            // view of the contract (IWPFAddInHostView1)
            this.contract = contract;

            // Prevent the reference to the contract from being released while the
            // host application uses the add-in
            if (contract == null) return;
            contractHandle = new ContractHandle(contract);
        }

        /// <summary>
        ///     Gets the add in UI.
        /// </summary>
        /// <returns></returns>
        public FrameworkElement GetAddInUi()
        {
            // Convert the INativeHandleContract that was passed from the add-in side
            // of the isolation boundary to a FrameworkElement
            var nativeHandleContract = contract.GetAddInUi();
            if (nativeHandleContract == null) return null;

            var frameworkElement = FrameworkElementAdapters.ContractToViewAdapter(nativeHandleContract);
            return frameworkElement;
        }
    }
}