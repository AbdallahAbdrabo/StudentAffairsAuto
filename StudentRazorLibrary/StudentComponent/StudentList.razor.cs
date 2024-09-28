using Microsoft.AspNetCore.Components;
using Students.Client.Dto;
using System.Net.Http;
using System.Net.Http.Headers;

namespace StudentsClinet;
public partial class StudentList
{
    public List<StudentDTO>? Students = new();
    private bool _isLoading = true;
    private bool _isEmpty = false;
    const string Url = "api/Student";
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
            
            HttpResponseMessage studentJson = await httpClient.GetAsync($"api/Students");
            studentJson.EnsureSuccessStatusCode();
           
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Request error: {ex.Message}");
        }
        
        _isEmpty = Students == null || !Students.Any();
    }

    private void DeleteStudent(StudentDTO item)
    {
        ArgumentNullException.ThrowIfNull(item);

    }


    //private async void ShowModal()
    //{


    //    if (modalComponent is not null)
    //    {
    //        await modalComponent.ShowModal();
    //    }
    //    else
    //    {
    //        Console.WriteLine("modalComponent is null.");
    //    }
    //}

    private void GoToAddPage() { navigation.NavigateTo($"student/Create"); }
    private void GoToEditPage(int studentId) { navigation.NavigateTo($"Student/Edit/{studentId}"); }
}
