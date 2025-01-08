namespace OnePoint.PDK.CustomAttribute
{
    public class CustomEndpointAttribute : Attribute
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public CustomEndpointAttribute(string method, string path)
        {
            Method = method;
            Path = path;
        }
    }
}
