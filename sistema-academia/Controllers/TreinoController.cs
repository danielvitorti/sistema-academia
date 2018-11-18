using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistema_academia.Data;
using sistema_academia.Models;
using sistema_academia;

namespace sistema_academia.Controllers
{
    public class TreinoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreinoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Treino
        public async Task<IActionResult> Index(string ordem, 
            string filtroAtual,
            string filtro, 
            int? pagina)
        {

            
            ViewData["NomeParam"] = String.IsNullOrEmpty(ordem) ? "nome_desc" : "";
            ViewData["IdParam"] = ordem == "Id" ? "id_desc" : "Id";
            ViewData["filtro"] = filtro;

        
        
            var treinos = from trn in _context.Treino
                         select trn;

            if (!String.IsNullOrEmpty(filtro))
            {
                treinos = treinos.Where(s => s.nome.Contains(filtro));
                                       
            }


            switch (ordem)
            {
                case "nome_desc":
                    treinos = treinos.OrderByDescending(trn => trn.nome);
                    break;
                case "Id":
                    treinos = treinos.OrderBy(trn => trn.id);
                    break;
                case "id_desc":
                    treinos = treinos.OrderByDescending(trn => trn.id);
                    break;
                default:
                    treinos = treinos.OrderBy(trn => trn.nome);
                    break;
            }

        
            int pageSize = 10;
            
            return View(await PaginatedList<Treino>.CreateAsync(treinos.AsNoTracking(), pagina ?? 1, pageSize));
        

        }

        // GET: Treino/Detalhes/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treino = await _context.Treino
                .FirstOrDefaultAsync(m => m.id == id);
            if (treino == null)
            {
                return NotFound();
            }

            return View(treino);
        }

        // GET: Treino/Cadastrar
        public IActionResult Cadastrar()
        {
            return View();
        }

        // POST: Treino/Cadastrar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("id,nome,objetivo,observacao")] Treino treino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(treino);
        }

        // GET: Treino/Editar/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treino = await _context.Treino.FindAsync(id);
            if (treino == null)
            {
                return NotFound();
            }
            return View(treino);
        }

        // POST: Treino/Editar/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more Detalhes see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("id,nome,objetivo,observacao")] Treino treino)
        {
            if (id != treino.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinoExists(treino.id))
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
            return View(treino);
        }

        // GET: Treino/Excluir/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var treino = await _context.Treino
                .FirstOrDefaultAsync(m => m.id == id);
            if (treino == null)
            {
                return NotFound();
            }

            return View(treino);
        }

        // POST: Treino/Excluir/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmed(int id)
        {
            var treino = await _context.Treino.FindAsync(id);
            _context.Treino.Remove(treino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinoExists(int id)
        {
            return _context.Treino.Any(e => e.id == id);
        }
    }
}
