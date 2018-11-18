using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistema_academia.Data;
using sistema_academia.Models;

namespace sistema_academia.Controllers
{
    public class ExercicioTreinoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExercicioTreinoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ExercicioTreino
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExercicioTreino.ToListAsync());
        }

        // GET: ExercicioTreino/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercicioTreino = await _context.ExercicioTreino
                .FirstOrDefaultAsync(m => m.id == id);
            if (exercicioTreino == null)
            {
                return NotFound();
            }

            return View(exercicioTreino);
        }

        // GET: ExercicioTreino/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExercicioTreino/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,peso,tempo,observacao,dataCadastro")] ExercicioTreino exercicioTreino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exercicioTreino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exercicioTreino);
        }

        // GET: ExercicioTreino/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercicioTreino = await _context.ExercicioTreino.FindAsync(id);
            if (exercicioTreino == null)
            {
                return NotFound();
            }
            return View(exercicioTreino);
        }

        // POST: ExercicioTreino/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,peso,tempo,observacao,dataCadastro")] ExercicioTreino exercicioTreino)
        {
            if (id != exercicioTreino.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exercicioTreino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExercicioTreinoExists(exercicioTreino.id))
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
            return View(exercicioTreino);
        }

        // GET: ExercicioTreino/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exercicioTreino = await _context.ExercicioTreino
                .FirstOrDefaultAsync(m => m.id == id);
            if (exercicioTreino == null)
            {
                return NotFound();
            }

            return View(exercicioTreino);
        }

        // POST: ExercicioTreino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exercicioTreino = await _context.ExercicioTreino.FindAsync(id);
            _context.ExercicioTreino.Remove(exercicioTreino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExercicioTreinoExists(int id)
        {
            return _context.ExercicioTreino.Any(e => e.id == id);
        }
    }
}
