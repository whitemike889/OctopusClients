using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class BuiltinActionTemplateChildResource : CompositeActionTemplateChildResource
    {
        [WriteableOnCreate]
        public string ActionType { get; set; }
    }
}