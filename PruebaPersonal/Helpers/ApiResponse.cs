using PruebaPersonal.Models;
using System.Collections.Generic;
using System.Net;

namespace PruebaPersonal.Helpers
{
    public class ApiResponse
    {
        public HttpStatusCode? status { get; set; }
        public IEnumerable<PolizaModels>? data { get; set; }
        public string Message { get; set; }
        public PolizaModels? poliza { get; set; }
    }
}
