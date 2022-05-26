using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProcessWorkOrders.Context;
using ProcessWorkOrders.Models;

namespace ProcessWorkOrders.Controllers
{
    public class RollsController : Controller
    {
        private readonly WorkOrderDbContext _context;

        public RollsController(WorkOrderDbContext context)
        {
            _context = context;
        }

        // GET: Rolls?workOrderNumber=5
        public IActionResult Index(int? workOrderNumber)
        {
            if(workOrderNumber!=null)
            {
            var rolls = _context.WorkOrders.Include(_ => _.Rolls).SingleOrDefault(_ => _.WorkOrderNumber == workOrderNumber);
            return View(rolls.Rolls);
            }
            else
            {
                return View(new List<Roll>());
            }
        }

        // GET: Rolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roll = await _context.Rolls
                .FirstOrDefaultAsync(m => m.Number == id);
            if (roll == null)
            {
                return NotFound();
            }

            return View(roll);
        }

        // GET: Rolls/Create
        public IActionResult Create()
        {
            ViewData["WorkOrder"] = 2;
            return View();
        }

        // POST: Rolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Weight,Number,Width,Length,QuantityPer,Gauge,Operator,WorkOrderWorkOrderNumber")] Roll roll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roll);
        }

        // GET: Rolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roll = await _context.Rolls.FindAsync(id);
            if (roll == null)
            {
                return NotFound();
            }
            return View(roll);
        }

        // POST: Rolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Number,Width,Length,QuantityPer,Gauge,Operator")] Roll roll)
        {
            if (id != roll.Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RollExists(roll.Number))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(roll);
        }

        // GET: Rolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roll = await _context.Rolls
                .FirstOrDefaultAsync(m => m.Number == id);
            if (roll == null)
            {
                return NotFound();
            }

            return View(roll);
        }

        // POST: Rolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roll = await _context.Rolls.FindAsync(id);
            _context.Rolls.Remove(roll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RollExists(int id)
        {
            return _context.Rolls.Any(e => e.Number == id);
        }
    }
}
