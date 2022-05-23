var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureAppConfiguration(
                c => {

                    c.AddSystemsManager(source =>{
                        source.Path = "/testapp";
                        source.ReloadAfter =
                            TimeSpan.FromMinutes(10);
                    });
                }
            );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
