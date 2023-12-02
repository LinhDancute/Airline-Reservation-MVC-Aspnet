using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Models;
using App.Models.Airline;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace App.Areas.Airline.Controllers
{
    [Area("Airline")]
    [Route("admin/airline/flightroute/[action]/{id?}")]
    [Authorize(Roles = RoleName.Administrator)]
    public class FlightRouteController : Controller
    {
        private readonly AppDbContext _context;

        public FlightRouteController(AppDbContext context)
        {
            _context = context;
        }
        // GET: FlightRoute
        public async Task<IActionResult> Index()
        {
            var flightRoutes = await _context.FlightRoutes.ToListAsync();
            return View(flightRoutes);
        }

        // GET: FlightRoute/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightRoute = await _context.FlightRoutes
                .FirstOrDefaultAsync(m => m.FlightRouteId == id);

            if (flightRoute == null)
            {
                return NotFound();
            }

            return View(flightRoute);
        }

        // GET: FlightRoute/Create
        public IActionResult Create()
        {
            ViewBag.Airports = _context.Airports.ToList();
            return View();
        }

        // POST: FlightRoute/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartureAddress,ArrivalAddress,Gate,Status")] FlightRoute flightRoute)
        {
            if (ModelState.IsValid)
            {
                var departureAirport = await _context.Airports.FirstOrDefaultAsync(a => a.Abbreviation == flightRoute.DepartureAddress);
                var arrivalAirport = await _context.Airports.FirstOrDefaultAsync(a => a.Abbreviation == flightRoute.ArrivalAddress);

                if (departureAirport != null && departureAirport.Status == App.Models.Airline.Airport.AirportStatus.Closed)
                {
                    ModelState.AddModelError("DepartureAddress", "Điểm đi đã đóng cửa.");
                }

                if (arrivalAirport != null && arrivalAirport.Status == App.Models.Airline.Airport.AirportStatus.Closed)
                {
                    ModelState.AddModelError("ArrivalAddress", "Điểm đến đã đóng cửa.");
                }

                if (ModelState.IsValid)
                {
                    if (flightRoute.DepartureAddress == flightRoute.ArrivalAddress)
                    {
                        ModelState.AddModelError("ArrivalAddress", "Điểm đi phải khác điểm đến.");
                        ViewBag.Airports = _context.Airports.ToList();
                        return View(flightRoute);
                    }

                    _context.Add(flightRoute);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }

            ViewBag.Airports = _context.Airports.ToList();
            return View(flightRoute);
        }

        // GET: FlightRoute/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightRoute = await _context.FlightRoutes.FindAsync(id);

            if (flightRoute == null)
            {
                return NotFound();
            }

            // Ensure that ViewBag.Airports is properly populated
            ViewBag.Airports = _context.Airports.ToList();

            return View(flightRoute);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlightRouteId,DepartureAddress,ArrivalAddress,Gate,Status")] FlightRoute flightRoute)
        {
            if (id != flightRoute.FlightRouteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var departureAirport = await _context.Airports.FirstOrDefaultAsync(a => a.Abbreviation == flightRoute.DepartureAddress);
                var arrivalAirport = await _context.Airports.FirstOrDefaultAsync(a => a.Abbreviation == flightRoute.ArrivalAddress);

                // Check if either the departure or arrival airport is closed
                if (departureAirport != null && departureAirport.Status == App.Models.Airline.Airport.AirportStatus.Closed)
                {
                    ModelState.AddModelError("DepartureAddress", "Điểm đi đã đóng cửa.");
                }

                if (arrivalAirport != null && arrivalAirport.Status == App.Models.Airline.Airport.AirportStatus.Closed)
                {
                    ModelState.AddModelError("ArrivalAddress", "Điểm đến đã đóng cửa.");
                }

                // Check if departure and arrival addresses are the same
                if (flightRoute.DepartureAddress == flightRoute.ArrivalAddress)
                {
                    ModelState.AddModelError("ArrivalAddress", "Điểm đi phải khác điểm đến.");
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(flightRoute);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!FlightRouteExists(flightRoute.FlightRouteId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }

            // Repopulate ViewBag.Airports for the view
            ViewBag.Airports = _context.Airports.ToList();
            return View(flightRoute);
        }



        // GET: FlightRoute/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightRoute = await _context.FlightRoutes
                .FirstOrDefaultAsync(m => m.FlightRouteId == id);

            if (flightRoute == null)
            {
                return NotFound();
            }

            return View(flightRoute);
        }

        // POST: FlightRoute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flightRoute = await _context.FlightRoutes.FindAsync(id);
            _context.FlightRoutes.Remove(flightRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightRouteExists(int id)
        {
            return _context.FlightRoutes.Any(e => e.FlightRouteId == id);
        }
    }
}