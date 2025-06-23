using System.Threading.Tasks;

namespace GenICam;

public class GenStringRegWrapper : IPValue
{
    private readonly GenStringReg _stringReg;

    public GenStringRegWrapper(GenStringReg stringReg)
    {
        _stringReg = stringReg;
    }

    /// <summary>
    /// Gets the value from the wrapped GenStringReg as a long.
    /// You can customize how to interpret the string to long (e.g. via encoding).
    /// </summary>
    public async Task<long?> GetValueAsync()
    {
        var strValue = await _stringReg.GetValueAsync();  // Assuming this returns Task<string>
        return long.TryParse(strValue, out var result) ? result : null;
    }

    /// <summary>
    /// Sets the value to the wrapped GenStringReg using long interpreted as string.
    /// You can adjust conversion logic as needed.
    /// </summary>
    public async Task<IReplyPacket> SetValueAsync(long value)
    {
        var stringValue = value.ToString();
        return await _stringReg.SetValueAsync(stringValue);  // Assuming GenStringReg has this overload
    }

}
