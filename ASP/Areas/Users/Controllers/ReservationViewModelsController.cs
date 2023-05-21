using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.Data;
using ASP.Models;

namespace ASP.Areas.Users.Controllers
{
    [Area("Users")]
    public class ReservationViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users/ReservationViewModels
        public async Task<IActionResult> Index()
        {
              return _context.Reservations != null ? 
                          View(await _context.Reservations.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Reservations'  is null.");
        }

        // GET: Users/ReservationViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservationViewModel = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservationViewModel == null)
            {
                return NotFound();
            }

            return View(reservationViewModel);
        }

        // GET: Users/ReservationViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/ReservationViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Phone,ReservationDate,ReservationDateEnd")] ReservationViewModel reservationViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservationViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservationViewModel);
        }

        // GET: Users/ReservationViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservationViewModel = await _context.Reservations.FindAsync(id);
            if (reservationViewModel == null)
            {
                return NotFound();
            }
            return View(reservationViewModel);
        }

        // POST: Users/ReservationViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Phone,ReservationDate,ReservationDateEnd")] ReservationViewModel reservationViewModel)
        {
            if (id != reservationViewModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservationViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationViewModelExists(reservationViewModel.ID))
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
            return View(reservationViewModel);
        }

        // GET: Users/ReservationViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reservations == null)
            {
                return NotFound();
            }

            var reservationViewModel = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ID == id);
            if (reservationViewModel == null)
            {
                return NotFound();
            }

            return View(reservationViewModel);
        }

        // POST: Users/ReservationViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reservations == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Reservations'  is null.");
            }
            var reservationViewModel = await _context.Reservations.FindAsync(id);
            if (reservationViewModel != null)
            {
                _context.Reservations.Remove(reservationViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationViewModelExists(int id)
        {
          return (_context.Reservations?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
