namespace Octopus.Client.Model
{
    public class CompositeActionTemplateItemResource : Resource
    {
        public int Version { get; set; }
        public string CommunityActionTemplateId { get; set; }
        public string ActionTemplateId { get; set; }
        public string CompositeActionTemplateId { get; set; }
    }
}