using ElasticSearchInDotNet.Models;
using Nest;

namespace ElasticSearchInDotNet
{
    public interface ISearchClient
    {
        ISearchResponse<Student> SearchOrder(string searchText);
    }
}
