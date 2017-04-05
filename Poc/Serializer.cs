using Library;
using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

namespace Poc
{
    public static partial class Serializer2
    {
        static Span<byte> span = new Span<byte>(Encoding.UTF8.GetBytes(""));
        private const byte ByteLF = (byte)'{';


        public static bool Deserialize(ReadableBuffer buffer, Library.Person t, out ReadCursor consumed, out ReadCursor examined)
        {
            consumed = buffer.Start;
            examined = buffer.End;
            Span<byte> value;
            var span = buffer.First.Span;

            var lineIndex = span.IndexOfVectorized((byte)'{');
            if (lineIndex < 0)
                return false;

            consumed = buffer.Move(consumed, lineIndex + 1);
            span = span.Slice(0, lineIndex + 1);


            lineIndex = span.IndexOfVectorized((byte)'"');
            if (lineIndex < 0)
                return false;

            consumed = buffer.Move(consumed, lineIndex + 1);
            span = span.Slice(0, lineIndex + 1);


            lineIndex = span.IndexOfVectorized((byte)'"');
            if (lineIndex < 0)
                return false;

            consumed = buffer.Move(consumed, lineIndex + 1);
            value = span.Slice(0, lineIndex + 1);
            span = span.Slice(0, lineIndex + 1);
            

            if (value.Equals(new Span<byte>(Encoding.UTF8.GetBytes("Age"))))
            {
            }
            if (value.Equals(new Span<byte>(Encoding.UTF8.GetBytes("Name"))))
            {
            }

            return true;
        }

        public static void GetNextToken(Span<byte> span, out int start, out int length) {
            start = 0;
            length = 0;

            span.try

        }

    }

    public partial class Serializer
    {
        static Span<byte> Age = new Span<byte>(Encoding.UTF8.GetBytes("Age"));
        static Span<byte> Name = new Span<byte>(Encoding.UTF8.GetBytes("Name"));
        static Span<byte> s = new Span<byte>(Encoding.UTF8.GetBytes("{\"Age\":\"\", \"Name\":\"\"}"));

        public static void Serialize(WritableBuffer pipe, Person p)
        {
            pipe.Write(s.Slice(0, 1));
            pipe.Write(new Span<byte>(Encoding.UTF8.GetBytes("Name")));
        }

        public static async Task<Person> Deserialize(ReadableBuffer buffer)
        {

            ReadableBuffer workBuffer = buffer;


            ReadCursor cursor;
            int found;

            found = ReadCursorOperations.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)'"');
            workBuffer = workBuffer.Slice(cursor).Slice(1);
            found = ReadCursorOperations.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)'"');

            var value = workBuffer.Slice(workBuffer.Start, cursor);

            if (value.Equals(Age))
            {
                found = ReadCursorOperations.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)' ');
                workBuffer = workBuffer.Slice(cursor).Slice(1);
                found = ReadCursorOperations.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)',');
                value = workBuffer.Slice(workBuffer.Start, cursor);
            }
            else if (value.Equals(Name))
            {
                found = ReadCursorOperations.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)'"');
                workBuffer = workBuffer.Slice(cursor).Slice(1);
                found = ReadCursorOperations.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)'"');
                value = workBuffer.Slice(workBuffer.Start, cursor);
            }

            workBuffer = workBuffer.Slice(cursor).Slice(1);
            //pipelineReader.Advance(buffer.End, buffer.End);





            return null;
        }

    }


}