using LogicLayer.Interfaces;
using LogicLayer.Models;

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
    public static void Init()
    {
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
