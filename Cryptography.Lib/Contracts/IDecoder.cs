using Cryptography.Lib.Entities;

namespace Cryptography.Lib.Contracts;

public interface IDecoder
{
    CryptionInfo Decode(CryptionInfo code);
}
