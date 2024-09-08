using LogicLayer.Interfaces;
using LogicLayer.Models;

namespace LogicLayer.Core;

public static partial class Core
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    private static bool _initialized;
    

    public static void Init()
    {
        _initialized = true;
    }
    
    //Private methods
    private static void CheckInit()
    {
        if (!_initialized) throw new Exception("Core not initialized");
    }
    
}