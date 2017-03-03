using Library;
using System;
using System.IO.Pipelines;
using System.Text;

class GeneratedSerializer
{
    Span<byte> s = new Span<byte>(Encoding.UTF8.GetBytes("{\"Age\":\"\", \"Name\":\"\"}"));
    void Serializer(WritableBuffer pipe, Library.Person p)
    {
        pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes("{")));
        pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes("\"Age\" : ")));
        pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes(p.Age.ToString())));
        pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes(",")));
        pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes("\"Name\" : ")));
        pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes("\"\"")));
        pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes(p.Name)));
        pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes("\"\"")));
        pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes("}")));
    }
}