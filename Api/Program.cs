using AuthenticationLayer;
using LogicLayer.Core;
using MockDataLayer.Services;

var builder = WebApplication.CreateBuilder(args);

Core.Init(new UserMockService(), new StockBalanceMockService(), new CompanyMockService(), new CompanyHistoryMockService(), new BankAccountMockService(), new TransientAuthenticationService());

// Add services to the container.
builder.Services.AddControllers();  // Add controllers service
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

app.UseAuthorization();  // Add this if you need authorization in your app

app.MapControllers();  // Map controller routes

app.Run();