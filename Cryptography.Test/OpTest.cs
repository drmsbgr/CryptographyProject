using Cryptography.Lib.Entities;
using Cryptography.Lib.Operations;
using Cryptography.Lib.Other;

namespace Cryptography.Test;

public class OpTest
{
    [Theory]
    [InlineData('A', 'B', 1)]
    [InlineData('A', 'C', 2)]
    [InlineData('B', 'E', 4)]
    public void TransposeTest(char input, char expected, int bias)
    {
        //TÜRK ALFABESİNE GÖRE TEST EDİLİR
        var op = new TransposeOperation(bias);
        var targetLetter = CrypterSettings.Current.Alphabet.GetLetterByChar(input);
        var result = (Letter)op.Process(targetLetter);
        Assert.Equal(expected, result.Value);
    }

    [Fact]
    public void BlockTest()
    {
        var message = "ABCDEF";
        var op = new BlockOperation(3);
        var input = new Block(message);
        var result = op.Process(input);

        Assert.Equal(2, result.Items.Count);
        Assert.Equal("ABC", result.Items[0].Word);
        Assert.Equal("DEF", result.Items[1].Word);
    }
}
