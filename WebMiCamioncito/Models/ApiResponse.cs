namespace WebMiCamioncito.Models
{
    public class ApiResponse
    {
        public bool success { get; set; }
        public string? message { get; set; }
        public ApiResult? result { get; set; }
    }
}
