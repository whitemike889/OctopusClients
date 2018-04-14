using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Octopus.Client.Extensibility;
using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class CompositeActionTemplateChildResource : Resource, INamedResource
    {
        IDictionary<string, PropertyValueResource> properties = new Dictionary<string, PropertyValueResource>(StringComparer.OrdinalIgnoreCase);

        public string Name { get; set; }

        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public IDictionary<string, PropertyValueResource> Properties => properties;

        [WriteableOnCreate]
        public CompositeActionTemplateChildType ChildType { get; set; }
        [Writeable]
        public string RunConditionParameterName { get; set; }
        [Writeable]
        public RunConditionOptions RunConditionOption { get; set; }

    }
}