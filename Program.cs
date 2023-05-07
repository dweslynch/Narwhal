namespace Narwhal;

using System;

public class Program
{
    public static async Task Main(String[] args) {
        Console.WriteLine("Hello, world!");

        MNISTCell[] data = await MNISTCell.ImportFromFileAsync("datafiles/validate.dump");
        data[0].Visualize();
    }
}