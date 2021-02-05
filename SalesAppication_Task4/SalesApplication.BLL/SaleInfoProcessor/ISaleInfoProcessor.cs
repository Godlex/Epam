namespace SalesApplication.BLL
{
    using System.Collections.Generic;
    using Models;

    public interface ISaleInfoProcessor
    {
        public void Processes(IEnumerable<SalesInfo> salesInfos, string fileName);
    }
}