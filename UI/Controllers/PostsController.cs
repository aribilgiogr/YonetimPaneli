using Business.Services;
using Core.Abstracts.IServices;
using Core.Concrete.DTOs;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IPostService service;
        public PostsController()
        {
            service = new PostService();
        }
        // GET: Posts
        public ActionResult Index()
        {
            return View(service.GetPostList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var post = service.GetPostDetail((int)id);
            if (post == null)
                return HttpNotFound();

            return View(post);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NewPostDto model, HttpPostedFileBase file)
        {
            string[] file_ext = { ".jpg", ".png", ".bmp" };
            if (file != null && file.ContentLength > 0)
            {
                if (file_ext.Contains(Path.GetExtension(file.FileName).ToLower()))
                {

                }
                else
                {
                    ModelState.AddModelError("CoverImageUrl", "Dosya uzantısı geçersiz! (\".jpg\", \".png\", \".bmp\")");
                }
            }
            else
            {
                ModelState.AddModelError("CoverImageUrl", "Dosya yükleme başarısız!");
            }

            if (ModelState.IsValid)
            {
                model.AuthorId = User.Identity.GetUserId();
                service.CreatePost(model);
                return RedirectToAction("index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var post = service.GetPostDetail(id);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UpdatePostDto model)
        {
            if (ModelState.IsValid)
            {
                service.UpdatePost(model);
                return RedirectToAction("index");
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var post = service.GetPostDetail(id);
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            service.DeletePost(id, User.Identity.GetUserId());
            return RedirectToAction("index");
        }
    }
}