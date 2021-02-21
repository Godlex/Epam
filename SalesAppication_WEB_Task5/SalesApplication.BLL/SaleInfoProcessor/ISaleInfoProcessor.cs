namespace SalesApplication.BLL
{
    using System.Collections.Generic;
    using Models;

    public interface ISaleInfoProcessor
    {
        void Processes(IEnumerable<SalesInfo> salesInfos, string fileName);
    }
}