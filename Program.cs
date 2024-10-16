using Newtonsoft.Json;
using ASDP.FinalProject;
using ASDP.FinalProject.Filter;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSerilog(x=>
    x.WriteTo.Console()
    );

builder.Services.AddControllers(x =>
{
    x.Filters.Add<AdspExceptionFilter>();
}).AddNewtonsoftJson(options =>
{
    // Configure settings to allow unescaped newline characters (if needed)
    options.SerializerSettings.StringEscapeHandling = Newtonsoft.Json.StringEscapeHandling.Default;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "ASDP.FinalProject.xml"));
});

builder.Services.Inject(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
