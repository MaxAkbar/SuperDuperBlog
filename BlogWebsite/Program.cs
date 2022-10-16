using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddDbContext<BlogContext>(options =>


    options.UseSqlServer(builder.Configuration.GetConnectionString("BlogContext") ?? throw new InvalidOperationException("Connection string 'BlogContext' not found.")));

//builder.WebHost.UseKestrel()
//            .UseContentRoot(Directory.GetCurrentDirectory())
//            .UseIISIntegration();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

app.MapRazorPages();

//app.Run(async (context) =>
//{
//    if (context.Request.Path.ToString().EndsWith("Foo", StringComparison.CurrentCultureIgnoreCase))
//    {
//        await context.Response.WriteAsync("Foo");
//    }
//    else
//    {
//        await context.Response.WriteAsync("Everything else");
//    }
//});


app.Run();
