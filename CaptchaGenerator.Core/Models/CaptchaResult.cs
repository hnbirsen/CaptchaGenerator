using System;
namespace CaptchaGenerator.Core.Models
{
    public class CaptchaResult
    {
        public string code { get; set; }
        public byte[] byteData { get; set; }
        public string base64Data => Convert.ToBase64String(byteData);
        public DateTime timestamp { get; set; }
    }
}
