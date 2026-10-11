using System.Collections;

namespace Cryptography.Lib.Entities;

public sealed class CryptionInfo(string code) : IEnumerable<char>
{
    public string Code { get; } = code;

    public static implicit operator CryptionInfo(string code) => new(code);

    public IEnumerator<char> GetEnumerator() => Code.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}