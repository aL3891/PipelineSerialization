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
            //var summary = BenchmarkRunner.Run<BigClassSerializer>();
            var summary = BenchmarkRunner.Run<SmallClassSerializer>();
            Console.ReadLine();
        }
    }

    [Config(typeof(CoreConfig))]
    public class BigClassSerializer
    {       
       private Pipe _pipe;
        private MemoryStream mem;
        private JsonSerializer json;
        private JsonTextWriter writer;
        private Model model;

        [IterationSetup]
        public void Setup()
        {
			_pipe = new Pipe();
            mem = new MemoryStream();
            json = new JsonSerializer();
            writer = new JsonTextWriter(new StreamWriter(mem));
            model = BigModels.About100Fields;
        }

        //[Benchmark(Baseline = true)]
        //public void Jsondotnet()
        //{
        //    mem.Position = 0;
        //    json.Serialize(writer, model);
        //}

        [Benchmark]
        public void Generated()
        {
            //ModelSerializer.Serialize(writableBuffer, model);
        }
    }

    [Config(typeof(CoreConfig))]
    public class SmallClassSerializer
    {
        Person person;
        private Pipe _pipe;
        private MemoryStream mem;
        private JsonSerializer json;
        private JsonTextWriter writer;

        [IterationSetup]
        public void Setup()
        {
            _pipe = new Pipe();
            mem = new MemoryStream();
            json = new JsonSerializer();
            writer = new JsonTextWriter(new StreamWriter(mem));
            person = new Person { Age = 23, Name = "rune" };
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
            //PersonSerializer.Serialize(writableBuffer, person);
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