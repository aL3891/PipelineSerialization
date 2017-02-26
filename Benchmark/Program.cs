using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Library;
using Newtonsoft.Json;
using Poc;
using System;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<DeserializerBenchmark>();
        }
    }

    public class SerializerBenchmark
    {
        Person person;
        IPipeWriter pipe;

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
        public Task Naive()
        {
            return Serializer.Serialize(pipe, person);
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