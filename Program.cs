using Newtonsoft.Json;
using ASDP.FinalProject;
using ASDP.FinalProject.Filter;
using Serilog;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using ASDP.FinalProject.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var seq_addr = builder.Configuration.GetValue<string>("Seq:Api");
var seq_token = builder.Configuration.GetValue<string>("Seq:Token");

// Add services to the container.
builder.Services.AddSerilog(x=>
    x.WriteTo.Console()
    .WriteTo.Seq(seq_addr, apiKey: seq_token));

builder.Services.AddCors(opt => opt.AddPolicy("allow_all", pol => pol.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin())
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

var syncfusionLicense = builder.Configuration.GetValue<string>("SyncfusionTrialKey");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncfusionLicense);


builder.Services.Inject(builder.Configuration);

var app = builder.Build();
app.UseCors("allow_all");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AdspContext>();
    db.Database.Migrate();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
