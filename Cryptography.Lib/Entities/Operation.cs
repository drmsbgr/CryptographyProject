using Cryptography.Lib.Operations.Contracts;

namespace Cryptography.Lib.Entities;

public abstract class Operation : IOperation
{
    public abstract IOperationOutput Process(Block input);
}
