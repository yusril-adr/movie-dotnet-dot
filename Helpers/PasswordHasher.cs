using System;
using System.Security.Cryptography;
using System.Text;

namespace dot_dotnet_test_api.Helpers;
public class PasswordHasher
{
    private const int SaltSize = 16; // 128 bit
    private const int KeySize = 32;  // 256 bit
    private const int Iterations = 10000; // Number of iterations for PBKDF2
    private static readonly HashAlgorithmName HashAlgorithm = HashAlgorithmName.SHA256;

    // Generates a hashed password with a salt
    public static string HashPassword(string password)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            // Generate a random salt
            var salt = new byte[SaltSize];
            rng.GetBytes(salt);

            // Hash the password with the salt
            var hash = HashPasswordWithSalt(password, salt);

            // Combine the salt and the hash
            var hashBytes = new byte[SaltSize + KeySize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, KeySize);

            // Convert the combined salt and hash to a base64 string
            return Convert.ToBase64String(hashBytes);
        }
    }

    // Verifies a password against a stored hashed password
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Extract the salt and hash from the stored hashed password
        var hashBytes = Convert.FromBase64String(hashedPassword);

        var salt = new byte[SaltSize];
        Array.Copy(hashBytes, 0, salt, 0, SaltSize);

        var storedHash = new byte[KeySize];
        Array.Copy(hashBytes, SaltSize, storedHash, 0, KeySize);

        // Hash the provided password with the extracted salt
        var hash = HashPasswordWithSalt(password, salt);

        // Compare the stored hash with the newly generated hash
        return CryptographicOperations.FixedTimeEquals(storedHash, hash);
    }

    // Hashes a password using the provided salt
    private static byte[] HashPasswordWithSalt(string password, byte[] salt)
    {
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithm))
        {
            return pbkdf2.GetBytes(KeySize); // Get the hash (key)
        }
    }
}
