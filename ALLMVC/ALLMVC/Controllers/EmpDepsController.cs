using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ALLMVC.Data;
using ALLMVC.Models;

namespace ALLMVC.Controllers
{
    public class EmpDepsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpDepsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmpDeps
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmpDep.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> SearchNormal(string Search)
        {
            ViewData["GetEmpDep"] = Search;
            var empdep = from x in _context.EmpDep select x;
            if (!string.IsNullOrEmpty(Search))
            {
                empdep = empdep.Where(e => e.EmpName.Contains(Search) || e.Email.Contains(Search));
            }
            return View(await empdep.AsNoTracking().ToListAsync());
        }

        public ActionResult SearchJquery(string Search)
        {
            //var SearchList = from m in _context.EmpDep
            //                 select m;
            //if (!String.IsNullOrEmpty(Search))
            //{
            //    SearchList = SearchList.Where(s => s.Name.Contains(Search));
            //}
            //if (!String.IsNullOrEmpty(Search))
            //{
            //    SearchList = SearchList.Where(s => s.EmpName.Contains(Search));
            //}
            //return View(SearchList);

            return View(_context.EmpDep.ToList());
        }
        // GET: EmpDeps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empDep = await _context.EmpDep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empDep == null)
            {
                return NotFound();
            }

            return View(empDep);
        }

        // GET: EmpDeps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmpDeps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Location,EmpName,Email,DepartmentId")] EmpDep empDep)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empDep);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empDep);
        }

        // GET: EmpDeps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empDep = await _context.EmpDep.FindAsync(id);
            if (empDep == null)
            {
                return NotFound();
            }
            return View(empDep);
        }

        // POST: EmpDeps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Location,EmpName,Email,DepartmentId")] EmpDep empDep)
        {
            if (id != empDep.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empDep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpDepExists(empDep.Id))
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
            return View(empDep);
        }

        // GET: EmpDeps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empDep = await _context.EmpDep
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empDep == null)
            {
                return NotFound();
            }

            return View(empDep);
        }

        // POST: EmpDeps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empDep = await _context.EmpDep.FindAsync(id);
            _context.EmpDep.Remove(empDep);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpDepExists(int id)
        {
            return _context.EmpDep.Any(e => e.Id == id);
        }
    }
}
