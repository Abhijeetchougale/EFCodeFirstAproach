using PagedList;
using ProductAndCategory.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductAndCategory.Controllers
{
    public class ProductController : Controller
    {
        ProdDbContext pd= new ProdDbContext();
        
        public ActionResult Index(int? page)
        {
            int pagesize = 10;
            int pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            List<Product> list = pd.Products.ToList();
            IPagedList<Product> prod = list.ToPagedList(pageindex, pagesize);
           


            return View(prod);
        }
        [HttpGet]
        public ActionResult create()
        {
            ViewBag.CategoryId = new SelectList(pd.Categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult create(Product p)
        {
            if (ModelState.IsValid)
            {
                pd.Products.Add(p);
                pd.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(pd.Categories, "CategoryId", "CategoryName", p.CategoryId);
            return View(p);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var row = pd.Products.Where(model => model.ProductId == id).FirstOrDefault();
            pd.SaveChanges();

            return View(row);
        }
        [HttpPost]
        public ViewResult Edit(Product p)
        {
            pd.Entry(p).State = EntityState.Modified;
            pd.SaveChanges();
            return View();


        }
        [HttpGet]
        public ActionResult delete(int id)
        {
            if(id>0)
            { 
            var row = pd.Products.Where(model => model.ProductId == id).FirstOrDefault();
                if(row != null)
                {
                    pd.Entry(row).State = EntityState.Deleted;
                    int a=pd.SaveChanges();
                    if(a>0)
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
            var row = pd.Products.Where(model => model.ProductId == id).FirstOrDefault();
            return View(row);
        }


    }
}