using System;
using System.Collections.Generic;

namespace Teachify.Models
{
    public class City
    {
        public string Name {get;set;}
    }
    public class ResultCitiesModel
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public List<City> Data { get; set; }
        public object ResponseFailed { get; set; }
        public string Message { get; set; }
    }
}