using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace StudentsClinet;
public partial class StudentList
{
    public List<StudentDTO>? Students = new();
    private bool _isLoading = true;
    private bool _isEmpty = false;
    const string Url = "api/Students";
    [Inject] private IJSRuntime? JSrun { get; set; }
    public Modal? modalComponent;
    protected override async Task OnInitializedAsync()
    {
        try
        {
            await GetStudentsAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            _isLoading = false;
        }
        await base.OnInitializedAsync();
    }

    private async Task GetStudentsAsync()
    {
        try
        {
            
            HttpResponseMessage responseMessage = await httpClient.GetAsync($"{Url}");
            responseMessage.EnsureSuccessStatusCode();

            Students = await responseMessage.Content.ReadFromJsonAsync<List<StudentDTO>>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
        }
        
        _isEmpty = Students == null || !Students.Any();
    }
    private async Task DeleteStudent(StudentDTO item)
    {
        string? jsonContent = JsonSerializer.Serialize(item);

        StringContent? content = new(jsonContent, Encoding.UTF8, "application/json");

        try
        {
           
            HttpRequestMessage? request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(Url, UriKind.Relative),
                Content = content 
            };

            
            HttpResponseMessage response = await httpClient.SendAsync(request);

          
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Resource deleted successfully with body content.");
            }
            else
            {
                Console.WriteLine($"Failed to delete the resource. Status code: {response.StatusCode}");
            }
            await GetStudentsAsync();
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");

        }
    }
    private async void ShowModal()
    {


        if (modalComponent is not null)
        {
            await modalComponent.ShowModal();
        }
        else
        {
            Console.WriteLine("modalComponent is null.");
        }
    }
  
    private void GoToEditPage(int studentId) { navigation.NavigateTo($"Student/Edit/{studentId}"); }
}
