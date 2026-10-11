namespace Cryptography.Lib;

public static class ModularMath
{
    public static long ExtendedGCD(long b, long n, out long x, out long y)
    {
        if (b == 0)
        {
            x = 0; y = 1;
            return n;
        }

        long gcd = ExtendedGCD(n % b, b, out long x1, out long y1);
        x = y1 - n / b * x1;
        y = x1;
        return gcd;
    }

    public static long ModulerBolme(long a, long b, long n)
    {
        long g = ExtendedGCD(b, n, out long x, out long y);

        // Kural: gcd(b, n), a'yı tam bölmeli
        if (a % g != 0)
            throw new Exception("Bu modüler bölme işleminin sonucu yoktur!");

        // Genel çözüm: x = (x0 * (a/g)) % (n/g)
        long result = (x * (a / g)) % (n / g);

        // Sonucun negatif çıkmasını engelle
        if (result < 0) result += (n / g);

        return result;
    }

    public static (long pay, long payda) ConverToRational(double ondalikliSayi)
    {
        // 1. Ondalık basamak sayısını bulalım
        string text = ondalikliSayi.ToString(System.Globalization.CultureInfo.InvariantCulture);
        int virguldenSonra = 0;

        if (text.Contains('.'))
        {
            virguldenSonra = text.Split('.')[1].Length;
        }

        // 2. Paydayı 10'un kuvveti olarak belirleyelim
        long payda = (long)Math.Pow(10, virguldenSonra);

        // 3. Payı tam sayıya çevirelim
        long pay = (long)Math.Round(ondalikliSayi * payda);

        // 4. En sade hali bulmak için EBOB (GCD) ile sadeleştirelim
        long ortakBolen = GCD(pay, payda);

        return (pay / ortakBolen, payda / ortakBolen);
    }

    // Öklid Algoritması ile EBOB Bulma
    public static long GCD(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return Math.Abs(a);
    }
}