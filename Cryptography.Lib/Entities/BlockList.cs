using Cryptography.Lib.Operations.Contracts;

namespace Cryptography.Lib.Entities;

public sealed class BlockList : IOperationOutput
{
    public List<Block> Items = [];
}
