namespace Cryptography.Lib.Entities;

public sealed class Vector : ICloneable
{
    public Vector()
    {
        values = [];
    }

    public Vector(params float[] items) : this()
    {
        values.AddRange(items);
    }

    public float this[int index]
    {
        get => values[index];
        set => values[index] = value;
    }
    private readonly List<float> values = [];
    public void Add(float value) => values.Add(value);
    public void Clear() => values.Clear();
    public void RemoveAt(int col)
    {
        values.RemoveAt(col);
    }

    public object Clone()
    {
        return new Vector([.. values]);
    }

    public int Length => values.Count;

    //nokta çarpım
    public static float operator *(Vector a, Vector b)
    {
        if (a.Length != b.Length) throw new Exception("Çarpılan vektörlerin uzunlukları aynı olmalı.");

        var res = 0.0f;

        for (int i = 0; i < a.Length; i++)
            res += a[i] * b[i];

        return res;
    }
}
