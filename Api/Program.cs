using Api.Data;
using Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

const string SoftLineAllowSpecificOrigins = "_SoftLinePolicy";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors( opt =>
    opt.AddPolicy(name: "SoftLinePolicy", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    })
);

builder.Services.AddDbContext<SoftLineDbContext>(x => {
    var connStr = builder.Configuration.GetConnectionString("SoftLineConnection");
    x.UseSqlServer(connStr);
});

builder.Services.AddScoped<IAuthentic,AuthenticService>();
builder.Services.AddScoped<IProduct,ProductService>();
builder.Services.AddScoped<ICustomer,CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(SoftLineAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
