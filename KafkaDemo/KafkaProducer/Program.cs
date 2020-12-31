using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入消息内容（默认主题为test,即消息类型)");
  
            using (var producer = new KafkaProducer())
            {
                while (true)
                {
                    string message = Console.ReadLine();
                    try
                    {
                        var result = producer.ProduceAsync("test",
                        new Confluent.Kafka.Message<string, string>() { Key = Guid.NewGuid().ToString(), Value = message })
                         .GetAwaiter().GetResult();
                        //VS2017
                        //Console.WriteLine($"offset:{result.Offset.Value},partition:{result.Partition.Value}");
                        Console.WriteLine("offset:"+result.Offset.Value+",partition:"+result.Partition.Value);
                    }
                    catch (ProduceException<string, string> e)
                    {
                        //VS2017
                        //Console.WriteLine($"失败的消息: {e.Message} [{e.Error.Code}]");
                         Console.WriteLine("失败的消息: "+e.Message+" "+ e.Error.Code.ToString());
                        continue;
                    }              
                }
            }
        }
    }
}
