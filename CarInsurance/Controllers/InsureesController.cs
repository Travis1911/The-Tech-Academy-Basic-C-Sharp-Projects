using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarInsurance.Data;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class InsureesController : Controller
    {
        private readonly InsuranceContext _context;

        public InsureesController(InsuranceContext context)
        {
            _context = context;
        }

        // Quote Calculation Method
        private decimal CalculateQuote(Insuree insuree)
        {
            decimal quote = 50;

            // Calculate age
            int age = DateTime.Today.Year - insuree.DateOfBirth.Year;

            if (insuree.DateOfBirth.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            // Age rules
            if (age <= 18)
            {
                quote += 100;
            }
            else if (age >= 19 && age <= 25)
            {
                quote += 50;
            }
            else
            {
                quote += 25;
            }

            // Car year rules
            if (insuree.CarYear < 2000)
            {
                quote += 25;
            }

            if (insuree.CarYear > 2015)
            {
                quote += 25;
            }

            // Porsche rules
            if (insuree.CarMake.ToLower() == "porsche")
            {
                quote += 25;

                if (insuree.CarModel.ToLower() == "911 carrera")
                {
                    quote += 25;
                }
            }

            // Speeding tickets
            quote += insuree.SpeedingTickets * 10;

            // DUI
            if (insuree.DUI)
            {
                quote *= 1.25m;
            }

            // Full Coverage
            if (insuree.CoverageType.ToLower() == "full")
            {
                quote *= 1.50m;
            }

            return quote;
        }

        // GET: Insurees
        public async Task<IActionResult> Index()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        // GET: Insurees/Admin
        public async Task<IActionResult> Admin()
        {
            return View(await _context.Insurees.ToListAsync());
        }

        // GET: Insurees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);

            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // GET: Insurees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insurees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")]
            Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree);

                _context.Add(insuree);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(insuree);
        }

        // GET: Insurees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees.FindAsync(id);

            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // POST: Insurees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            int id,
            [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")]
            Insuree insuree)
        {
            if (id != insuree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    insuree.Quote = CalculateQuote(insuree);

                    _context.Update(insuree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsureeExists(insuree.Id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(insuree);
        }

        // GET: Insurees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insuree = await _context.Insurees
                .FirstOrDefaultAsync(m => m.Id == id);

            if (insuree == null)
            {
                return NotFound();
            }

            return View(insuree);
        }

        // POST: Insurees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insuree = await _context.Insurees.FindAsync(id);

            if (insuree != null)
            {
                _context.Insurees.Remove(insuree);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool InsureeExists(int id)
        {
            return _context.Insurees.Any(e => e.Id == id);
        }
    }
}