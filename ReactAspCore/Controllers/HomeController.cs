
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ReactAspCore.Models;

namespace ReactDemo.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<CommentModel> _comments;

        static HomeController()
        {
            _comments = new List<CommentModel>
            {
                new CommentModel
                {
                    Id = 1,
                    Author = "Hanamichi",
                    Text = "Best basketball player in Japan"
                },
                new CommentModel
                {
                    Id = 2,
                    Author = "Ronaldo",
                    Text = "ManU"
                },
                new CommentModel
                {
                    Id = 3,
                    Author = "Messi",
                    Text = "#7 qua bong vang"
                },
            };
        }

        public ActionResult Index()
        {
            return View(_comments);
        }
        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }
        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            // Create a fake ID for this comment
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }
    }
}
