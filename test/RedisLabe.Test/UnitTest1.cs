using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RedisLabe.Test
{
    using ServiceStack;
    using ServiceStack.Redis;
    using RedisModels;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var redisClient = new RedisClient("localhost"))
            {
                //redisClient.DeleteAll<Word>();

                var repoWord = redisClient.As<Word>();
                //repoWord.SetSequence(0);


                var dhing = new Word(repoWord.GetNextSequence())
                {
                    Value = "dhing"
                };

                repoWord.Store(dhing);

            }
        }
    }
}
