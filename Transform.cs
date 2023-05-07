namespace Narwhal;

using System;
using System.Linq;

public class Transform
{
    // Constants for the dimensions of the weight array, to avoid confusion
    private const int OUTPUT = 0;
    private const int INPUT = 1;

    private float[,] weightv;
    private int[] offsetv;

    public int InputSize => weightv.GetLength(INPUT);
    public int OutputSize => weightv.GetLength(OUTPUT);

    public Transform(float[,] weights, int[] offsets)
    {
        if (weights.GetLength(0) != offsets.Length)
            throw new ArgumentException("Dimensionality Mismatch: The first dimension of the weight array match the size of the offset array");

        weightv = weights;
        offsetv = offsets;
    }

    public ILayer ApplyTo(ILayer layer)
    {
        // Check dimensionality
        if (layer.Size != InputSize)
            throw new ArgumentException("Dimensionality Mismatch: The second dimension of the weight array must be the same size as the layer to be transformed");

        byte[] result = new byte[OutputSize];

        // for (int outputIndex = 0; outputIndex < outputSize; outputIndex++), but will split threads across multiple CPU cores
        Parallel.For(0, OutputSize,
            outputIndex => {
                // Compute the weighted sum of all activations in the input layer
                double total = layer.Enumerated.Select((activation, inputIndex) => activation * weightv[outputIndex,inputIndex]).Sum();
                result[outputIndex] = Squish(total + offsetv[outputIndex]);
            }
        );
        return new SimpleLayer(result);
    }

    private static int ApplySigmoid(double input, int max)
    {
        // `max` is used to divide the input, then used as the numerator for the return value
        // This maps the range of the sigmoid function to [-max, max] instead of [-1, 1]
        // and also accounts for the fact that the activations being weighted and summed are in range [0, 255] instead of [0, 1]
        // In other words, `max` scales both the domain and range of the sigmoid
        var divisor = Math.Exp(-input / max) + 1.0;
        return (int) (max / divisor);
    }

    // This needs to be `internal` instead of `private` so we can access it from our unit tests
    internal static byte Squish(double input) => (byte) ApplySigmoid(input, 255);
}