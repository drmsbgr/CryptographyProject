using Cryptography.Lib.Contracts;

namespace Cryptography.Lib.Entities;

public class Alphabet : IInfo
{
    public string AlphabetName { get; } = string.Empty;
    private readonly List<Letter> Letters = [];
    public int LetterCount => Letters.Count;

    public Alphabet(string alphabetName, IEnumerable<char> letters)
    {
        this.AlphabetName = alphabetName;
        this.Letters.AddRange(letters.Select(x => new Letter(Letters.Count, x)));
    }

    public string GetLetters() => string.Join("", Letters.Select(x => x.Value.ToString()));

    public Info GetInfo()
    {
        var info = new Info(AlphabetName);
        info.AddContentWithLowerBounds(GetLetters());
        return info;
    }

    public Letter GetLetterByChar(char target)
    {
        var found = Letters.Find(x => x.Value == target);
        if (found is not null)
            return found;
        else
            throw new Exception($"'{AlphabetName}' içerisinde '{target}' harfi bulunamadı.");
    }

    public Letter GetLetterById(int index)
    {
        var found = Letters.Find(x => x.Id == index);
        if (found is not null)
            return found;
        else
            throw new Exception($"'{AlphabetName}' içerisinde '{index}' numarasına sahip bir harf bulunamadı.");
    }
}