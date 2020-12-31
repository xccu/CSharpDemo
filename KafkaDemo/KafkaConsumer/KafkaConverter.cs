using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaConsumer
{
    //public class KafkaConverter : IDeserializer<object>
    //{/// <summary>
    //    /// 反序列化字节数据成实体数据
    //    /// </summary>
    //    /// <param name="data"></param>
    //    /// <param name="context"></param>
    //    /// <returns></returns>
    //    public object Deserialize(System.ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    //    {
    //        if (isNull) return null;

    //        var json = Encoding.UTF8.GetString(data.ToArray());
    //        try
    //        {
    //            return JsonConvert.DeserializeObject(json);
    //        }
    //        catch
    //        {
    //            return json;
    //        }
    //    }
    //}
}
