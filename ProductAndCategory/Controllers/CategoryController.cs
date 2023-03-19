using ProductAndCategory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductAndCategory.Controllers
{
    public class CategoryController : Controller
    {
        ProdDbContext pd = new ProdDbContext();
        // GET: Product
        public ActionResult Index()
        {
            var data = pd.Categories.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult create(Category c)
        {
            pd.Categories.Add(c);
            pd.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var row = pd.Categories.Where(model => model.CategoryId == id).FirstOrDefault();
            pd.SaveChanges();

            return View(row);
        }
        [HttpPost]
        public ViewResult Edit(Category c)
        {
            pd.Entry(c).State = EntityState.Modified;
            pd.SaveChanges();


            return View();
        }
        [HttpGet]
        public ActionResult delete(int id)
        {
            if (id > 0)
            {
                var row = pd.Categories.Where(model => model.CategoryId == id).FirstOrDefault();
                if (row != null)
                {
                    pd.Entry(row).State = EntityState.Deleted;
                    int a = pd.SaveChanges();
                    if (a > 0)
                    {
                        TempData["delete"] = "<script>alert('data deleted')</script>";
                    }
                    else
                    {
                        TempData["delete"] = "<script>alert('data not deleted')</script>";
                    }
                }
            }
            return RedirectToAction("index");

        }
       
        public ActionResult Details(int id)
        {
            var row = pd.Categories.Where(model=>model.CategoryId==id).FirstOrDefault();
            return View(row);
        }
    }
}