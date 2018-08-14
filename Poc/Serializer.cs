using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Poc
{
	public static partial class Serializer2
	{
		private const byte ByteLF = (byte)'{';


		public static bool Deserialize(ReadResult readResult,  Person t, out SequencePosition consumed, out SequencePosition examined)
		{


			var buffer = readResult.Buffer;
			consumed = readResult.Buffer.Start;
			examined = readResult.Buffer.End;
			ReadOnlySpan<byte> value;
			var span = readResult.Buffer.First.Span;

			var lineIndex = span.IndexOf((byte)'{');
			if (lineIndex < 0)
				return false;

			span = span.Slice(0, lineIndex + 1);

			lineIndex = span.IndexOf((byte)'"');
			if (lineIndex < 0)
				return false;
			
			span = span.Slice(0, lineIndex + 1);

			lineIndex = span.IndexOf((byte)'"');
			if (lineIndex < 0)
				return false;
			
			value = span.Slice(0, lineIndex + 1);
			span = span.Slice(0, lineIndex + 1);


			if (value.SequenceEqual(new Span<byte>(Encoding.UTF8.GetBytes("Age"))))
			{
			}
			if (value.SequenceEqual(new Span<byte>(Encoding.UTF8.GetBytes("Name"))))
			{
			}

			return true;
		}

		public static void GetNextToken(Span<byte> span, out int start, out int length)
		{
			start = 0;
			length = 0;


		}

	}

	public partial class Serializer
	{
		static byte[] Age = Encoding.UTF8.GetBytes("Age");
		static byte[] Name = Encoding.UTF8.GetBytes("Name");
		static byte[] s = Encoding.UTF8.GetBytes("{\"Age\":\"\", \"Name\":\"\"}");

		public static void Serialize(PipeWriter pipe, Person p)
		{
			pipe.Write(s.AsSpan().Slice(0, 1));
			pipe.Write(Name.AsSpan());
		}

		public static async Task<Person> Deserialize(PipeReader reader)
		{
			ReadResult result = await reader.ReadAsync();
			ReadOnlySequence<byte> buffer = result.Buffer;
			SequencePosition? position = null;

			position = buffer.PositionOf( (byte)'"');
			buffer = buffer.Slice(position.Value).Slice(1);
			position = buffer.PositionOf( (byte)'"');

			var value = buffer.Slice(buffer.Start, position.Value);

			if (value.Equals(Age))
			{
				position = buffer.PositionOf( (byte)' ');
				buffer = buffer.Slice(position.Value).Slice(1);
				position = buffer.PositionOf( (byte)',');
				value = buffer.Slice(buffer.Start, position.Value);
			}
			else if (value.Equals(Name))
			{
				position = buffer.PositionOf( (byte)'"');
				buffer = buffer.Slice(position.Value).Slice(1);
				position = buffer.PositionOf( (byte)'"');
				value = buffer.Slice(buffer.Start, position.Value);
			}
			//pipelineReader.Advance(buffer.End, buffer.End);
			return null;
		}
	}
}