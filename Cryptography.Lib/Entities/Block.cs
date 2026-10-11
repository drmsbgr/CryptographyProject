using Cryptography.Lib.Operations.Contracts;
using Cryptography.Lib.Other;

namespace Cryptography.Lib.Entities;

public sealed class Block : IOperationOutput
{
    public Block()
    {
        Letters = [];
    }

    public Block(string message) : this()
    {
        foreach (var item in message)
            Letters.Add(CrypterSettings.Current.Alphabet.GetLetterByChar(item));
    }

    public static explicit operator Letter(Block block) => CrypterSettings.Current.Alphabet.GetLetterByChar(block.Word[0]);

    public List<Letter> Letters = [];
    public string Word => string.Join("", Letters.Select(x => x.Value));
}