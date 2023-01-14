using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using universe.Models;

namespace universe.Controllers
{
    public class HomeController : Controller
    {
        UniversityDBContext db;
        public HomeController(UniversityDBContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public IActionResult create_audience()
        {
            return View();
        }
        public IActionResult create_building()
        {
            return View();
        }
        public IActionResult create_responsible()
        {
            return View();
        }
        public IActionResult create_property()
        {
            return View();
        }
        public IActionResult create_department()
        {
            return View();
        }
        public async Task<IActionResult> audienceAsync()
        {
            return View(await db.Audiences.ToListAsync());
        }
        public async Task<IActionResult> buildingAsync()
        {
            return View(await db.Buildings.ToListAsync());
        }
        public async Task<IActionResult> departmentAsync()
        {
            return View(await db.Departments.ToListAsync());
        }
        public async Task<IActionResult> responsibleAsync()
        {
            return View(await db.Responsibles.ToListAsync());
        }
        public async Task<IActionResult> propertyAsync()
        {
            return View(await db.Properties.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> create_audience(Audience audience)
        {
            db.Audiences.Add(audience);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> create_building(Building building)
        {
            db.Buildings.Add(building);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> create_department(Department department)
        {
            db.Departments.Add(department);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> create_responsible(Responsible responsible)
        {
            db.Responsibles.Add(responsible);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> create_property(Property property)
        {
            db.Properties.Add(property);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Audience audience = new Audience { AudienceId = id.Value };
                db.Entry(audience).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> edit_audience(int? id)
        {
            if (id != null)
            {
                Audience? audience = await db.Audiences.FirstOrDefaultAsync(p => p.AudienceId == id);
                if (audience != null) return View(audience);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Audience audience)
        {
            db.Audiences.Update(audience);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}