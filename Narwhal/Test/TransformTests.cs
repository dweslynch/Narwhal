using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Narwhal.Test;

[TestClass]
public class TransformTests
{
    [TestMethod]
    public void TestSigmoidWithLowValue() => Assert.AreEqual(0, Transform.Squish(Double.MinValue));

    [TestMethod]
    public void TestSigmoidWithHighValue() => Assert.AreEqual(255, Transform.Squish(Double.MaxValue));

    [TestMethod]
    public void TestApplyTransformToLayer()
    {
        byte[] inputLayer = new byte[] { 255, 100 };
        float[,] weights = new float[,]
        {
            { 0, 50 },  // Weights for the first and second input neuron respectively, to calculate the activation of the first output neuron
            { -50, 1 }  // Weights to calculate the activation of the second output neuron
        };
        short[] offsets = new short[] { 0, 12650 };     // Bias/Offset of the first and second output neuron, respectively

        // Activation[out_0] = Squish(Activation[in_0] * Weight[out0, in_0] + Activation[in_1] * Weight[out_0, in_1] + Offset[out_0])
        //                   = Squish(255              * 0                  + 100              * 50                  + 0            )
        //                   = Squish(0                                     + 5000                                   + 0            )
        //                   = Squish(5000)
        //                   = 255
        // Activation[out_1] = Squish(Activation[in_0] * Weight[out1, in_0] + Activation[in_1] * Weight[out_1, in_1] + Offset[out_1])
        //                   = Squish(255              * -50                + 100              * 1                   + 12650        )
        //                   = Squish(-12750                                + 100                                    + 12650        )
        //                   = Squish(0)
        //                   = 127

        ILayer layer = new SimpleLayer(inputLayer);
        Transform transform = new Transform(weights, offsets);
        ILayer transformedLayer = transform.ApplyTo(layer);

        Assert.AreEqual(2, transformedLayer.Size);
        Assert.AreEqual(255, transformedLayer[0]);
        Assert.AreEqual(127, transformedLayer[1]);
    }
}