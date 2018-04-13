using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class ActionTemplateResource : ActionTemplateBaseResource
    {
        public ActionTemplateResource()
        {
            ActionTemplateType = ActionTemplateType.ActionTemplate;
        }
        [Required(ErrorMessage = "Please provide an action type.")]
        [WriteableOnCreate]
        public string ActionType { get; set; }
        public string CommunityActionTemplateId { get; set; }
    }
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