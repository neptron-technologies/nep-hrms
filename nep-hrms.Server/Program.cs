using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using nep_hrms.DAL.Interfaces;
using nep_hrms.DAL.Repositories;
using nep_hrms.Domain.Interfaces;
using nep_hrms.Domain.Services;
using nep_hrms.Domain.Mappers;
using nep_hrms.Server.Authenticate;
using nep_hrms.Server.nep_hrms.DAL;
using NETCore.MailKit.Core;
using nep_hrms.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(EmpMapper));
builder.Services.AddAutoMapper(typeof(AttendanceMap));
builder.Services.AddAutoMapper(typeof(UserMapper));
builder.Services.AddAutoMapper(typeof(ProjectMapper));  //added on tues
builder.Services.AddAutoMapper(typeof(RecruitmentMapper)); //added on tues
builder.Services.AddAutoMapper(typeof(UserRoleMapper));
builder.Services.AddAutoMapper(typeof(PermissionMapper));
builder.Services.AddAutoMapper(typeof(RolePermissionMapper));

//builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings")); //added on friday


var configuration = builder.Configuration;

builder.Services.AddDbContext<HrmsDBContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("HRMSAppDBConnection"));
});

var jwtSettings = configuration.GetSection("JwtSettings");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"] ?? throw new ArgumentNullException("JWT Key is missing in appsettings.json"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidateAudience = true,
        ValidAudience = jwtSettings["Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddAuthorization();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IAttendanceRepo, AttendanceRepo>();
builder.Services.AddScoped<IProjectRepo, ProjectRepo>();  //added by suraj
builder.Services.AddScoped<IRecruitmentRepo, RecruitmentRepo>(); // same
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
builder.Services.AddScoped<IAttendanceService, AttendanceService>();
builder.Services.AddScoped<IProjectService, ProjectService>();   //added by suraj
builder.Services.AddScoped<IRecruitmentService, RecruitmentService>(); // same
//builder.Services.AddScoped<EmailService>();
//builder.Services.AddScoped<nep_hrms.Domain.Services.EmailService>();
builder.Services.AddScoped<Auth>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors( x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());  //added

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();