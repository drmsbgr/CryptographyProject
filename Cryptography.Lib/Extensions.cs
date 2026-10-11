using Cryptography.Lib.Entities;

namespace Cryptography.Lib;

public static class Extensions
{
    extension(Alphabet alphabet)
    {
        public static Alphabet TurkishAlphabet =>
            new("Türk Alfabesi", "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ");
        public static Alphabet EnglishAlphabet =>
            new("İngiliz Alfabesi", "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
    }
}