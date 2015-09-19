
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RedisAgent
{
    using ServiceStack.Redis;
    using RedisModels;
    using ServiceStack.Redis.Generic;

    class Program
    {
        static void Main(string[] args)
        {

            using (var redisClient = new RedisClient("localhost"))
            {
                while (true)
                {
                    var stopwatch = System.Diagnostics.Stopwatch.StartNew();
                    //Console.WriteLine("ping: " + ping + ", time: " + time);

                    //redisClient.DeleteAll<Counter>();

                    IRedisTypedClient<Counter> redis = redisClient.As<Counter>();

                    //var key = redis.GetAllKeys();

                    var c = redis.GetAndSetValue("the-counter", new Counter());

                    c.Value += 1;

                    redis.GetAndSetValue("the-counter", c);

                    Console.WriteLine("counter: " + c.Value);

                    Thread.Sleep(TimeSpan.FromSeconds(1));
                }
            }
        }
    }
}
