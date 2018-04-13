using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class CompositeActionTemplateChildResource
    {
        IDictionary<string, PropertyValueResource> properties = new Dictionary<string, PropertyValueResource>(StringComparer.OrdinalIgnoreCase);

        public string Id { get; set; }
        /// <summary>
        /// The snapshot name of the ActionTemplate
        /// </summary>
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