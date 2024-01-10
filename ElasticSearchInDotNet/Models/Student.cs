using Nest;
using System;
using System.Collections.Generic;

namespace ElasticSearchInDotNet.Models
{

    public class Student
    {
        [Number(Name = "id")]
        public int Id { get; set; }
        [Text(Name = "name")]
        public string Name { get; set; }
        [Number(Name = "age")]
        public int Age { get; set; }
        [Text(Name = "city")]
        public string City { get; set; }

        public ISearchResponse<Student> Results { get; set; }

    }
}
