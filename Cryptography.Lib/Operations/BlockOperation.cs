using Cryptography.Lib.Entities;

namespace Cryptography.Lib.Operations;

public sealed class BlockOperation(int n) : Operation
{
    public override BlockList Process(Block input)
    {
        var r = new BlockList();

        if (input.Letters.Count % n != 0)
            throw new Exception($"'{input.Letters.Count}' adet harf ile '{n}' elemanlı grup oluşturulamaz!");

        for (int i = 0; i < input.Letters.Count; i += n)
        {
            var s = new Block();

            for (int j = 0; j < n; j++)
                s.Letters.Add(input.Letters[i + j]);

            r.Items.Add(s);
        }

        return r;
    }
}