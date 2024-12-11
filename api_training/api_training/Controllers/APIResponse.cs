namespace api_training.Controllers
{
    public class APIResponse
    {
        public int successcode { get; set; }
        public string msg { get; set; }
        public object data { get; set; }
    }
}