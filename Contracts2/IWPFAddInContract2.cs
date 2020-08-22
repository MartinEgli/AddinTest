using System.AddIn.Contract;
using System.AddIn.Pipeline;

namespace Contracts2
{
    [AddInContract]
    public interface IWPFAddInContract2 : IContract
    {
        /// <summary>
        /// Gets the UI to the host applicationI.
        /// </summary>
        /// <returns></returns>
        INativeHandleContract GetAddInUi();
    }
}