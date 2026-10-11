namespace Cryptography.Lib.Entities;

public class Letter(int id, char? value)
{
    public int Id { get; } = id;
    public char? Value { get; private set; } = value;

    public static implicit operator Block(Letter l) => new(l.Value.ToString()!);
}