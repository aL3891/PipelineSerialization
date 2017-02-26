using Library;
using System;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

namespace Poc
{
    public class Serializer
    {
        static Span<byte> Age = new Span<byte>(Encoding.UTF8.GetBytes("Age"));
        static Span<byte> Name = new Span<byte>(Encoding.UTF8.GetBytes("Name"));

        public static async Task<Person> Deserialize()//IPipelineReader pipelineReader)
        {

            //ReadableBuffer buffer, workBuffer;

            //var result = await pipelineReader.ReadAsync();
            //buffer = result.Buffer;
            //workBuffer = buffer;
            //ReadCursor cursor;
            //int found;

            //found = SeekExtensions.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)'"');
            //workBuffer = workBuffer.Slice(cursor).Slice(1);
            //found = SeekExtensions.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)'"');

            //var value = workBuffer.Slice(workBuffer.Start, cursor);

            //if (value.Equals(Age))
            //{
            //    found = SeekExtensions.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)' ');
            //    workBuffer = workBuffer.Slice(cursor).Slice(1);
            //    found = SeekExtensions.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)',');
            //    value = workBuffer.Slice(workBuffer.Start, cursor);
            //}
            //else if (value.Equals(Name))
            //{
            //    found = SeekExtensions.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)'"');
            //    workBuffer = workBuffer.Slice(cursor).Slice(1);
            //    found = SeekExtensions.Seek(workBuffer.Start, workBuffer.End, out cursor, (byte)'"');
            //    value = workBuffer.Slice(workBuffer.Start, cursor);
            //}

            //workBuffer = workBuffer.Slice(cursor).Slice(1);




            //pipelineReader.Advance(buffer.End, buffer.End);





            return null;
        }

    }

}