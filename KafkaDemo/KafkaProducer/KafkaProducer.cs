using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaProducer
{
    class KafkaProducer : IDisposable
    {
        private ProducerConfig _config = new ProducerConfig();
        private IProducer<string, string> _producer;
        public KafkaProducer(string server = null)
        {
            if (string.IsNullOrEmpty(server))
            {
                //这里可以添加更多的Kafka集群，比如
                //server=" server ="192.168.1.129:9092,192.168.1.133:9092,192.168.1.134:9092";";                   
                server = "localhost:9092";

            }
            _config.BootstrapServers = server;
            _producer = new ProducerBuilder<string, string>(_config).Build();

        }

        public async Task<DeliveryResult<string, string>> ProduceAsync(string topic, Message<string, string> message)
        {
            return await _producer.ProduceAsync(topic, message);

        }

        public void Dispose()
        {
            _producer.Dispose();
        }
    }
}
