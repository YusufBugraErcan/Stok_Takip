using Microsoft.AspNetCore.Mvc;

namespace stoktakip.Models
{
    public class CustomError : Controller
    {
        public string ErrorMessage { get; set; }
        public int StatusCode { get; set; }
    }
}
