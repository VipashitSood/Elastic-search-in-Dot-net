using System.Collections.Generic;

namespace ElasticSearchInDotNet.Models
{
    public class SearchResultsModel
    {
        public string SearchText { get; set; }

        public List<Student> Results { get; set; }
    }
}
