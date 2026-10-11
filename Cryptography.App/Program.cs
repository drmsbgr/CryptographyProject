using Cryptography.Lib;
using Cryptography.Lib.Crypters;
using Cryptography.Lib.Entities;
using Cryptography.Lib.Other;

CrypterSettings.Current.Alphabet = Alphabet.EnglishAlphabet;
Console.WriteLine(CrypterSettings.Current.Alphabet.GetInfo());

var message = "PAY MORE MONEY";
var key = new Matrix();
key.AddRow(new(17, 17, 5));
key.AddRow(new(21, 18, 21));
key.AddRow(new(2, 2, 19));

var crypter = new HillCrypter(key);

Console.WriteLine(crypter.GetInfo());

Console.WriteLine(message);
var encoded = crypter.Encode(message).Code;
Console.WriteLine(encoded);
// var decoded = crypter.Decode(encoded).Code;
// Console.WriteLine(decoded);