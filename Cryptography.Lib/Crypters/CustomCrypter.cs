using Cryptography.Lib.Entities;
using Cryptography.Lib.Operations.Contracts;

namespace Cryptography.Lib.Crypters;

public sealed class CustomCrypter(string name) : Crypter(name)
{
    private readonly Queue<IOperation> encodeOperations = [];
    private readonly Queue<IOperation> decodeOperations = [];

    protected override Queue<IOperation> EncodeOps() => encodeOperations;
    protected override Queue<IOperation> DecodeOps() => decodeOperations;

    public void AddEncodeOp(IOperation op) => encodeOperations.Enqueue(op);
    public void AddDecodeOp(IOperation op) => decodeOperations.Enqueue(op);
}