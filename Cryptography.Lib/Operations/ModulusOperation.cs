using Cryptography.Lib.Entities;
using Cryptography.Lib.Other;

namespace Cryptography.Lib.Operations;

public sealed class ModulusOperation : Operation
{
    public ModulusOperation()
    {
        modulus = CrypterSettings.Current.Alphabet.LetterCount;
    }

    public ModulusOperation(int modulus)
    {
        this.modulus = modulus;
    }

    private readonly int modulus;

    public static int Mod(int val, int modulus) => ((val % modulus) + modulus) % modulus;
    public static int Mod(int val) => Mod(val, CrypterSettings.Current.Alphabet.LetterCount);

    public override Block Process(Block input)
    {
        var r = new Block();

        foreach (var initial in input.Letters)
        {
            var curId = initial.Id;
            var newId = Mod(curId, modulus);
            r.Letters.Add(new(newId, null));
        }

        return r;
    }
}
