using Cryptography.Lib.Entities;
using Cryptography.Lib.Operations;
using Cryptography.Lib.Operations.Contracts;

namespace Cryptography.Lib.Crypters;

public sealed class HillCrypter : Crypter
{
    private readonly Matrix key;
    public HillCrypter(Matrix key) : base("Hill Crypter")
    {
        if (key.Row != key.Column)
            throw new Exception("Anahtar matris kare olmak zorundadır!");
        this.key = key;
    }
    protected override Queue<IOperation> EncodeOps()
    {
        return new Queue<IOperation>([
            new BlockOperation(key.Row),
            new MatrixMulOperation(key)
        ]);
    }

    protected override Queue<IOperation> DecodeOps()
    {
        return new Queue<IOperation>([
            new BlockOperation(key.Row),
            new MatrixMulOperation(key.Inverse(), false)
        ]);
    }
}