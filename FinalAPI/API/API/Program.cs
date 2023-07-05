using API.Authorization.Interfaces;
using API.Authorization.Services;
using API.Models;
using API.Models.DTO;
using API.Repositories.Appointments;
using API.Repositories.Doctors;
using API.Repositories.Feedbacks;
using API.Repositories.Patients;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BigBang2Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));


builder.Services.AddScoped<DoctorDTO>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenGenerate, TokenService>();
builder.Services.AddScoped<IUser, UserRepo>();
builder.Services.AddScoped<DoctorDTO>();

builder.Services.AddScoped<IAppointment,AppointmentService>();
builder.Services.AddScoped<IFeedback, FeedbackService>();
builder.Services.AddScoped<IDoctor, DoctorService>();
builder.Services.AddScoped<IPatients, Patients>();

/*builder.Services.AddScoped<IDoctor, DoctorService>();
*/
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey"])),
           ValidateIssuer = false,
           ValidateAudience = false
       };
   });

builder.Services.AddSwaggerGen(c => {
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}

                     }
                 });
});





/*builder.Services.AddCors(op =>
{
    op.AddPolicy("MyHotelPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();


    });
});*/

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AngularCORS", options =>
    {
        options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AngularCORS");
app.MapControllers();

app.Run();
