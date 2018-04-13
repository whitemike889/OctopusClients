using System;
using System.Collections.Generic;
using Octopus.Client.Model;

namespace Octopus.Client.Serialization
{
    public class ActionTemplateConverter : InheritedClassConverter<ActionTemplateBaseResource, ActionTemplateType>
    {
        static readonly IDictionary<ActionTemplateType, Type> ActionTemplateTypeMappings =
            new Dictionary<ActionTemplateType, Type>
            {
                {ActionTemplateType.ActionTemplate, typeof(ActionTemplateResource)},
                {ActionTemplateType.CompositeActionTemplate, typeof(CompositeActionTemplateResource)},
            };

        protected override Type DefaultType => typeof(ActionTemplateResource);
        protected override IDictionary<ActionTemplateType, Type> DerivedTypeMappings => ActionTemplateTypeMappings;
        protected override string TypeDesignatingPropertyName => nameof(ActionTemplateBaseResource.ActionTemplateType);

    }
}