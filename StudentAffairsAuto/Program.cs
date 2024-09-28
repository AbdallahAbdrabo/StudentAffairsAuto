using Microsoft.EntityFrameworkCore;
using Shared.Application;
using Shared.Application.UnitOfWork;
using StudentAffairsAuto.Client.Pages;
using StudentAffairsAuto.Components;
using Students.Application.Repository1;
using Students.Application.UnitOfWork1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>();

builder.Services.AddScoped<IStudentsRepository, StudentsRepository>();

builder.Services.AddScoped<IStudentsUnitOfWork, StudentsUnitOfWork>();

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
