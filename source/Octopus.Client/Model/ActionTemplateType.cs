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
        ActionTemplate
    }

    public enum RunConditionOptions
    {
        None,
        BoundToParameter
    }
}
