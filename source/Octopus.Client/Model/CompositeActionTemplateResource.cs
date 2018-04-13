using System.Collections.Generic;
using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class CompositeActionTemplateResource : ActionTemplateBaseResource
    {
        [Writeable]
        public IList<CompositeActionTemplateChildResource> Children { get; set; }

        public CompositeActionTemplateResource()
        {
            ActionTemplateType = ActionTemplateType.CompositeActionTemplate;
            Children = new List<CompositeActionTemplateChildResource>();
        }
    }
}