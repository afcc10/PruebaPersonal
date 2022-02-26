using System.Net;
using System.Web.Http;

namespace PruebaIngresoBibliotecario.Api.Helpres
{
    public class ApiResponse
    {
        ///<summary>IsSuccess</summary>
        public bool IsSuccess { get; set; }
        /// <summary>StatusCode</summary>
        public HttpStatusCode StatusCode { get; set; }
        ///<summary>Result</summary>
        public object Result { get; set; }
        ///<summary>Error</summary>
        public ApiErrorResponse Error { get; set; }
    }

    public class ApiErrorResponse
    {
        ///<summary>Message</summary>
        public string Message { get; set; }
        ///<summary>Info</summary>
        public object Info { get; set; }
    }
}
