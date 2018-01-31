using System.Collections.Generic;
using Newtonsoft.Json;
using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class CompositeActionTemplateItemResource : Resource
    {
        public int Version { get; set; }
        [WriteableOnCreate]
        public string CommunityActionTemplateId { get; set; }
        [WriteableOnCreate]
        public string ActionTemplateId { get; set; }
        [WriteableOnCreate]
        public string CompositeActionTemplateId { get; set; }

        [Writeable]
        public IList<ActionTemplateParametersMappingResource> ParameterMappings { get; set; }

        public CompositeActionTemplateItemResource()
        {
            ParameterMappings = new List<ActionTemplateParametersMappingResource>();
        }
    }
}