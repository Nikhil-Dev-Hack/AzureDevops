using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AzureDevOpsMVC.Data;
using AzureDevOpsMVC.Models;

namespace AzureDevOpsMVC.Controllers
{
    public class ProjectDetailsController : Controller
    {
        private readonly AzureDevOpsMVCContext _context;

        public ProjectDetailsController(AzureDevOpsMVCContext context)
        {
            _context = context;
        }

        // GET: ProjectDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectDetails.ToListAsync());
        }

        // GET: ProjectDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectDetails = await _context.ProjectDetails
                .FirstOrDefaultAsync(m => m.URL == id);
            if (projectDetails == null)
            {
                return NotFound();
            }

            return View(projectDetails);
        }

        // GET: ProjectDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("URL,Token")] ProjectDetails projectDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectDetails);
        }

        // GET: ProjectDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectDetails = await _context.ProjectDetails.FindAsync(id);
            if (projectDetails == null)
            {
                return NotFound();
            }
            return View(projectDetails);
        }

        // POST: ProjectDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("URL,Token")] ProjectDetails projectDetails)
        {
            if (id != projectDetails.URL)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectDetailsExists(projectDetails.URL))
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
            return View(projectDetails);
        }

        // GET: ProjectDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectDetails = await _context.ProjectDetails
                .FirstOrDefaultAsync(m => m.URL == id);
            if (projectDetails == null)
            {
                return NotFound();
            }

            return View(projectDetails);
        }

        // POST: ProjectDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var projectDetails = await _context.ProjectDetails.FindAsync(id);
            _context.ProjectDetails.Remove(projectDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectDetailsExists(string id)
        {
            return _context.ProjectDetails.Any(e => e.URL == id);
        }
    }
}
