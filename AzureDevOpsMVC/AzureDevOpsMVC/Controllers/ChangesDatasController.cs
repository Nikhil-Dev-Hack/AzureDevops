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
    public class ChangesDatasController : Controller
    {
        private readonly AzureDevOpsMVCContext _context;

        public ChangesDatasController(AzureDevOpsMVCContext context)
        {
            _context = context;
        }

        // GET: ChangesDatas
        public async Task<IActionResult> Index(int? Page_No)
        {
            return View(await _context.ChangesData.ToListAsync());
        }

        // GET: ChangesDatas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changesData = await _context.ChangesData
                .FirstOrDefaultAsync(m => m.CommitId == id);
            if (changesData == null)
            {
                return NotFound();
            }

            return View(changesData);
        }

        // GET: ChangesDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChangesDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommitId,RepoId,ObjectId,Url,Path,Chnagetype,Sno")] ChangesData changesData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(changesData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(changesData);
        }

        // GET: ChangesDatas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changesData = await _context.ChangesData.FindAsync(id);
            if (changesData == null)
            {
                return NotFound();
            }
            return View(changesData);
        }

        // POST: ChangesDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CommitId,RepoId,ObjectId,Url,Path,Chnagetype,Sno")] ChangesData changesData)
        {
            if (id != changesData.CommitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(changesData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChangesDataExists(changesData.CommitId))
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
            return View(changesData);
        }

        // GET: ChangesDatas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var changesData = await _context.ChangesData
                .FirstOrDefaultAsync(m => m.CommitId == id);
            if (changesData == null)
            {
                return NotFound();
            }

            return View(changesData);
        }

        // POST: ChangesDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var changesData = await _context.ChangesData.FindAsync(id);
            _context.ChangesData.Remove(changesData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChangesDataExists(string id)
        {
            return _context.ChangesData.Any(e => e.CommitId == id);
        }
    }
}
