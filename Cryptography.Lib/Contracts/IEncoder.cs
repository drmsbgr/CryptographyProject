using Cryptography.Lib.Entities;

namespace Cryptography.Lib.Contracts;

public interface IEncoder
{
    CryptionInfo Encode(CryptionInfo message);
}
