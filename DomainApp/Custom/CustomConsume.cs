using Microsoft.AspNetCore.Mvc;

namespace DomainApp.Custom
{
    public class CustomConsume : ConsumesAttribute
    {
        private readonly Type _type;
        private readonly Type _exampleType;
        public CustomConsume(string contentType, params string[] otherContentTypes) : base(contentType, otherContentTypes)
        {

        }
        public CustomConsume(string contentType, Type type, params string[] otherContentTypes) : base(contentType, otherContentTypes)
        {
            _type = type;
        }
        public CustomConsume(string contentType, Type type, Type ExampleType, params string[] otherContentTypes) : base(contentType, otherContentTypes)
        {
            _type = type;
            _exampleType = ExampleType;
        }
        public new Type GetType()
        {
            return _type;
        }
        public Type GetExampleType()
        {
            return _exampleType;
        }
    }
}
