namespace _4Sale.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool Temp { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}