using Azure.AI.OpenAI;
using Azure;
using Microsoft.Extensions.Options;
using static OpenAIWebApp.Controllers.SqlChatterController;
using static OpenAIWebApp.Controllers.LawChatterController;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<AzureOpenAISettings>(builder.Configuration.GetSection("AzureOpenAI"));
builder.Services.AddSingleton<OpenAIClient>(sp =>
{
    var settings = sp.GetRequiredService<IOptions<AzureOpenAISettings>>().Value;
    return new OpenAIClient(new Uri(settings.Endpoint), new AzureKeyCredential(settings.Key));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SqlChatter}/{action=Index}/{id?}");

app.Run();
