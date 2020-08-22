using System.AddIn.Contract;
using System.AddIn.Pipeline;
using AddInViews1;
using Contracts1;

namespace AddInSideAdapters1
{
    /// <summary>
    ///     Adapts the add-in's view1 of the contract to the add-in contract
    /// </summary>
    [AddInAdapter]
    public class WPFAddInView1ToContractAddInSideAdapter : ContractBase, IWPFAddInContract1
    {
        /// <summary>
        /// The WPF add in view1
        /// </summary>
        private readonly IWPFAddInView1 _view1;

        /// <summary>
        /// Initializes a new instance of the <see cref="WPFAddInView1ToContractAddInSideAdapter" /> class.
        /// </summary>
        /// <param name="view1">The WPF add in view1.</param>
        public WPFAddInView1ToContractAddInSideAdapter(IWPFAddInView1 view1)
        {
            // Adapt the add-in view1 of the contract (IWPFAddInView1)
            // to the contract (IWPFAddInContract)
            this._view1 = view1;
        }

        /// <summary>
        /// Gets the add in UI.
        /// </summary>
        /// <returns></returns>
        public INativeHandleContract GetAddInUi()
        {
            // Convert the FrameworkElement from the add-in to an INativeHandleContract
            // that will be passed across the isolation boundary to the host application.
            var frameworkElement = _view1.GetAddInUi();
            if (frameworkElement == null)
            {
                return null;
            }

            var nativeHandleContract = FrameworkElementAdapters.ViewToContractAdapter(frameworkElement);
            return nativeHandleContract;
        }
    }
}