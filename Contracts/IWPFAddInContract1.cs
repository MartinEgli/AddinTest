using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace Contracts1
{
    /// <summary>
    /// Defines the services that an add-in will provide to a host application
    /// </summary>
    /// <seealso cref="System.AddIn.Contract.IContract" />
    [AddInContract]
    public interface IWPFAddInContract1 : IContract
    {
        /// <summary>
        /// Gets the UI to the host applicationI.
        /// </summary>
        /// <returns></returns>
        INativeHandleContract GetAddInUi();
    }
}