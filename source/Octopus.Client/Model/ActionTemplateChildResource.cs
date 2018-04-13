using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class ActionTemplateChildResource : CompositeActionTemplateChildResource
    {
        [WriteableOnCreate]
        public string ActionTemplateId { get; set; }
        public int Version { get; set; }
    }
}