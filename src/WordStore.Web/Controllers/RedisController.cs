using RedisModels;
using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WordStore.Web.Models;

namespace WordStore.Web.Controllers
{
    public class RedisController : Controller
    {
        RedisClient redisClient = null;
        public RedisController()
        {
            redisClient = new RedisClient("localhost");
        }
        // GET: Redis
        public ActionResult Index()
        {
            var models = new List<RedisKeyViewModels>();

            var keys = redisClient.GetAllKeys();
            foreach (var item in keys)
            {
                models.Add(new RedisKeyViewModels
                {
                    Key = item
                });
            }
            return View(models);
        }
    }
}