
//using Microsoft.AspNetCore.Components;
//using Students.Application.Model;
//using Students.Application.UnitOfWork1;

namespace StudentsClient;

public partial class CreateOrAddStudent 
{
//    private Student? student = new Student();
//    [Inject] public IStudentsUnitOfWork? _studentsUnitOfWork { get; set; }
//    [Parameter] public int? StudentId { get; set; }
//    const string Url = "api/Student";
//    protected override async Task OnInitializedAsync()
//    {
//        if (StudentId is not null && _studentsUnitOfWork is not null)
//        {
           
//            try
//           {
//                student = await _studentsUnitOfWork.ReadById(StudentId ?? 0);
           
//            }
//            catch (HttpRequestException ex)
//            {
           
//                Console.WriteLine($"Request error: {ex.Message}");
//                student = new Student(); // Fallback to a new student if there's an error
//            }
//        }
//        await base.OnInitializedAsync();
//    }
//    private async Task HandleValidSubmit()
//    {
//        if (student is null ) throw new ArgumentNullException(nameof(student));

//        if (_studentsUnitOfWork is null ) throw new ArgumentNullException(nameof(_studentsUnitOfWork));

     
//        if (StudentId is null && _studentsUnitOfWork is not null)
//        {
//            student.StudentId = null;
//          await _studentsUnitOfWork.Create(student);
//        }
//        else
//        {
//            if (_studentsUnitOfWork is null) throw new ArgumentNullException(nameof(_studentsUnitOfWork));
//            await   _studentsUnitOfWork.Update(student);
//        }
//        //navigation.NavigateTo($"/student");
       


    //}
}
