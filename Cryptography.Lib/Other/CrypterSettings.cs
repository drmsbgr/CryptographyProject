using Cryptography.Lib.Entities;

namespace Cryptography.Lib.Other;

public sealed class CrypterSettings(Alphabet alphabet)
{
    private static CrypterSettings current = new(Alphabet.TurkishAlphabet);
    public static CrypterSettings Current { get => current; set => current = value; }
    public Alphabet Alphabet { get; set; } = alphabet;
}
