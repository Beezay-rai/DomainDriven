using Microsoft.AspNetCore.Mvc;

namespace DomainApp.Custom
{
    public class CustomProduceResponseTypeAttribute : ProducesResponseTypeAttribute
    {
        private readonly Type _exampleProviderType;
        private readonly string _description;
        private readonly string[] _contentTypes;

        public CustomProduceResponseTypeAttribute(int statusCode, string description = "")
            : base(statusCode)
        {
            _description = description;
        }

        public CustomProduceResponseTypeAttribute(Type type, int statusCode)
            : base(type, statusCode)
        {
        }

        public CustomProduceResponseTypeAttribute(
            Type type,
            int statusCode,
            string contentType,
            string description = "",
            params string[] additionalContentTypes)
            : base(type, statusCode, contentType, additionalContentTypes)
        {
            _description = description;
            _contentTypes = new[] { contentType }.Concat(additionalContentTypes).ToArray();
        }

        public CustomProduceResponseTypeAttribute(
            Type type,
            int statusCode,
            Type exampleProviderType,
            string contentType,
            string description = "",
            params string[] additionalContentTypes)
            : base(type, statusCode, contentType, additionalContentTypes)
        {

            _description = description;
            _contentTypes = new[] { contentType }.Concat(additionalContentTypes).ToArray();
            _exampleProviderType = exampleProviderType;
        }

        public string[] GetContentTypes()
        {
            return _contentTypes ?? Array.Empty<string>();
        }

        public Type GetExampleProviderType()
        {
            return _exampleProviderType;
        }

        public string GetDescription()
        {
            return _description;
        }
    }
}
