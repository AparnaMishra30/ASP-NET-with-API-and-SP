namespace Training_webApp.Models
{
    internal class APIResponse
    {
        public int successcode { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
        public object additionaldata { get; set; }
    }
}