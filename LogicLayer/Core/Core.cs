using LogicLayer.Interfaces.DataServices;

namespace LogicLayer.Core;

/// <summary>
/// Provides core functionalities with initialization and state checking.
/// </summary>
public static partial class Core
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static bool _initialized;

    /// <summary>
    /// Sets the internal state to indicate that initialization is complete.
    /// </summary>
    /// <remarks>
    /// This method sets the internal state to indicate that initialization is complete.
    /// </remarks>
    public static void Init(IUserService userService, IStockBalanceService stockBalanceService, ICompanyService companyService, ICompanyHistoryService companyHistoryService, IBankAccountService bankAccountService, ITransientAuthenticationService transientAuthenticationService)
    {
        _bankAccountService = bankAccountService;
        _userService = userService;
        _transientAuthenticationService = transientAuthenticationService;
        _initialized = true;
    }
    
    // Private methods

    /// <summary>
    /// Checks if the core has been initialized.
    /// </summary>
    /// <exception cref="Exception">
    /// Throws an exception if the core has not been initialized.
    /// </exception>
    private static void CheckInit()
    {
        if (!_initialized) throw new Exception("Core not initialized");
    }
}
