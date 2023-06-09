using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.AspNetCore.Identity;
using ASP.Data;
using ASP.Models;
using Microsoft.EntityFrameworkCore;
using ASP.Repository;

namespace ASP.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {



        private readonly ApplicationDbContext _context;
       // private readonly ReservationRepository _reservationRepository;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
           

        }



        [Route("admin")]
        public IActionResult Index()
        {
            return View();
        }

        /*
        public ActionResult ChangeStatus(int id)
        {
            return View(id);
        }

        public ActionResult ChangeStatus(int id, string status)
        {
          
            try
            {
                return RedirectToAction(nameof("Index"));
            }
            catch
            {
                return View();
            }
        }

        */

        [Route("admin/details")]
        public IActionResult Details()
        {
            return View();
        }
       [Route("admin/ReservationList")]
        public async Task<IActionResult> ReservationList()
        {
            return _context.Reservations != null ?
                        View(_context.Reservations.ToList()) :
                        Problem("Entity set 'ApplicationDbContext.Reservations'  is null.");
        }

        [Route("admin/Edit")]

        // GET: HomeController/Edit/5
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

        // POST: Admin/ReservationViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Phone,VehicleId,ReservationDate,ReservationDateEnd,Status")] ReservationViewModel reservationViewModel)
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
                return RedirectToAction(nameof(ReservationList));
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
        [Route("admin/delete")]
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
