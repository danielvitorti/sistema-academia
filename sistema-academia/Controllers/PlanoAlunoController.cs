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
    public class PlanoAlunoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanoAlunoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlanoAluno
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanoAluno.ToListAsync());
        }

        // GET: PlanoAluno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoAluno = await _context.PlanoAluno
                .FirstOrDefaultAsync(m => m.id == id);
            if (planoAluno == null)
            {
                return NotFound();
            }

            return View(planoAluno);
        }

        // GET: PlanoAluno/Create
        public IActionResult Create()
        {
            ViewBag.Planos =  _context.Plano.ToList();
            ViewBag.Alunos = _context.Aluno.ToList();
            return View();
        }

        // POST: PlanoAluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,plano,aluno,dataCadastro")] PlanoAluno planoAluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planoAluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planoAluno);
        }

        // GET: PlanoAluno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoAluno = await _context.PlanoAluno.FindAsync(id);
            if (planoAluno == null)
            {
                return NotFound();
            }
            return View(planoAluno);
        }

        // POST: PlanoAluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,dataCadastro")] PlanoAluno planoAluno)
        {
            if (id != planoAluno.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planoAluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoAlunoExists(planoAluno.id))
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
            return View(planoAluno);
        }

        // GET: PlanoAluno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planoAluno = await _context.PlanoAluno
                .FirstOrDefaultAsync(m => m.id == id);
            if (planoAluno == null)
            {
                return NotFound();
            }

            return View(planoAluno);
        }

        // POST: PlanoAluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planoAluno = await _context.PlanoAluno.FindAsync(id);
            _context.PlanoAluno.Remove(planoAluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoAlunoExists(int id)
        {
            return _context.PlanoAluno.Any(e => e.id == id);
        }

        
        public ActionResult ListaPlanoJsonPorId(string id)
        {

            var planos = _context.PlanoAluno
                         .Include(planoAluno => planoAluno.Plano)                       
                         .Where(s => s.Aluno.id == Convert.ToInt32(id))
                         .ToList();

            this.HttpContext.Response.StatusCode = 200;                                                                                 

            return Json(planos);

        }

    }
}
