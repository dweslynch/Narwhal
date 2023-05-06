using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Narwhal.Test;

[TestClass]
public class HelperTests
{
    [TestMethod]
    public void TestSigmoidWithLowValue() => Assert.AreEqual(0, TransformHelper.Squish(Single.MinValue));

    [TestMethod]
    public void TestSigmoidWithHighValue() => Assert.AreEqual(255, TransformHelper.Squish(Single.MaxValue));
}