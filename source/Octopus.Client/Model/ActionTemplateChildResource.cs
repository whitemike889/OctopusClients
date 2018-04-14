using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class ActionTemplateChildResource : CompositeActionTemplateChildResource
    {
        public ActionTemplateChildResource()
        {
            ChildType = CompositeActionTemplateChildType.ActionTemplate;
        }
        [WriteableOnCreate]
        public string ActionTemplateId { get; set; }
        public int Version { get; set; }
    }
}