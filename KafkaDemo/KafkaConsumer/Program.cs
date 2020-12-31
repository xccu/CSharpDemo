using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("默认只关注test主题的消息)");
            using (var consumer = new KafkaConsumer())
            {
                while (true)
                {
                    consumer.Consume(a =>
                    {
                        if (a == null)
                        {
                            Console.WriteLine("暂无消息");
                        }
                        else
                        {
                            //VS2017
                            //Console.WriteLine($"Key:{a.Key},Value:{a.Value}");

                            Console.WriteLine("Key:"+a.Key+",Value:"+a.Value);
                        }
                    });
                }
            }
        }

    }
}
