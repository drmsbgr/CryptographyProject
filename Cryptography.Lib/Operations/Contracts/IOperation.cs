using Cryptography.Lib.Entities;

namespace Cryptography.Lib.Operations.Contracts;

public interface IOperation
{
    IOperationOutput Process(Block input);
}
