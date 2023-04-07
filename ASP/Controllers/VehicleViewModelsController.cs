
using Microsoft.AspNetCore.Mvc;
using ASP.Data;
using ASP.Models;
using ASP.Repository;
using ASP.App_Start;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ASP.Controllers
{
    public class VehicleViewModelsController : Microsoft.AspNetCore.Mvc.Controller
    {

        private readonly ApplicationDbContext _context;
        private IMapper _mapper;
      

        public VehicleViewModelsController(ApplicationDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
    
        }



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

            return View(_mapper.Map<VehicleViewModelDTO>(vehicle_));

        }

        // GET: VehicleViewModels/Details/5

    }
    }