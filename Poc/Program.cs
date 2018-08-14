using Library;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Pipelines;
using System.IO.Pipelines.Samples.Models;
using System.Text;

namespace Poc
{
    class Program
    {
        private static Pipe _pipe;

        static void Main(string[] args)
        {
            _pipe = new Pipe();
			Serializer.Serialize(_pipe.Writer, new Person { });
            //var json = JsonConvert.SerializeObject(new Person { });
            //var bytes = Encoding.UTF8.GetBytes(json);
            //Serializer.Deserialize(_pipelineFactory.CreateReader(new MemoryStream(bytes))).Wait();
        }
    }

}