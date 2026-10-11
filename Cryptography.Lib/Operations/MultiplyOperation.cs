using Cryptography.Lib.Entities;
using Cryptography.Lib.Other;

namespace Cryptography.Lib.Operations;

public sealed class MultiplyOperation(int coefficient) : Operation
{
    public override Block Process(Block input)
    {
        var r = new Block();
        foreach (var initial in input.Letters)
        {
            int newId = ModulusOperation.Mod(coefficient * initial.Id);
            r.Letters.Add(CrypterSettings.Current.Alphabet.GetLetterById(newId));
        }
        return r;
    }
}