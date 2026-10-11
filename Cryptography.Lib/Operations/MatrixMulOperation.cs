using Cryptography.Lib.Entities;
using Cryptography.Lib.Other;

namespace Cryptography.Lib.Operations;

public sealed class MatrixMulOperation(Matrix B, bool byRight = true) : Operation
{
    public override Block Process(Block input)
    {
        var A = new Matrix();
        var items = new Vector();
        input.Letters.ForEach(x => items.Add(x.Id));
        A.AddRow(items);

        Matrix? r = null;

        if (byRight)
            r = A * B;
        else
            r = B * A.Transpose();

        var targetRow = r.GetRow(0);

        var result = new Block();

        for (int i = 0; i < targetRow.Length; i++)
        {
            result.Letters
            .Add(CrypterSettings.Current.Alphabet
                .GetLetterById(ModulusOperation.Mod((int)targetRow[i]))
            );
        }


        return result;
    }
}
