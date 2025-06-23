using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Threading.Tasks;

namespace GenICam;

public class GenStructEntry : IPValue
{
    public string Name { get; }
    public short LSB { get; }
    public short MSB { get; }
    public ushort Length { get; }

    public GenStructEntry(string name, short lsb, short msb, ushort length)
    {
        Name = name;
        LSB = lsb;
        MSB = msb;
        Length = length;
    }

    /// <summary>
    /// Stub: Not used standalone; part of GenStructReg
    /// </summary>
    public Task<long?> GetValueAsync()
    {
        throw new GenICamException("GenStructEntry cannot be read independently.");
    }

    /// <summary>
    /// Stub: Not used standalone; part of GenStructReg
    /// </summary>
    public Task<IReplyPacket> SetValueAsync(long value)
    {
        throw new GenICamException("GenStructEntry cannot be written independently.");
    }
}
