using ElasticSearchInDotNet.Models;
using Nest;
using System.Collections.Generic;

namespace ElasticSearchInDotNet.Rapository
{
    public interface ISearchClient
    {
        ISearchResponse<Student> SearchName(string searchText);

        ISearchResponse<Student> GetAllData();

        List<double> AgeSumMultiple();
    }
}
