namespace Octopus.Client.Model
{
    public enum ActionTemplateType
    {
        ActionTemplate,
        CompositeActionTemplate
    }

    public enum CompositeActionTemplateChildType
    {
        Builtin,
        ActionTemplate,
        CompositeActionTemplate
    }

    public enum RunConditionOptions
    {
        None,
        BoundToParameter
    }
}
