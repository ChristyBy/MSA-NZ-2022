var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddSwaggerDocument(options =>
{
    options.DocumentName = "My Amazing API";
    options.Version = "V1";

}
);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3();
}
builder.Services.AddHttpClient("reddit", configureClient: client =>
{
    client.BaseAddress = new Uri("https://www.reddit.com/dev/api");
});

builder.Services.AddHttpClient("reddit", configureClient: client =>
{
    client.BaseAddress = new Uri("https://www.visualcrossing.com/weather-api");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
