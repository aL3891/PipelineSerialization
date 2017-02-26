using Library;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Pipelines;
using System.Text;

namespace Poc
{
    class Program
    {
        static void Main(string[] args)
        {


            var f = new PipeFactory();
            //f.CreateReader(stream);

            var json = JsonConvert.SerializeObject(new Person { });
            var bytes = Encoding.UTF8.GetBytes(json);

            Serializer.Deserialize(f.CreateReader(new MemoryStream(bytes))).Wait();
        }
    }

}