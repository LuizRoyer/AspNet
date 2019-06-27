using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class ProductsController : Controller
    {
        UnitOfWork.UnitOfWorkApp _Uow;

        public ProductsController()
        {
            _Uow = new UnitOfWork.UnitOfWorkApp();
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(_Uow.ProductRepository.FindAll());
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View(_Uow.ProductRepository.FinById(id));
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(Produts produts)
        {
            try
            {
                // TODO: Add insert logic here

                _Uow.ProductRepository.Add(produts);
                _Uow.Commit();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_Uow.ProductRepository.FinById(id));
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Produts produts)
        {
            try
            {
                // TODO: Add update logic here
                _Uow.ProductRepository.Edit(produts);
                _Uow.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_Uow.ProductRepository.FinById(id));
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Produts produts)
        {
            try
            {
                // TODO: Add delete logic here

                _Uow.ProductRepository.Remove(_Uow.ProductRepository.FinById(id));
                _Uow.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
