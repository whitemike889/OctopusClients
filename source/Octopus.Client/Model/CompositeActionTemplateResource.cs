using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Octopus.Client.Extensibility;
using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public class CompositeActionTemplateResource : Resource, INamedResource
    {
        readonly IList<ActionTemplateParameterResource> parameters = new List<ActionTemplateParameterResource>();
        readonly IList<CompositeActionTemplateItemResource> templateItems = new List<CompositeActionTemplateItemResource>();

        [Required(ErrorMessage = "Please provide a name for the template.")]
        [Writeable]
        public string Name { get; set; }

        [Writeable]
        public string Description { get; set; }

        public int Version { get; set; }

        [Writeable]
        public IList<CompositeActionTemplateItemResource> TemplateItems => templateItems;

        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public IList<ActionTemplateParameterResource> Parameters => parameters;

    }
}