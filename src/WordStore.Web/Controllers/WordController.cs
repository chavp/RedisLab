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
    public class WordController : Controller
    {
         RedisClient redisClient = null;
         public WordController()
        {
            redisClient = new RedisClient("localhost");
        }

        // GET: Word
        public ActionResult Index()
        {
            var models = new List<WordViewModels>();

            var wordRepo = redisClient.As<Word>();

            var words = wordRepo.GetAll();
            foreach (var word in words)
            {
                models.Add(new WordViewModels
                {
                    Id = word.Id,
                    Value = word.Value
                });
            }

            return View(models);
        }

        public ActionResult Delete(long id)
        {
            var wordRepo = redisClient.As<Word>();

            wordRepo.DeleteById(id);

            TempData["alert"] = new AlertMessage
            {
                Type = "alert-success",
                Message = "Delete successfully.",
                Title = "Well done!"
            };

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Save(WordViewModels saveVM)
        {
            var wordRepo = redisClient.As<Word>();

            var target = wordRepo.GetById(saveVM.Id);
            target.Value = saveVM.Value;

            wordRepo.Store(target);

            TempData["alert"] = new AlertMessage
            {
                Type = "alert-success",
                Message = "Save successfully.",
                Title = "Well done!"
            };

            return RedirectToAction("Index");
        }
    }
}