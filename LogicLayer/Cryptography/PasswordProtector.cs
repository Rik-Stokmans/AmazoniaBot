namespace LogicLayer.Cryptography;

/// <summary>
/// Provides methods for protecting and verifying passwords using hashing.
/// </summary>
public static class PasswordProtector
{
    /// <summary>
    /// Hashes the specified password using BCrypt hashing algorithm.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <returns>
    /// A <see cref="string"/> containing the hashed password.
    /// </returns>
    public static string Protect(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    
    /// <summary>
    /// Verifies that the specified password matches the provided hash.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="hash">The hash to compare against.</param>
    /// <returns>
    /// A <see cref="bool"/> indicating whether the password matches the hash.
    /// </returns>
    public static bool Verify(string password, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
