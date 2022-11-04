using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Interfaces;
using WebApplication1.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IThanhPhoRepository, ThanhPhoRepository>();
builder.Services.AddScoped<IQuanHuyenRepository, QuanHuyenRepository>();
builder.Services.AddDbContext<TinhThanhContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Configdb"));
});
builder.Services.AddCors(options => options.AddPolicy("Mycors", build => {
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors("Mycors");
app.Run();
