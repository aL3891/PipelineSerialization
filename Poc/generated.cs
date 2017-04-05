using System;
using System.IO.Pipelines;
using System.Text.Formatting;
using System.Text;
using System.Buffers;

public static partial class Serializer
{
    static Span<byte> span = new Span<byte>(Encoding.UTF8.GetBytes(""));
    private const byte ByteLF = (byte)'{';


    public static bool Deserialize(ReadableBuffer buffer, Library.Person t, out ReadCursor consumed, out ReadCursor examined)
    {
        consumed = buffer.Start;
        examined = buffer.End;

        var span = buffer.First.Span;

        var lineIndex = span.IndexOfVectorized(ByteLF);
        if (lineIndex >= 0)
        {
            consumed = buffer.Move(consumed, lineIndex + 1);
            span = span.Slice(0, lineIndex + 1);
        }
        else 
        {
            // No request line end
            return false;
        }

        Span<byte> value;
        if (value.Equals(new Span<byte>(Encoding.UTF8.GetBytes("Age"))))
        {
        }
        if (value.Equals(new Span<byte>(Encoding.UTF8.GetBytes("Name"))))
        {
        }

        return true; 
    }
}