namespace LogicLayer.Cryptography;

public abstract class Verification
{
    public static string GenerateVerificationCode()
    {
        var random = new Random();
        var code = "";
        for (var i = 0; i < 4; i++)
        {
            code += random.Next(0, 9).ToString();
        }

        return code;
    }

    public static string GenerateBearerToken()
    {
        return Guid.NewGuid().ToString();
    }
}