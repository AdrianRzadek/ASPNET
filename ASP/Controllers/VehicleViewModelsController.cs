using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP.Data;
using ASP.Models;
using AutoMapper;

namespace ASP.Controllers
{
    public class VehicleViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VehicleViewModelsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: VehicleViewModels
        public async Task<IActionResult> Index()
        {
              return _context.Vehicles != null ? 
                          View(await _context.Vehicles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
        }

        // GET: VehicleViewModels/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicleViewModel = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleViewModel == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<VehicleViewModel>(vehicleViewModel));
        }

        // GET: VehicleViewModels/Create
        
        public IActionResult Create()
        {
            return View();
        }
       
        
        // POST: VehicleViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Description")] VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(_mapper.Map<VehicleViewModel>(vehicleViewModel));
        }

        // GET: VehicleViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicleViewModel = await _context.Vehicles.FindAsync(id);
            if (vehicleViewModel == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<VehicleViewModel>(vehicleViewModel));
        }

        // POST: VehicleViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,VehicleName,VehicleMark,VehicleColor,VehiclePrice")] VehicleViewModel vehicleViewModel)
        {
            if (id != vehicleViewModel.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleViewModelExists(vehicleViewModel.VehicleId))
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
            return View(_mapper.Map<VehicleViewModel>(vehicleViewModel));
        }

        // GET: VehicleViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicles == null)
            {
                return NotFound();
            }

            var vehicleViewModel = await _context.Vehicles
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleViewModel == null)
            {
                return NotFound();
            }

             return View(_mapper.Map<VehicleViewModel>(vehicleViewModel));
        }

        // POST: VehicleViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Vehicles'  is null.");
            }
            var vehicleViewModel = await _context.Vehicles.FindAsync(id);
            if (vehicleViewModel != null)
            {
                _context.Vehicles.Remove(vehicleViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleViewModelExists(int id)
        {
          return (_context.Vehicles?.Any(e => e.VehicleId == id)).GetValueOrDefault();
        }
    }
}
