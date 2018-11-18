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
    public class PagamentoAlunoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagamentoAlunoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PagamentoAluno
        public async Task<IActionResult> Index()
        {
            return View(await _context.PagamentoAluno.ToListAsync());
        }

        // GET: PagamentoAluno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoAluno = await _context.PagamentoAluno
                .FirstOrDefaultAsync(m => m.id == id);
            if (pagamentoAluno == null)
            {
                return NotFound();
            }

            return View(pagamentoAluno);
        }

        // GET: PagamentoAluno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PagamentoAluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,descricao,valor,tipoPagamento")] PagamentoAluno pagamentoAluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pagamentoAluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pagamentoAluno);
        }

        // GET: PagamentoAluno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoAluno = await _context.PagamentoAluno.FindAsync(id);
            if (pagamentoAluno == null)
            {
                return NotFound();
            }
            return View(pagamentoAluno);
        }

        // POST: PagamentoAluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,descricao,valor,tipoPagamento")] PagamentoAluno pagamentoAluno)
        {
            if (id != pagamentoAluno.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pagamentoAluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PagamentoAlunoExists(pagamentoAluno.id))
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
            return View(pagamentoAluno);
        }

        // GET: PagamentoAluno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pagamentoAluno = await _context.PagamentoAluno
                .FirstOrDefaultAsync(m => m.id == id);
            if (pagamentoAluno == null)
            {
                return NotFound();
            }

            return View(pagamentoAluno);
        }

        // POST: PagamentoAluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pagamentoAluno = await _context.PagamentoAluno.FindAsync(id);
            _context.PagamentoAluno.Remove(pagamentoAluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PagamentoAlunoExists(int id)
        {
            return _context.PagamentoAluno.Any(e => e.id == id);
        }
    }
}
