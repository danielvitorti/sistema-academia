using System;
using System.Collections.Generic;
using System.Collections;
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
    public class PlanoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Plano
        public async Task<IActionResult> Index(string ordem, 
            string filtroAtual,
            string filtro, 
            int? pagina)
        {

            ViewData["NomeParam"] = String.IsNullOrEmpty(ordem) ? "nome_desc" : "";
            ViewData["IdParam"] = ordem == "Id" ? "id_desc" : "Id";
            ViewData["filtro"] = filtro;

        
        
            var planos = from pln in _context.Plano
                         select pln;

            if (!String.IsNullOrEmpty(filtro))
            {
                planos = planos.Where(s => s.nome.Contains(filtro)
                                       || s.observacao.Contains(filtro));
            }


            switch (ordem)
            {
                case "nome_desc":
                    planos = planos.OrderByDescending(pln => pln.nome);
                    break;
                case "Id":
                    planos = planos.OrderBy(pln => pln.id);
                    break;
                case "id_desc":
                    planos = planos.OrderByDescending(pln => pln.id);
                    break;
                default:
                    planos = planos.OrderBy(pln => pln.nome);
                    break;
            }

        
                int pageSize = 10;
                return View(await PaginatedList<Plano>.CreateAsync(planos.AsNoTracking(), pagina ?? 1, pageSize));
        
            
        }

        // GET: Plano/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano
                .FirstOrDefaultAsync(m => m.id == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // GET: Plano/Create
        public IActionResult Cadastrar()
        {
            return View();
        }

        // POST: Plano/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("id,nome,observacao,formaPagamento,valor")] Plano plano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(plano);
        }

        // GET: Plano/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano.FindAsync(id);
            if (plano == null)
            {
                return NotFound();
            }
            return View(plano);
        }

        // POST: Plano/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("id,nome,observacao,formaPagamento,valor,dataCadastro")] Plano plano)
        {
            if (id != plano.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanoExists(plano.id))
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
            return View(plano);
        }

        // GET: Plano/Delete/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plano = await _context.Plano
                .FirstOrDefaultAsync(m => m.id == id);
            if (plano == null)
            {
                return NotFound();
            }

            return View(plano);
        }

        // POST: Plano/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmed(int id)
        {
            var plano = await _context.Plano.FindAsync(id);
            _context.Plano.Remove(plano);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanoExists(int id)
        {
            return _context.Plano.Any(e => e.id == id);
        }
        
        
        public ActionResult BuscaPlanoJsonPorId(string id)
        {

            var plano = _context.Plano.Find(Convert.ToInt32(id));

            return Json(plano);

        }

        public ActionResult ListaPlanosJson(string q)
        {

            Dictionary<dynamic,dynamic> result = new Dictionary<dynamic,dynamic>();
            Dictionary<dynamic,dynamic> resultPlanos = new Dictionary<dynamic,dynamic>();
            ArrayList resultArrPlanos = new ArrayList();                

            var planos = from pln in _context.Plano
                         select pln;


            if (!String.IsNullOrEmpty(q))
            {
                planos = planos.Where(s => s.nome.Contains(q));
                                       
            }

            foreach( var plano in planos)
            {
                resultPlanos["id"] = plano.id;
                resultPlanos["name"] = plano.nome;
            }

            resultArrPlanos.Add(resultPlanos);
            
            result.Add("total_count",planos.Count());
            result.Add("incomplete_results",false);
            result.Add("items",resultArrPlanos);

            return Json(result);

        }

    }
}
