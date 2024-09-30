
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Students.Client.Dto;
using System.Net.Http;

namespace StudentsClient;

public partial class CreateOrAddStudent 
{

    [Parameter] public StudentDTO? studentDTO { get; set; }
    [Parameter] public int? StudentId { get; set; }
    const string Url = "api/Students";
    bool isCreate = false;
   
    protected override async Task OnInitializedAsync()
    {
        if (studentDTO is  null )
        {
            studentDTO = new StudentDTO();
            isCreate = true;
        }
        await base.OnInitializedAsync();
    }
    private async Task HandleValidSubmit()
    {
        if (studentDTO is null) throw new ArgumentNullException(nameof(studentDTO));

        if (httpClient is not null)
        {
            HttpResponseMessage response;
            if (isCreate)
            {
                response = await httpClient.PostAsJsonAsync(Url, studentDTO);
            }
            else
            {

                response = await httpClient.PutAsJsonAsync(Url, studentDTO);
            }
            response.EnsureSuccessStatusCode();
            //navigation.NavigateTo($"/student");
            StateHasChanged();
        }
    }
    
}
