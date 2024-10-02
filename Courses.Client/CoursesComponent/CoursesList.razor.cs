namespace Courses.Client;

public partial class CoursesList
{
    private List<CourseDTO>? CourseList = new List<CourseDTO>();
    private bool _isLoading = true;
    private bool _isEmpty = false;
    const string Url = "api/Courses";
    public Modal? modalComponent;
    private Guid currentModalId;
    private CourseDTO? facultyToDelete;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            await LoadFaculty();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex}");
        }
        finally
        {
            _isLoading = false;
        }
        await base.OnInitializedAsync();
    }
    private async Task LoadFaculty()
    {
        try
        {

            HttpResponseMessage responseMessage = await httpClient.GetAsync($"{Url}");
            responseMessage.EnsureSuccessStatusCode();

            CourseList = await responseMessage.Content.ReadFromJsonAsync<List<CourseDTO>>();
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
        }
        _isEmpty = CourseList == null || !CourseList.Any();
    }
    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender)
        {
            currentModalId = Guid.NewGuid();
        }
        base.OnAfterRender(firstRender);
    }
    private async void ShowModal(CourseDTO facultyDTO)
    {
        facultyToDelete = facultyDTO;


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

    private async Task DoCreateOrEdit(SaveResult saveResult)
    {
        if (saveResult is null) throw new ArgumentNullException(nameof(SaveResult));

        if (httpClient is not null)
        {
            HttpResponseMessage response;
            if (saveResult.IsCreate)
            {
                response = await httpClient.PostAsJsonAsync(Url, saveResult.course);
            }
            else
            {
                response = await httpClient.PutAsJsonAsync(Url, saveResult.course);
            }
            response.EnsureSuccessStatusCode();

            await LoadFaculty();

            StateHasChanged();
        }
    }
    private async Task DeleteStudent()
    {
        string? jsonContent = JsonSerializer.Serialize(facultyToDelete);

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
            response.EnsureSuccessStatusCode();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        await LoadFaculty();
    }
}