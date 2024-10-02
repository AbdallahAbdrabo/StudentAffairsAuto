using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace StudentAffairsServer;

public partial class CultureSelector
{
    [Inject]
    public IJSRuntime? JSRuntime { get; set; }
    CultureInfo[] cultures = new[]
    {
    new CultureInfo("en-US"),
    new CultureInfo("ar-EG")
};
    CultureInfo Culture
    {
        get => CultureInfo.CurrentCulture;
        set
        {
            if (CultureInfo.CurrentCulture != value)
            {
                if (CultureInfo.CurrentCulture != value)
                {
                    CultureInfo.CurrentCulture = value;
                    ChangeCultureAsync(value).ContinueWith(_ => InvokeAsync(StateHasChanged));
                }
                //CultureInfo.CurrentCulture = value;
                //ChangeCultureAsync(value).ConfigureAwait(false);
                //StateHasChanged();
                
            }
        }
    }
    private async Task ChangeCultureAsync(CultureInfo culture)
    {
        await JS.InvokeVoidAsync("blazorCulture.set", culture.Name);
        NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
        
    }
}