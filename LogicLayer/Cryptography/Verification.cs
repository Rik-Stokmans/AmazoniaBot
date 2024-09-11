namespace LogicLayer.Cryptography;

public class Verification
{
    public static string GenerateVerificationCode()
    {
        var random = new Random();
        var code = "";
        for (var i = 0; i < 6; i++)
        {
            code += random.Next(0, 9).ToString();
        }

        return code;
    }
}