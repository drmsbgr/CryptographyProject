using Cryptography.Lib.Entities;

namespace Cryptography.Test;

public class MatrixTest
{
    [Fact]
    public void VectorMultiplicationTest()
    {
        var v1 = new Vector(1, 2, 1);
        var v2 = new Vector(2, 3, 2);
        var res = v1 * v2;
        Assert.Equal(10, res);
    }

    [Fact]
    public void MatrixMultiplicationTest()
    {
        var m1 = new Matrix();
        m1.AddRow(new(1, 2));
        m1.AddRow(new(0, 1));
        var m2 = new Matrix();
        m2.AddRow(new(2, 1));
        m2.AddRow(new(1, 2));
        var res = m1 * m2;

        Assert.Equal(4, res[0, 0]);
        Assert.Equal(5, res[0, 1]);
        Assert.Equal(1, res[1, 0]);
        Assert.Equal(2, res[1, 1]);
    }

    [Fact]
    public void DeterminantTest()
    {
        var m1 = new Matrix();
        m1.AddRow(new(1, 2));
        m1.AddRow(new(4, 3));
        Assert.Equal(-5, m1.Determinant());
    }

    [Fact]
    public void DeterminantTest2()
    {
        var m2 = new Matrix();
        m2.AddRow(new(1, 1, -1));
        m2.AddRow(new(0, 2, 1));
        m2.AddRow(new(-1, 1, 0));
        Assert.Equal(-4, m2.Determinant());
    }

    [Fact]
    public void MinorTest()
    {
        var m = new Matrix();
        m.AddRow(new(1, 2));
        m.AddRow(new(4, 3));

        Assert.Equal(3, m.Minor(0, 0)[0, 0]);
        Assert.Equal(4, m.Minor(0, 1)[0, 0]);
        Assert.Equal(2, m.Minor(1, 0)[0, 0]);
        Assert.Equal(1, m.Minor(1, 1)[0, 0]);
    }

    [Fact]
    public void CofactorTest()
    {
        var m = new Matrix();
        m.AddRow(new(1, 2));
        m.AddRow(new(-3, 4));

        var cofactor = m.Cofactor();

        Assert.Equal(4, cofactor[0, 0]);
        Assert.Equal(3, cofactor[0, 1]);
        Assert.Equal(-2, cofactor[1, 0]);
        Assert.Equal(1, cofactor[1, 1]);
    }

    [Fact]
    public void InverseTest()
    {
        var m = new Matrix();
        m.AddRow(new(1, 2));
        m.AddRow(new(-3, 4));

        var inf = m.Inverse();

        Assert.Equal(2f / 5f, inf[0, 0]);
        Assert.Equal(-1f / 5f, inf[0, 1]);
        Assert.Equal(3f / 10f, inf[1, 0]);
        Assert.Equal(1f / 10f, inf[1, 1]);
    }
}