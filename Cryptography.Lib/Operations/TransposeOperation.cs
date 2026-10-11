using Cryptography.Lib.Entities;
using Cryptography.Lib.Other;

namespace Cryptography.Lib.Operations;

public sealed class TransposeOperation(int amount) : Operation
{
    public override Block Process(Block input)
    {
        var result = new Block();

        foreach (var initial in input.Letters)
            result.Letters.Add(CrypterSettings.Current.Alphabet.GetLetterById(ModulusOperation.Mod(initial.Id + amount)));

        return result;
    }
}