namespace CRUDTest;

public class UnitTest1
{
    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, 1, 0)]
    public void Test1(int a, int b, int expected)
    {
        int actual = MyMath.Add(a, b);
        Assert.Equal(expected, actual);

    }
}