using Cryptography.Lib.Entities;
using Cryptography.Lib.Operations;
using Cryptography.Lib.Operations.Contracts;
using Cryptography.Lib.Other;

namespace Cryptography.Lib.Crypters;

public sealed class AtbashCrypter() : Crypter("AtbashCrypter")
{
    protected override Queue<IOperation> DecodeOps() => EncodeOps();

    protected override Queue<IOperation> EncodeOps()
    {
        return new Queue<IOperation>([new MultiplyOperation(-1), new TransposeOperation(CrypterSettings.Current.Alphabet.LetterCount - 1)]);
    }
}