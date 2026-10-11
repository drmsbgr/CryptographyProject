namespace Cryptography.Lib.Contracts;

public interface ICrypter : IEncoder, IDecoder
{
    public string CrypterName { get; }
}
