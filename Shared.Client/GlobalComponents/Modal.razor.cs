namespace Shared;

public partial class Modal
{
    [Parameter] public Guid Id { get; set; } 
    [Parameter] public string? ModalTitle { get; set; }
    [Parameter] public string? Message { get; set; }
    [Parameter] public EventCallback OnSave { get; set; }
    [Inject] private IJSRuntime? JSrun { get; set; }
    
    public async Task ShowModal()
    {

        if (JSrun != null)
        {
            await JSrun.InvokeVoidAsync("ModalFunction", Id);
        }
        else
        {
            Console.WriteLine("JSRuntime is null.");
        }
    }
    private async void SaveChanges()
    {
        if (JSrun != null)
        {
            await JSrun.InvokeVoidAsync("ModalFunctionClose", Id);
            await OnSave.InvokeAsync();
        }
        else
        {
            Console.WriteLine("JSRuntime is null.");
        }
    }
}