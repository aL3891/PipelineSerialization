using Newtonsoft.Json;
using PipelineSerialization.Poc;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Person { })));

            var f = new PipelineFactory();
            f.CreateReader(stream);

            Serializer.Deserialize(f.CreateReader(stream));


        }
    }
}
