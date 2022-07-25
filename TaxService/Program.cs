using tax_api.Services;
using tax_api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IOrderRepository>((container) => {
    var logger = container.GetRequiredService<ILogger<OrderRepository>>();
    return new OrderRepository(logger);
});

builder.Services.AddSingleton<ITaxService>((container) => {
    var logger = container.GetRequiredService<ILogger<TaxService>>();
    var repo = container.GetRequiredService<IOrderRepository>();
    return new TaxService(logger, repo);
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

app.MapControllers();

app.Run();
