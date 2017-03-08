using System;
using System.IO.Pipelines;
using System.Text.Formatting;
using System.Text;

public class PersonSerializer
{
    static Span<byte> span = new Span<byte>(Encoding.UTF8.GetBytes("{\"Age\" : ,\"Name\" : ''}"));
    public static void Serializer(WritableBuffer wb, Library.Person t)
    {
        var enc = TextEncoder.Utf8;
        wb.Write(span.Slice(0, 9));
        wb.Append(t.Age, enc);
        wb.Write(span.Slice(9, 11));
        wb.Append(t.Name, enc);
        wb.Write(span.Slice(20, 2));
    }
}