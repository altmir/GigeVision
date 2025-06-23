using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenICam;

public class GenStructReg : IPValue
{
    public CategoryProperties Properties { get; }
    public long Address { get; }
    public ushort Length { get; }
    public GenAccessMode AccessMode { get; }
    public IPort Port { get; }
    public List<GenStructEntry> Entries { get; }

    public GenStructReg(CategoryProperties props, long address, ushort length, GenAccessMode accessMode, IPort port, List<GenStructEntry> entries)
    {
        Properties = props;
        Address = address;
        Length = length;
        AccessMode = accessMode;
        Port = port;
        Entries = entries;
    }

    public async Task<long?> GetValueAsync()
    {
        IReplyPacket reply = await Port.ReadAsync(Address, Length);
        byte[] buffer = reply.MemoryValue;

        long result = 0;
        for (int i = 0; i < buffer.Length; i++)
        {
            result |= ((long)buffer[i]) << (8 * i);
        }

        return result;
    }

    public async Task<IReplyPacket> SetValueAsync(long value)
    {
        byte[] buffer = new byte[Length];
        for (int i = 0; i < Length; i++)
        {
            buffer[i] = (byte)((value >> (8 * i)) & 0xFF);
        }

        return await Port.WriteAsync(buffer, Address, Length);
    }
}
