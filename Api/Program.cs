using AuthenticationLayer;
using LogicLayer.Core;
using LogicLayer.Cryptography;
using LogicLayer.Models.DataModels;
using MockDataLayer;
using MockDataLayer.Services;

var builder = WebApplication.CreateBuilder(args);

Core.Init(new UserMockService(), new StockBalanceMockService(), new CompanyMockService(), new CompanyHistoryMockService(), new BankAccountMockService(), new TransientAuthenticationService());

MockData.Users =
[
    new User(1, "duffie13", "duffie13", PasswordProtector.Protect("password")),
    new User(2, "receiver", "receiver", PasswordProtector.Protect("password"))
];

MockData.BankAccounts =
[
    new BankAccount(1, "test1", 1, 100),
    new BankAccount(1, "test2", 2, 200),
    new BankAccount(1, "test3", 3, 300),
    new BankAccount(1, "test4", 4, 400),
    new BankAccount(2, "test5", 5, 500)
];

MockData.Companies =
[
    new Company(1, 1, "AMZN", 5000),
    new Company(2, 1, "CRIM", 1000),
    new Company(3, 2, "KMRT", 500)
];

MockData.CompanyHistories =
[
    new CompanyHistory(1, new DateTime(2024, 1, 1), 1000000, 200),
    new CompanyHistory(1, new DateTime(2024, 2, 1), 1000000, 200),
    new CompanyHistory(1, new DateTime(2024, 3, 1), 1000000, 200),
    new CompanyHistory(1, new DateTime(2024, 4, 1), 1000000, 200),
    new CompanyHistory(1, new DateTime(2024, 5, 1), 1000000, 200),
    new CompanyHistory(2, new DateTime(2024, 1, 1), 300000, 300),
    new CompanyHistory(2, new DateTime(2024, 2, 1), 300000, 300),
    new CompanyHistory(2, new DateTime(2024, 3, 1), 300000, 300),
    new CompanyHistory(2, new DateTime(2024, 4, 1), 300000, 300),
    new CompanyHistory(2, new DateTime(2024, 5, 1), 300000, 300),
    new CompanyHistory(3, new DateTime(2024, 1, 1), 100000, 200),
    new CompanyHistory(3, new DateTime(2024, 2, 1), 100000, 200),
    new CompanyHistory(3, new DateTime(2024, 3, 1), 100000, 200),
    new CompanyHistory(3, new DateTime(2024, 4, 1), 100000, 200),
    new CompanyHistory(3, new DateTime(2024, 5, 1), 100000, 200)
];

MockData.StockBalances =
[
    new StockBalance(1, 1, 20),
    new StockBalance(2, 1, 17),
    new StockBalance(3, 1, 13),
    new StockBalance(4, 1, 6),
    new StockBalance(5, 1, 1),
    new StockBalance(1, 2, 8),
    new StockBalance(2, 2, 6),
    new StockBalance(3, 2, 4),
    new StockBalance(4, 2, 3),
    new StockBalance(5, 2, 1)
];

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