using AuthenticationLayer;
using LogicLayer.Core;
using LogicLayer.Cryptography;
using LogicLayer.Models.DataModels;
using MockDataLayer;
using MockDataLayer.Services;

var builder = WebApplication.CreateBuilder(args);

Core.Init(new UserMockService(), new StockBalanceMockService(), new CompanyMockService(), new CompanyHistoryMockService(), new BankAccountMockService(), new TransientAuthenticationService(), new StockOrderMockService(), new ShopItemMockService());

MockData.Users =
[
    new User(1, "duffie13", "duffie13", PasswordProtector.Protect("password")),
    new User(2, "receiver", "receiver", PasswordProtector.Protect("password"))
];

MockData.BankAccounts =
[
    new BankAccount(1, "test1", 1, 10000 * 100),
    new BankAccount(1, "test2", 2, 5000 * 100),
    new BankAccount(1, "test3", 3, 3000 * 100),
    new BankAccount(1, "test4", 4, 1000 * 100),
    new BankAccount(2, "test5", 5, 1000 * 100)
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
    
    new StockBalance(1, 2, 8),
    new StockBalance(2, 2, 6),
];

MockData.StockOrders =
[
    new StockOrder(2, 1, 17, false, 100, 5),
    new StockOrder(2, 1, 1, false, 90, 5)
];

MockData.ShopItems =
[
    new ShopItem(1, "Stone", 200, "data:image/webp;base64,UklGRgIEAABXRUJQVlA4WAoAAAAQAAAARwAARwAAQUxQSOEAAAABcFZrWxTNGoACLpCERiTYEmgij0GABlph9kFe3P0TEQratmFcCrsUTjtW7jmjgbD8nkbWeheIb7M0mH8E41ka1IU5mkZpw2yJx41WVR/WV0objmUeEdFYOobCUlGgZV/WMery0wiosrddjM6iGoH5ByCeYcoewVFM2SPYElP2Q+AbwTyg0VFlj6W2AIUlByJCa9lgNVJrQTBjIc2goC4NR4934517RGiFn8NKCzKKvTCePb6eTeEO5Ebh7lJl+Dju5PHc7eP5I8bz14znzxrF3zeeP3SafzE3anAMP62znAAAVlA4IPoCAAAQEACdASpIAEgAPpE8mEiloyIhKlIPCLASCWgAzM4BWL6BU/Hi+IqOd2LTwtvD5gMeR3nT/MsGhp5XEpA/IqlkYnZblfKzB2gXmjwECa67i/+oR7dIrx4Yphg3jmoSbRYEN2UuFQX4nKLdvD7681zwKMuI0hdUbe1VzIpA+mGCkY8baIE/iOU8IAD+/FzZP9aHaIBuycS9mAvzJJyQcq51CbgIJ8baUHQnZT+ind0opT+jhbGS8Uq3punG3+//KiIAkEkpesdPo2zjvn/jvdh5HuNJtftJp0tnA+eBzHQPl5tI9TLAEEOj9hQ0uecOULvdxc+L4ewviQrxx1M2POfl6FbvEPJQvbgbZoPKsQiUqlQJpFMJJfT2IvKezk3UB60DZZlx7EDw8bHa0RY6+qEP81z5i+/uB9p6OJTgP7UHysDso4uL9OTOVyr5bXk1Gl3HC43kg6z/FkYVScjDewPjG2Pby7oMY666lOsNyraXuxaULnhuPYuQkSEya89Lyan0a9953YLra+JWJR5kN7QwQkrKcHPfPbtiQsAitlQEKy67yl0Flk6SrTt06OLnDTxx1+WHoilIoBNVzke4GLXl/UyBm5C8ln1gE3/2AQec6k95Mxl9yP8yrpUXw5l0CvhNzhfXwYgVPBMlWTz/P7PdnxTgYmecwCfrFzt//FCIaA0P/zAhSs5tWNLlxTcXDVJGH2HXXX9UFnjOwfeQZLYP2zs4EARFhTiVavHtdAEriu8qoHxf+Ylf9wYKW8IwbNagSGDHXeQGi8HV0/+uwHYJqLxIEHCS3pERghcTTg/uA6e8atdSGDDalfMz6eWZKBSMdZoUG4pDySOzWHV+j2TUFa9eO8zBHMoBRePKsb1DJ/UyVtaf1EhkBv52hNXyIPLigrk5puZbYAfctVi2WRtEW+aK7iZ7LCI2/5WbCjnDLYShYqiEQ2YCB+hQP//oJI5eTo/eqwylsF73o6AZbyd5ATyTcMnlORD4u34tdhcpsZW/fmWWgAAAAAA=")
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