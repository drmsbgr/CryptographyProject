using Cryptography.Lib.Contracts;
using Cryptography.Lib.Other;

namespace Cryptography.Lib.Entities;

public sealed class CrypterSet : IEncoder, IDecoder, IInfo
{
    public CrypterSet()
    {
        crypterSet = [];
    }

    public CrypterSet(ICollection<ICrypter> _crypterSet)
    {
        crypterSet = [.. _crypterSet];
    }

    private readonly List<ICrypter> crypterSet;

    public void Add(ICrypter crypter)
    {
        crypterSet.Add(crypter);
    }

    public CryptionInfo Decode(CryptionInfo code)
    {
        var copy = new List<ICrypter>(crypterSet);
        copy.Reverse();

        var initial = code;
        foreach (var item in copy)
            initial = item.Decode(initial);

        return initial;
    }

    public CryptionInfo Encode(CryptionInfo initial)
    {
        var code = initial;

        foreach (var item in crypterSet)
            code = item.Encode(code);

        return code;
    }

    public Info GetInfo()
    {
        var letters = CrypterSettings.Current.Alphabet.GetLetters();
        var info = new Info("Şifreleyici Seti");

        crypterSet.ForEach(x => info.AddContent(x.CrypterName));
        info.AddBounds();
        info.AddContent(letters);
        info.AddContentWithLowerBounds(Encode(letters).Code);
        return info;
    }
}