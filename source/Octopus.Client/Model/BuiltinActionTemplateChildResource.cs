using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class BuiltinActionTemplateChildResource : CompositeActionTemplateChildResource
    {
        public BuiltinActionTemplateChildResource()
        {
            ChildType = CompositeActionTemplateChildType.Builtin;
        }
        [WriteableOnCreate]
        public string ActionType { get; set; }
    }
}