using Microsoft.EntityFrameworkCore;
using NAFSupport.Server.DataAccessLayer;
using NAFSupport.Server.Services;

var builder = WebApplication.CreateBuilder(args);

#region CORS setting for API

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins",
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                              .AllowAnyHeader()
                                              .AllowAnyMethod();

                          //policy.WithOrigins("https://noorecommerceshop.netlify.app" , "http://noornashad-001-site3.etempurl.com")
                          //             .AllowAnyHeader()
                          //             .AllowAnyMethod();
                      });
});
#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<NAFSupportDBContext>(option =>
   option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("_myAllowSpecificOrigins");

app.MapControllers();

app.Run();
