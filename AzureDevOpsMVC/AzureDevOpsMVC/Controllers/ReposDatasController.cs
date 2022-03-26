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
    public class ReposDatasController : Controller
    {
        private readonly AzureDevOpsMVCContext _context;

        public ReposDatasController(AzureDevOpsMVCContext context)
        {
            _context = context;
        }

        // GET: ReposDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReposData.ToListAsync());
        }

        // GET: ReposDatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reposData = await _context.ReposData
                .FirstOrDefaultAsync(m => m.ProjectName == id);
            if (reposData == null)
            {
                return NotFound();
            }

            return View(reposData);
        }

        // GET: ReposDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReposDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RepoName,RepoId,RepoURL,DefaultBranch,ProjectName,CommitCount")] ReposData reposData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reposData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reposData);
        }

        // GET: ReposDatas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reposData = await _context.ReposData.FindAsync(id);
            if (reposData == null)
            {
                return NotFound();
            }
            return View(reposData);
        }

        // POST: ReposDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RepoName,RepoId,RepoURL,DefaultBranch,ProjectName,CommitCount")] ReposData reposData)
        {
            if (id != reposData.ProjectName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reposData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReposDataExists(reposData.ProjectName))
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
            return View(reposData);
        }

        // GET: ReposDatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reposData = await _context.ReposData
                .FirstOrDefaultAsync(m => m.ProjectName == id);
            if (reposData == null)
            {
                return NotFound();
            }

            return View(reposData);
        }

        // POST: ReposDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var reposData = await _context.ReposData.FindAsync(id);
            _context.ReposData.Remove(reposData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReposDataExists(string id)
        {
            return _context.ReposData.Any(e => e.ProjectName == id);
        }
    }
}
