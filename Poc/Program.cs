using Library;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;

namespace Poc
{
    class Program
    {
        static void Main(string[] args)
        {
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Person { })));

            //var f = new PipelineFactory();
            //f.CreateReader(stream);
            

            Serializer.Deserialize();
        }
    }

}