



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddControllers();
builder.Services.AddLocalization();
builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();
builder.Services.AddScoped<IFaculiesRepository, FaculiesRepository>();
builder.Services.AddScoped<ICoursesRepository, CoursesRepository>();

builder.Services.AddScoped<IStudentsUnitOfWork, StudentsUnitOfWork>();
builder.Services.AddScoped<IFacultiesUnitOfWork, FacultiesUnitOfWork>();
builder.Services.AddScoped<ICoursesUnitOfWork, CoursesUnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration.GetSection("BaseAddress").Value!)
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();  


app.MapControllers();
app.UseCors("AllowAll");
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(StudentAffairsAuto.Client._Imports).Assembly);




app.Run();
