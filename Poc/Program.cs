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
        private static PipeFactory _pipelineFactory;
        private static IPipe _pipe;

        static void Main(string[] args)
        {
            _pipelineFactory = new PipeFactory();
            _pipe = _pipelineFactory.Create();
            var writableBuffer = _pipe.Writer.Alloc(3000);
            ModelSerializer.Serialize(writableBuffer, BigModels.About100Fields);

            //var json = JsonConvert.SerializeObject(new Person { });
            //var bytes = Encoding.UTF8.GetBytes(json);

            //Serializer.Deserialize(_pipelineFactory.CreateReader(new MemoryStream(bytes))).Wait();
        }
    }

}