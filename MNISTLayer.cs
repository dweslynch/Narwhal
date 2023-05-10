namespace Narwhal;

using System;

public class MNISTLayer : ILayer
{
    private MNISTCell cell;

    public byte this[int index] => cell[index];

    public int Size => 784;

    public bool IsTerminalLayer => true;

    public MNISTLayer(MNISTCell cell)
    {
        this.cell = cell;
    }

    public IEnumerable<byte> Enumerated
    {
        get
        {
            for (int i = 0; i < Size; i++)
                yield return cell[i];
        }
    }
}