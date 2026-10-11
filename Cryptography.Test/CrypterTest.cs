using Cryptography.Lib.Crypters;
using Cryptography.Lib.Operations;

namespace Cryptography.Test;

public class CrypterTest
{
    [Theory]
    [InlineData("ABC", "ZYV")]
    [InlineData("BCGA", "YVSZ")]
    public void AtbashTest(string message, string expectedCode)
    {
        var c = new AtbashCrypter();
        var result = c.Encode(message);
        Assert.Equal(expectedCode, result.Code);
    }

    [Theory]
    [InlineData("ABC", "ÇDE")]
    [InlineData("BCGA", "DEIÇ")]
    public void GenericCeaserTest(string message, string expectedCode)
    {
        var c = new CeaserCrypter();
        var result = c.Encode(message);
        Assert.Equal(expectedCode, result.Code);
    }

    [Theory]
    [InlineData("ELMAYE", "FRZUĞF")]
    public void CustomCrypterTest(string message, string expectedCode)
    {
        var c1 = new CustomCrypter("Deneme");
        c1.AddEncodeOp(new TransposeOperation(3));
        c1.AddEncodeOp(new MultiplyOperation(8));

        var result = c1.Encode(message);
        Assert.Equal(expectedCode, result.Code);
    }
}
