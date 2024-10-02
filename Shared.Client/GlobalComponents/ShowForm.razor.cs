namespace Shared.Client;

public partial class ShowForm
{
    [Parameter] public RenderFragment? ChildContent { get; set; }
    [Parameter] public string? ButtonDescription { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JSRuntime.InvokeVoidAsync("modalFunctions.addEventListeners");
        }
    }
}