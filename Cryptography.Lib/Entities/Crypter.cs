using System.Transactions;
using Cryptography.Lib.Contracts;
using Cryptography.Lib.Operations.Contracts;
using Cryptography.Lib.Other;

namespace Cryptography.Lib.Entities;

public abstract class Crypter(string crypterName) : ICrypter, IInfo
{
    public string CrypterName { get; } = crypterName;
    protected abstract Queue<IOperation> EncodeOps();
    protected abstract Queue<IOperation> DecodeOps();

    private static CryptionInfo Process(CryptionInfo info, Queue<IOperation> ops)
    {
        info = new CryptionInfo(info.Code.Replace(" ", ""));

        IOperationOutput output = new Block(info.Code);

        while (ops.Count > 0)
        {
            var op = ops.Dequeue();

            switch (output)
            {
                case Block block:
                    output = op.Process(block);
                    break;
                case BlockList blockList:
                    var subOutputBlock = new Block();
                    foreach (var block in blockList.Items)
                    {
                        var subOps = new Queue<IOperation>();
                        subOps.Enqueue(op);
                        ops.ToList().ForEach(subOps.Enqueue);
                        var subOutput = Process(block.Word, subOps);
                        foreach (var item in subOutput.Code)
                            subOutputBlock.Letters.Add(CrypterSettings.Current.Alphabet.GetLetterByChar(item));
                    }
                    output = subOutputBlock;
                    break;
            }
        }

        var result = (Block)output;
        return new CryptionInfo(result.Word);
    }

    public virtual CryptionInfo Encode(CryptionInfo message) => Process(message, EncodeOps());

    public virtual CryptionInfo Decode(CryptionInfo message) => Process(message, DecodeOps());

    public Info GetInfo()
    {
        var letters = CrypterSettings.Current.Alphabet.GetLetters();
        var info = new Info(CrypterName);
        info.AddContent(letters);
        try
        {
            info.AddContentWithLowerBounds(Encode(new CryptionInfo(letters)).Code);
        }
        catch (Exception)
        {
            info.AddContentWithLowerBounds("<Alfabe şifreleme başarısız oldu>");
        }

        return info;
    }
}
