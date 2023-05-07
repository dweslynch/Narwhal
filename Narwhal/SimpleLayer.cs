namespace Narwhal;

using System.Collections.Generic;

public class SimpleLayer : ILayer
{
    private byte[] activations;

    public byte this[int index] => activations[index];
    public int Size => activations.Length;

    public SimpleLayer(byte[] activations)
    {
        if (activations is null)
            throw new ArgumentNullException("Attempted to construct an activation layer from a null byte array");

        this.activations = activations;
    }

    public IEnumerable<byte> Enumerated
    {
        get
        {
            for (int i = 0; i < Size; i++)
            {
                yield return activations[i];
            }
        }
    }
}