using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using Library;
using Newtonsoft.Json;
using Poc;
using System;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SerializerBenchmark>(ManualConfig.Create(DefaultConfig.Instance).With(new MemoryDiagnoser()));
            Console.ReadLine();
        }
    }

    public class SerializerBenchmark
    {
        Person person;
        private IPipe _pipe;
        private PipeFactory _pipelineFactory;

        [Setup]
        public void Setup()
        {
            _pipelineFactory = new PipeFactory();
            _pipe = _pipelineFactory.Create();
        }

        public SerializerBenchmark()
        {
            person = new Person { };
            
            
        }

        [Benchmark]
        public void Jsondotnet()
        {
            JsonConvert.SerializeObject(person);
        }


        [Benchmark]
        public async Task  Naive()
        {
            var writableBuffer = _pipe.Writer.Alloc(100);
            Serializer.Serialize(writableBuffer, person);
            await writableBuffer.FlushAsync();
        }
    }

    //public class DeserializerBenchmark
    //{
    //    string json;
    //    byte[] bytes;

    //    public DeserializerBenchmark()
    //    {
    //        json = JsonConvert.SerializeObject(new Person { });
    //        bytes = Encoding.UTF8.GetBytes(json);
    //    }

    //    [Benchmark]
    //    public void Jsondotnet()
    //    {
    //        JsonConvert.DeserializeObject<Person>(json);
    //    }

    //    [Benchmark]
    //    public void Naive()
    //    {
    //        JsonConvert.DeserializeObject<Person>(json);
    //    }
    //}
}