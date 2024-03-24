using Meditaps.Infrastructure;
using Meditaps.Services;
using Meditaps.Services.Business;
using Meditaps.Services.Mutation;
using Meditaps.Services.Queries;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IUserQueries,UserQueries>();
builder.Services.AddScoped<IUserMutation, UserMutation>();
builder.Services.AddScoped<IWordMutation,WordMutation>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<UserDbContext>(opt => {
    opt.UseSqlite(builder.Configuration.GetConnectionString("DbConnectionString"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

