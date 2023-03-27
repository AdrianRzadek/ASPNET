using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.Data;
using ASP.Models;

namespace ASP.Controllers
{
    public class Vehicle_Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public Vehicle_Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vehicle_
        public async Task<IActionResult> Index()
        {
              return _context.Vehicles != null ? 
                          View(await _context.Vehicles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
        }

        // GET: Vehicle_/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle_ = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vehicle_ == null)
            {
                return NotFound();
            }

            return View(vehicle_);
        }

        // GET: Vehicle_/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicle_/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description")] Vehicle_ vehicle_)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle_);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle_);
        }

        // GET: Vehicle_/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle_ = await _context.Vehicles.FindAsync(id);
            if (vehicle_ == null)
            {
                return NotFound();
            }
            return View(vehicle_);
        }

        // POST: Vehicle_/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Description")] Vehicle_ vehicle_)
        {
            if (id != vehicle_.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle_);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Vehicle_Exists(vehicle_.ID))
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
            return View(vehicle_);
        }

        // GET: Vehicle_/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicle_ = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.ID == id);
            if (vehicle_ == null)
            {
                return NotFound();
            }

            return View(vehicle_);
        }

        // POST: Vehicle_/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
            }
            var vehicle_ = await _context.Vehicles.FindAsync(id);
            if (vehicle_ != null)
            {
                _context.Vehicles.Remove(vehicle_);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Vehicle_Exists(int id)
        {
          return (_context.Vehicles?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
