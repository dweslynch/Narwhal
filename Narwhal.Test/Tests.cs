using Microsoft.VisualStudio.TestTools.UnitTesting;
using Narwhal;

namespace Narwhal.Test;

[TestClass]
public class Tests
{
    [TestMethod]
    public void AlwaysPass()
    {
        Assert.IsTrue(true);
    }
}