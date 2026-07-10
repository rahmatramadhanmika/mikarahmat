using Microsoft.EntityFrameworkCore;
using myapi.Data;
using myapi.Repositories;
using myapi.Repositories.Interfaces;
using myapi.Services;
using myapi.Services.Interfaces;
using myapi.Mappings;
using myapi.Exceptions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddAutoMapper(typeof(AboutProfile));
builder.Services.AddScoped<IAboutRepository, AboutRepository>();

builder.Services.AddScoped<IEducationService, EducationService>();
builder.Services.AddAutoMapper(typeof(EducationProfile));
builder.Services.AddScoped<IEducationRepository, EducationRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
    {
        policy.RequireClaim("IsAdmin", "True");
    });
});

builder.Services.AddScoped<IJwtService, JwtService>();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("MyDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<GlobalExceptionMidleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
