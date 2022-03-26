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
    public class ProjectsDatasController : Controller
    {
        private readonly AzureDevOpsMVCContext _context;

        public ProjectsDatasController(AzureDevOpsMVCContext context)
        {
            _context = context;
        }

        // GET: ProjectsDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectsData.ToListAsync());
        }

        // GET: ProjectsDatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectsData = await _context.ProjectsData
                .FirstOrDefaultAsync(m => m.ProjectName == id);
            if (projectsData == null)
            {
                return NotFound();
            }

            return View(projectsData);
        }

        // GET: ProjectsDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectsDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProjectName,ProjectId,Description,URL,ReposCount")] ProjectsData projectsData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectsData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectsData);
        }

        // GET: ProjectsDatas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectsData = await _context.ProjectsData.FindAsync(id);
            if (projectsData == null)
            {
                return NotFound();
            }
            return View(projectsData);
        }

        // POST: ProjectsDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ProjectName,ProjectId,Description,URL,ReposCount")] ProjectsData projectsData)
        {
            if (id != projectsData.ProjectName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectsData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectsDataExists(projectsData.ProjectName))
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
            return View(projectsData);
        }

        // GET: ProjectsDatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectsData = await _context.ProjectsData
                .FirstOrDefaultAsync(m => m.ProjectName == id);
            if (projectsData == null)
            {
                return NotFound();
            }

            return View(projectsData);
        }

        // POST: ProjectsDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var projectsData = await _context.ProjectsData.FindAsync(id);
            _context.ProjectsData.Remove(projectsData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectsDataExists(string id)
        {
            return _context.ProjectsData.Any(e => e.ProjectName == id);
        }
    }
}
