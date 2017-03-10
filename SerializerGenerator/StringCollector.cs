using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SerializerGenerator
{
    public class StringCollector
    {
        Dictionary<string, int> lengths = new Dictionary<string, int>();
        public Dictionary<string, int> indecies = new Dictionary<string, int>();
        public List<string> strings = new List<string>();

        public Tuple<int, int> GetOffset(string value)
        {
            if (!lengths.ContainsKey(value))
            {
                strings.Add(value);
                var b = Encoding.UTF8.GetBytes(value);
                indecies[value] = lengths.Values.Sum();
                lengths[value] = b.Length;

            }

            return Tuple.Create(indecies[value], lengths[value]);
        }

        public string GetRawString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var str in strings)
                sb.Append(str);

            return sb.ToString();
        }

        public string GetBase64String()
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(GetRawString()));
        }
    }
}