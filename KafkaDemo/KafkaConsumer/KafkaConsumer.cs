using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    class KafkaConsumer : IDisposable
    {
        private IConsumer<string, string> _consumer;
        public KafkaConsumer(string server = null)
        {
            if (string.IsNullOrEmpty(server))
            {
                server = "localhost:9092";
            }
            var config = new ConsumerConfig
            {
                GroupId = "TestGroupone",
                BootstrapServers = server,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _consumer.Subscribe("test");

        }

        public void Consume(Action<ConsumeResult<string, string>> action = null)
        {
            var consumerResult = _consumer.Consume(TimeSpan.FromSeconds(2));
            action.Invoke(consumerResult);
        }

        public void Dispose()
        {
            _consumer.Dispose();
        }
    }
}
