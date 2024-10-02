namespace  faculties.Client;
public partial class CreateorEditFaculty
{
    [Parameter] public EventCallback<SaveResult> OnSave { get; set; }
    private FacultyDTO? faculty = new ();
    const string Url = "api/Students";
    bool isCreate = false;

    protected override async Task OnInitializedAsync()
    {
        if (faculty is null)
        {
            faculty = new FacultyDTO();
            isCreate = true;
        }
        await base.OnInitializedAsync();
    }
    private async Task HandleValidSubmit()
    {
        var saveResult = new SaveResult()
        {
            IsCreate = isCreate,
            faculty = faculty,
        };
        await OnSave.InvokeAsync(saveResult);
    }
}