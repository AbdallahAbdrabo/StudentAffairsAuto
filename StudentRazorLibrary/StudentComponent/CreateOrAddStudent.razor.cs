
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Students.Client.Dto;
using System.Net.Http;

namespace StudentsClient;

public partial class CreateOrAddStudent 
{
    [Parameter] public EventCallback<SaveResult> OnSave { get; set; }
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
        var saveResult = new SaveResult()
        {
            IsCreate = isCreate,
            Student = studentDTO,

        };
        await OnSave.InvokeAsync(saveResult);
        //  studentDTO = new StudentDTO();
       
    }
    
}
