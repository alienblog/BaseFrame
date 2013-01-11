using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facade.Common;
using Facade.Products;
using Model.Products;

namespace Web.Controllers.Products
{
    public class ProductController : Controller
    {
        //
        // GET: Product/Index

        public ActionResult Index()
        {
            LogFacade logFacade=new LogFacade();
            ProductFacade productFacade=new ProductFacade();
            List<ProductList> productList=new List<ProductList>();
            try
            {
                productList = productFacade.GetAllProducts();
            }
            catch (Exception e)
            {

                logFacade.WriteLog("ProductController.Index()异常", e);
            }
             
            return View("~/Views/Products/Index.cshtml",productList);
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Product/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
