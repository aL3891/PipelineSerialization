using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;
using Library;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Pipelines;
using System.IO.Pipelines.Samples.Models;
using System.Text;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<BigClassSerializer>();
            Console.ReadLine();
        }
    }

    [Config(typeof(CoreConfig))]
    public class BigClassSerializer
    {
        
        private IPipe _pipe;
        private PipeFactory _pipelineFactory;
        private MemoryStream mem;
        private JsonSerializer json;
        private JsonTextWriter writer;
        private WritableBuffer writableBuffer;
        private Model model;

        [Setup]
        public void Setup()
        {
            _pipelineFactory = new PipeFactory();
            _pipe = _pipelineFactory.Create();
            mem = new MemoryStream();
            json = new JsonSerializer();
            writer = new JsonTextWriter(new StreamWriter(mem));
            model = BigModels.About100Fields;
            writableBuffer = _pipe.Writer.Alloc(100);
        }

        [Benchmark(Baseline = true)]
        public void Jsondotnet()
        {
            mem.Position = 0;
            json.Serialize(writer, model);
        }

        [Benchmark]
        public void Generated()
        {
            ModelSerializer.Serializer(writableBuffer, model);
        }
    }

    [Config(typeof(CoreConfig))]
    public class SmallClassSerializer
    {
        Person person;
        private IPipe _pipe;
        private PipeFactory _pipelineFactory;
        private MemoryStream mem;
        private JsonSerializer json;
        private JsonTextWriter writer;
        private WritableBuffer writableBuffer;

        [Setup]
        public void Setup()
        {
            _pipelineFactory = new PipeFactory();
            _pipe = _pipelineFactory.Create();
            mem = new MemoryStream();
            json = new JsonSerializer();
            writer = new JsonTextWriter(new StreamWriter(mem));
            person = new Person { Age = 23, Name = "rune" };
            writableBuffer = _pipe.Writer.Alloc(100);
        }

        [Benchmark(Baseline = true)]
        public void Jsondotnet()
        {
            mem.Position = 0;
            json.Serialize(writer, person);
        }

        [Benchmark]
        public void Generated()
        {
            PersonSerializer.Serializer(writableBuffer, person);
        }
    }

    public class DeserializerBenchmark
    {
        string json;
        byte[] bytes;

        public DeserializerBenchmark()
        {
            json = JsonConvert.SerializeObject(new Person { });
            bytes = Encoding.UTF8.GetBytes(json);
        }

        [Benchmark]
        public void Jsondotnet()
        {
            JsonConvert.DeserializeObject<Person>(json);
        }

        [Benchmark]
        public void Naive()
        {
            JsonConvert.DeserializeObject<Person>(json);
        }
    }
}