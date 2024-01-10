using ElasticSearchInDotNet.Models;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;

namespace ElasticSearchInDotNet.Rapository
{
    public class SearchClient : ISearchClient
    {
        private readonly ElasticClient client;

        public SearchClient(IConfiguration configuration)
        {
            client = new ElasticClient(
                new ConnectionSettings(new Uri(configuration.GetValue<string>("ElasticCloud:Endpoint")))
                    .DefaultIndex("test_index")
                    .BasicAuthentication(configuration.GetValue<string>("ElasticCloud:BasicAuthUser"),
                        configuration.GetValue<string>("ElasticCloud:BasicAuthPassword")));
        }

        public ISearchResponse<Student> SearchName(string searchText)
        {
            return client.Search<Student>(s => s
                .From(0)
                .Size(10)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Name)
                        .Query(searchText)
                    )
                ));
        }

        public ISearchResponse<Student> GetAllData()
        {
            return client.Search<Student>(s => s
                .Query(q => q
                    .MatchAll()
                ));
        }

        //Return sum of multiple fields in single query
        public List<double> AgeSumMultiple()
        {
            var result = client.Search<Student>(s => s
        .Aggregations(a => a
            .Sum("age_agg", st => st
                .Field(o => o.Age)
                    )
            .Sum("id_agg", st => st
                .Field(o => o.Id)
                    )
                )
            );

            //Other way to declare list and use
            //List<double> obj = new List<double>();

            //obj.Add((double)result.Aggregations.Sum("age_agg").Value);
            //obj.Add((double)result.Aggregations.Sum("id_agg").Value);

            List<double> obj = new List<double>
            {
                (double)result.Aggregations.Sum("age_agg").Value,
                (double)result.Aggregations.Sum("id_agg").Value
            };
            return obj;
        }

        //Return sum of single field in single query
        public double AgeSumSingle()
        {
            var result = client.Search<Student>(s => s
        .Aggregations(a => a
            .Sum("age_agg", st => st
                .Field(o => o.Age)
                    )
                )
            );
            return (double)result.Aggregations.Sum("id_agg").Value;
        }
    }


}
