using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Narwhal.Test;

[TestClass]
public class SerializerTests
{
    [TestMethod]
    public async Task TestImportExport()
    {
        var testData = await MNISTCell.ImportFromFileAsync("datafiles/test.dump");
        await MNISTCell.ExportToFileAsync("datafiles/export.dump", testData);
        var exportedData = await MNISTCell.ImportFromFileAsync("datafiles/export.dump");
        
        Assert.AreEqual(testData.Length, exportedData.Length, $"Test data and re-imported data have different lengths. Test: {testData.Length}. Re-imported: {exportedData.Length}");
        for (var i = 0; i < testData.Length; i++)
        {
            Assert.AreEqual(testData[i], exportedData[i], "Imported and exported datasets do not match");
        }
    }
}