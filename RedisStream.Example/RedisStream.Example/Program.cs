using StackExchange.Redis;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace RedisStream.Example
{
    class Program
    {
        private static string _connstr = "172.16.3.119:6379";
        // private static string _connstr = "172.16.3.119:6379";

        private static string _keyStream = "stream1";
        private static string _nameGrourp = "group1";
        private static string _nameConsumer = "consumer1";

        static async Task Main(string[] args)
        {
            //await StackExchangeRedisStreamConsumer();
            CsRedisStreamConsumer();

            Console.ReadKey();
        }

static async Task StackExchangeRedisStreamConsumer()
{
    Console.WriteLine("StackExchangeRedis StreamConsumer start!");

    var redis = ConnectionMultiplexer.Connect(_connstr);
    var db = redis.GetDatabase();

    try
    {
        ///初始化方式1
        //db.StreamAdd(_keyStream, "name", "message1", "*");
        //db.StreamCreateConsumerGroup(_keyStream, _nameGrourp);

        //方式2
        db.StreamCreateConsumerGroup(_keyStream, _nameGrourp, StreamPosition.NewMessages);
    }
    catch { }

    StreamEntry[] data = null;

    while (true)
    {
        data = db.StreamReadGroup(_keyStream, _nameGrourp, _nameConsumer, ">", count: 1, noAck: true);

        if (data?.Length > 0 == true)
        {
            Console.WriteLine($"message-id:{data.FirstOrDefault().Id}");

            data.FirstOrDefault().Values.ToList().ForEach(c =>
            {
                Console.WriteLine($"    {c.Name}:{c.Value}");
            });

            db.StreamAcknowledge(_keyStream, _nameGrourp, data.FirstOrDefault().Id);
        }
    }
}

        static async Task CsRedisStreamConsumer()
        {
            Console.WriteLine("CsRedis StreamConsumer start!");

            var csRedis = new CSRedis.CSRedisClient(_connstr);
            csRedis.XAdd(_keyStream, "*", ("name", "message1"));

            try
            {
                csRedis.XGroupCreate(_keyStream, _nameGrourp);
            }
            catch { }

            (string key, (string id, string[] items)[] data)[] product;
            (string Pid, string Platform, string Time) data = (null, null, null);

            while (true)
            {
                try
                {
                    product = csRedis.XReadGroup(_nameGrourp, _nameConsumer, 1, 10000, (_keyStream, ">"));
                    if (product?.Length > 0 == true && product[0].data?.Length > 0 == true)
                    {
                        Console.WriteLine($"message-id:{product.FirstOrDefault().data.FirstOrDefault().id}");

                        product.FirstOrDefault().data.FirstOrDefault().items.ToList().ForEach(value =>
                        {
                            Console.WriteLine($"    {value}");
                        });

                        //csRedis.XAck(_keyStream, _nameGrourp, product[0].data[0].id);
                    }
                }
                catch (Exception)
                {
                    //throw;
                }
            }
        }
    }
}