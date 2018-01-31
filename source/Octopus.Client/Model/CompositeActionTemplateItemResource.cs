using System.Collections.Generic;
using Newtonsoft.Json;

namespace Octopus.Client.Model
{
    public class CompositeActionTemplateItemResource : Resource
    {
        readonly IList<ActionTemplateParametersMappingResource> parameterMappings = new List<ActionTemplateParametersMappingResource>();
        public int Version { get; set; }
        public string CommunityActionTemplateId { get; set; }
        public string ActionTemplateId { get; set; }
        public string CompositeActionTemplateId { get; set; }
        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public IList<ActionTemplateParametersMappingResource> ParameterMappings => parameterMappings;
    }
}