using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcessWorkOrders.Context;
using ProcessWorkOrders.Models;

namespace ProcessWorkOrders.Controllers
{
    public class WorkOrderController : Controller
    {
        private readonly WorkOrderDbContext _context;
        public WorkOrderController(WorkOrderDbContext context)
        {
            _context = context;
        }
        // GET: WorkOrderController
        public ActionResult Index()
        {
            var workOrders = _context.WorkOrders.ToList();
            return View(workOrders);
        }

        // GET: WorkOrderController/Details/5
        public ActionResult Details(int id)
        {
            var order = _context.WorkOrders.Include(_=>_.Rolls).Where(_ => _.WorkOrderNumber == id).SingleOrDefault();
            if (order==null)
            {
                
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: WorkOrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkOrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WorkOrder workOrder)
        {
            if (workOrder != null)
            {
                try
                {
                    _context.Add(workOrder);
                    _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else return View();
        }

        // GET: WorkOrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WorkOrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WorkOrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var workOrder = _context.WorkOrders.SingleOrDefault(_ => _.WorkOrderNumber == id);
            _context.Remove(workOrder);
            _context.SaveChangesAsync();
            return View();
        }

        // POST: WorkOrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
