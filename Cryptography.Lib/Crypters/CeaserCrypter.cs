using Cryptography.Lib.Entities;
using Cryptography.Lib.Operations;
using Cryptography.Lib.Operations.Contracts;
using Cryptography.Lib.Other;

namespace Cryptography.Lib.Crypters;

public sealed class CeaserCrypter(int bias = 3) : Crypter("Ceaser Crypter")
{
    protected override Queue<IOperation> EncodeOps()
    {
        return new Queue<IOperation>([new TransposeOperation(bias)]);
    }

    protected override Queue<IOperation> DecodeOps()
    {
        return new Queue<IOperation>([new TransposeOperation(-bias)]);
    }
}