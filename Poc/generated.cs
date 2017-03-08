using System;
using System.IO.Pipelines;
using System.Text.Formatting;
using System.Text;

public static partial class Serializer
{
    static Span<byte> span = new Span<byte>(Encoding.UTF8.GetBytes("{\"Age\" : ',\"Name\" : }"));
    static Span<byte> slice0 = span.Slice(0, 9);
    static Span<byte> slice9 = span.Slice(9, 1);
    static Span<byte> slice10 = span.Slice(10, 11);
    public static void Serialize(WritableBuffer wb, Library.Person t)
    {
        var enc = TextEncoder.Utf8;
        wb.Write(slice0);
        wb.Append(t.Age, enc);
        if (t.Name != null)
        {
            wb.Write(slice9);
            wb.Append(t.Name, enc);
            wb.Write(slice9);
        }

        wb.Write(slice10);
    }
}