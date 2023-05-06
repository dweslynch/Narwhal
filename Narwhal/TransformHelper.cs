namespace Narwhal;

public static class TransformHelper
{
    private static int ApplySigmoid(float input, int max)
    {
        var divisor = Math.Exp(-input) + 1.0;
        return (int) (max / divisor);
    }

    public static byte Squish(float input) => (byte) ApplySigmoid(input, 255);
}