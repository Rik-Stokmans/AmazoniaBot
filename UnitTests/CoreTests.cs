using AuthenticationLayer;
using LogicLayer.Core;
using LogicLayer.Models.DataModels;
using MockDataLayer;
using MockDataLayer.Services;

namespace UnitTests;

public class Tests
{
    
    /*
    [SetUp]
    public void Setup()
    {
        MockData.Users =
        [
            new User(1, "TestUser1", "TestMinecraftUuid1", "TestPassword1"),
            new User(2, "TestUser2", "TestMinecraftUuid2", "TestPassword2"),
            new User(3, "TestUser3", "TestMinecraftUuid3", "TestPassword3"),
            new User(4, "TestUser4", "TestMinecraftUuid4", "TestPassword4"),
            new User(5, "TestUser5", "TestMinecraftUuid5", "TestPassword5"),
            new User(100, "duffie13", "duffie13", "password")
        ];

        MockData.BankAccounts =
        [
            new BankAccount(1, "test1", 100),
            new BankAccount(2, "test2", 200),
            new BankAccount(3, "test3", 300),
            new BankAccount(4, "test4", 400),
            new BankAccount(5, "test5", 500)
        ];

        MockData.Companies =
        [
            new Company(1, "AMZN", 5000),
            new Company(2, "CRIM", 1000),
            new Company(3, "KMRT", 500)
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

        Core.Init(new UserMockService(), new StockBalanceMockService(), new CompanyMockService(), new CompanyHistoryMockService(), new BankAccountMockService(), new TransientAuthenticationService());
    }

    [Test]
    public void BankAccountCoreTest()
    {
        //register bank account
        if (Core.RegisterBankAccount(1))
        {
            Assert.Fail();
        }

        if (!Core.RegisterBankAccount(6))
        {
            Assert.Fail();
        }

        //change balance
        if (Core.ChangeBalance(7, 100))
        {
            Assert.Fail();
        }

        if (!Core.ChangeBalance(1, 100))
        {
            Assert.Fail();
        }

        if (!Core.ChangeBalance(1, -100))
        {
            Assert.Fail();
        }

        //transfer balance
        if (Core.TransferBalance(1, 1, 50))
        {
            Assert.Fail();
        }

        if (Core.TransferBalance(1, 6, -50))
        {
            Assert.Fail();
        }

        if (Core.TransferBalance(1, 7, 50))
        {
            Assert.Fail();
        }

        if (Core.TransferBalance(1, 6, 1000))
        {
            Assert.Fail();
        }

        if (!Core.TransferBalance(1, 6, 50))
        {
            Assert.Fail();
        }

        if (!Core.TransferBalance(6, 1, 50))
        {
            Assert.Fail();
        }

        //delete bank account
        if (Core.DeleteBankAccount(7))
        {
            Assert.Fail();
        }

        if (!Core.DeleteBankAccount(6))
        {
            Assert.Fail();
        }

        //get all bank accounts and printing them to the console
        Core.GetAllBankAccounts().ForEach(x => Console.WriteLine(x.DiscordId + ": " + x.Balance + "$"));

        //if all tests pass
        Assert.Pass();
    }


    [Test]
    public void AuthenticateUserTests()
    {
        if (!Core.RegisterAccount("duffie13", "password!", "testuuid", 100)) Assert.Fail();

        foreach (var keyValuePair in MockData.LoginCredentials)
        {
            Console.WriteLine(keyValuePair.Key);
        }

        var code = MockData.LoginCredentials.First().Key;


        if (!Core.VerifyAccount(code)) Assert.Fail();

        MockData.Users.ForEach(x => Console.WriteLine(x.DiscordId + ": " + x.Username + " " + x.MinecraftUuid + " " + x.Password));
    }
    */
}