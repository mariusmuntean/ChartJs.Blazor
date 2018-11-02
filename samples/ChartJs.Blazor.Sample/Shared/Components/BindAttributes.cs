using Microsoft.AspNetCore.Blazor.Components;

namespace ChartJs.Blazor.Sample.Shared.Components
{
    [BindInputElement(null, null, "value", "onchange")]
    [BindInputElement("checkbox", null, "checked", "onchange")]
    [BindInputElement("text", null, "value", "onchange")]
    [BindElement("select", null, "value", "onchange")]
    [BindElement("textarea", null, "value", "onchange")]
    [BindElement("textarea", null, "value", "oninput")]
    [BindElement("textarea", "value", "value", "oninput")]
    public static class BindAttributes
    {
    }
}
