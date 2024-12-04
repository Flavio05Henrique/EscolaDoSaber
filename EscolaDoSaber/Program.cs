using EscolaDoSaber.Infra;
using EscolaDoSaber.Model.DTOs.Mapping;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SchoolContex>();
builder.Services.AddScoped<TeacherDAL>();
builder.Services.AddScoped<StudentDAL>();
builder.Services.AddScoped<CourseDAL>();

builder.Services.AddAutoMapper(typeof(DomainToDTOMapping));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
