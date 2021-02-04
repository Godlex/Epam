namespace SalesApplication.BLL
{
    using System.Collections.Generic;
    using Models;

    public interface ICsvFileReader
    {
        IEnumerable<SalesInfo> Read(string filePath);
    }
}