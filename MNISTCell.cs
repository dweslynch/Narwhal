namespace Narwhal;

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public class MNISTCell
{
    private byte[] data;

     public MNISTCell(byte[] contents)
     {
        if (contents.Length != 785)
            throw new ArgumentException($"The input array must consist of a single label byte, followed by 784 content bytes.  Got {contents.Length} bytes.");
        data = contents;
     }

     public byte Label => data[0];

     public byte this[int index] => data[index + 1];

     public byte[] Dump() => data;  // This is public because we do need a way to access this, but could consider returning a copy

     public void Visualize()
     {
        for (int i = 0; i < 28; i ++)
        {
            for (int j = 0; j < 28; j++)
            {
                byte pixel = this[i * 28 + j];
                if (pixel == 0)
                    Console.Write(" ");
                else
                    Console.Write("█");
            }
            Console.WriteLine();
        }
     }

    public static async Task<MNISTCell[]> ImportFromFileAsync(String path)
    {
        byte[] bytes = await File.ReadAllBytesAsync(path);

        if (bytes.Length % 785 != 0)
            throw new InvalidDataException($"Failed to import handwriting cells from file {path} because it does not contain a multiple of 785 bytes");

        var cells = new MNISTCell[bytes.Length / 785];
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = new MNISTCell(bytes[(i * 785)..((i + 1) * 785)]);
        }
        return cells;
    }

    public static async Task ExportToFileAsync(String path, MNISTCell[] cells)
    {
        await File.WriteAllBytesAsync(path, cells.SelectMany(cell => cell.Dump()).ToArray());
    }

    public override bool Equals(object? obj)
    {
        if (obj is not null && obj is MNISTCell other)
        {
            return Enumerable.SequenceEqual(this.Dump(), other.Dump());
        }
        return false;
    }

    // We take each value in the array, multiply it by its index + 1 (because value * 0 = 0) and sum it all together, treating overflows as a feature if they happen
    // I am not sure this produces all the uniqueness you'd want in a hashcode, but it should keep the compiler from complaining
    public override int GetHashCode() => data.Select((item, index) => item * (index + 1)).Sum();

}