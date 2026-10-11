namespace Cryptography.Lib.Entities;

public sealed class Matrix
{
    public Matrix()
    {

    }

    public Matrix(int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            var v = new Vector();
            for (int j = 0; j < col; j++)
                v.Add(0);
            AddRow(v);
        }
    }

    public float this[int i, int j]
    {
        get => rows[i][j];
        set => rows[i][j] = value;
    }
    private readonly List<Vector> rows = [];
    public void AddRow(Vector v) => rows.Add(v);
    public Vector GetRow(int rowIndex) => rows[rowIndex];
    public Vector GetColumn(int columnIndex)
    {
        var v = new Vector();

        for (int i = 0; i < Row; i++)
            v.Add((int)this[i, columnIndex]);

        return v;
    }
    public void Clear() => rows.Clear();
    public int Row => rows.Count;
    public int Column => rows.Count > 0 ? rows[0].Length : 0;

    public static Matrix operator *(float a, Matrix b)
    {
        var res = new Matrix(b.Row, b.Column);

        for (int i = 0; i < b.Row; i++)
        {
            for (int j = 0; j < b.Column; j++)
            {
                res[i, j] = a * b[i, j];
            }
        }

        return res;
    }

    public static Matrix operator *(Matrix a, Matrix b)
    {
        var res = new Matrix();

        for (int i = 0; i < a.Row; i++)
        {
            var row = new Vector();
            for (int j = 0; j < b.Column; j++)
                row.Add(0);
            res.AddRow(row);
        }

        for (int i = 0; i < a.Row; i++)
        {
            for (int j = 0; j < b.Column; j++)
            {
                res[i, j] = a.GetRow(i) * b.GetColumn(j);
            }
        }

        return res;
    }

    public Matrix Transpose()
    {
        var r = new Matrix();

        for (int i = 0; i < Column; i++)
            r.AddRow(GetColumn(i));

        return r;
    }

    public float Determinant()
    {
        if (Row != Column)
            throw new Exception("Sadece kare matrislerin determinantı hesaplanabilir!");

        if (Row == 1)
            return this[0, 0];

        if (Row == 2)
            return this[0, 0] * this[1, 1] - this[0, 1] * this[1, 0];

        var result = 0.0f;

        for (int j = 0; j < Column; j++)
        {
            var coefficient = (0 + j) % 2 == 0 ? 1 : -1;
            var value = this[0, j];
            var minorDet = Minor(0, j).Determinant();
            result += coefficient * value * minorDet;
        }

        return result;
    }

    public Matrix Minor(int row, int col)
    {
        var r = new Matrix();

        for (int i = 0; i < Row; i++)
        {
            if (i == row) continue;

            var targetRow = (Vector)GetRow(i).Clone();

            targetRow.RemoveAt(col);

            r.AddRow(targetRow);
        }

        return r;
    }

    public Matrix Cofactor()
    {
        var r = new Matrix(Row, Column);

        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                var scale = (i + j) % 2 == 0 ? 1 : -1;
                var minor = Minor(i, j);
                var det = minor.Determinant();
                r[i, j] = scale * det;
            }
        }

        return r;
    }

    public Matrix Inverse() => 1f / Determinant() * Cofactor().Transpose();
}