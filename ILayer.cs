namespace Narwhal;

using System;
using System.Collections.Generic;

// Interface representing the activation state of a neural layer that can have transforms applied to it
public interface ILayer
{
    public byte this[int index] { get; }

    public int Size { get; }

    // Provide an IEnumerable that we can run LINQ queries on
    public IEnumerable<byte> Enumerated { get; }

    public bool IsTerminalLayer => false;
}