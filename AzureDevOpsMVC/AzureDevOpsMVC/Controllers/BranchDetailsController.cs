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
    public class BranchDetailsController : Controller
    {
        private readonly AzureDevOpsMVCContext _context;

        public BranchDetailsController(AzureDevOpsMVCContext context)
        {
            _context = context;
        }

        // GET: BranchDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.BranchDetails.ToListAsync());
        }

        // GET: BranchDetails/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchDetails = await _context.BranchDetails
                .FirstOrDefaultAsync(m => m.Name == id);
            if (branchDetails == null)
            {
                return NotFound();
            }

            return View(branchDetails);
        }

        // GET: BranchDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BranchDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,AheadCount,BehindCount,CommitId,Comment,URL,Author,Commiter,RepoId,ProjectId,Sno")] BranchDetails branchDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branchDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branchDetails);
        }

        // GET: BranchDetails/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchDetails = await _context.BranchDetails.FindAsync(id);
            if (branchDetails == null)
            {
                return NotFound();
            }
            return View(branchDetails);
        }

        // POST: BranchDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,AheadCount,BehindCount,CommitId,Comment,URL,Author,Commiter,RepoId,ProjectId,Sno")] BranchDetails branchDetails)
        {
            if (id != branchDetails.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branchDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchDetailsExists(branchDetails.Name))
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
            return View(branchDetails);
        }

        // GET: BranchDetails/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchDetails = await _context.BranchDetails
                .FirstOrDefaultAsync(m => m.Name == id);
            if (branchDetails == null)
            {
                return NotFound();
            }

            return View(branchDetails);
        }

        // POST: BranchDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var branchDetails = await _context.BranchDetails.FindAsync(id);
            _context.BranchDetails.Remove(branchDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchDetailsExists(string id)
        {
            return _context.BranchDetails.Any(e => e.Name == id);
        }
    }
}
