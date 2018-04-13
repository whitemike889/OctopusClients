using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Octopus.Client.Extensibility;
using Octopus.Client.Extensibility.Attributes;

namespace Octopus.Client.Model
{
    public abstract class ActionTemplateBaseResource : Resource, INamedResource
    {
        IDictionary<string, PropertyValueResource> properties;
        IList<ActionTemplateParameterResource> parameters;

        public ActionTemplateBaseResource()
        {
            properties = new Dictionary<string, PropertyValueResource>(StringComparer.OrdinalIgnoreCase);
            parameters = new List<ActionTemplateParameterResource>();
        }
        [Required(ErrorMessage = "Please provide a name for the template.")]
        [Writeable]
        public string Name { get; set; }

        [Writeable]
        public string Description { get; set; }
        public int Version { get; set; }

        [WriteableOnCreate]
        public ActionTemplateType ActionTemplateType { get; set; }

        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public IDictionary<string, PropertyValueResource> Properties
        {
            get { return properties; }
            set { properties = value; }
        }

        [JsonProperty(ObjectCreationHandling = ObjectCreationHandling.Reuse)]
        public IList<ActionTemplateParameterResource> Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }
    }
}