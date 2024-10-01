using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Shared;
using Students.Client.Dto;

namespace StudentsClinet;
public partial class StudentList
{
    public List<StudentDTO>? Students = new();
    private bool _isLoading = true;
    private bool _isEmpty = false;
    const string Url = "api/Students";
    [Inject] private IJSRuntime? JSrun { get; set; }
    public Modal? modalComponent;
    private Guid currentModalId;
    private StudentDTO? studentToDelete;
    private String? message = "areyou";
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
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            currentModalId = Guid.NewGuid();
        }
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
    private async Task DeleteStudent()
    {
        string? jsonContent = JsonSerializer.Serialize(studentToDelete);

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
           
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");

        }
        await GetStudentsAsync();
       
    }
    private async void ShowModal(StudentDTO student)
    {
        studentToDelete = student;
        

        if (modalComponent is not null)
        {
            await modalComponent.ShowModal();
        }
        else
        {
            Console.WriteLine("modalComponent is null.");
        }
        currentModalId = Guid.NewGuid();
    }
    private async Task DoCreateOrEdit(SaveResult saveResult) {
        if (saveResult is null) throw new ArgumentNullException(nameof(SaveResult));

        if (httpClient is not null)
        {
            HttpResponseMessage response;
            if (saveResult.IsCreate)
            {
                response = await httpClient.PostAsJsonAsync(Url, saveResult.Student);
            }
            else
            {

                response = await httpClient.PutAsJsonAsync(Url, saveResult.Student);
            }
            response.EnsureSuccessStatusCode();

            await GetStudentsAsync();

            StateHasChanged();
        }
    }
    private void GoToEditPage(int studentId) { navigation.NavigateTo($"Student/Edit/{studentId}"); }
}
