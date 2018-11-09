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
        public async Task<IActionResult> Index(string txtNomePlano = "")
        {
             if(txtNomePlano !="")
            {
            
                var planos = await _context.Plano.Where(a => a.nome.Contains(txtNomePlano)).ToListAsync().ConfigureAwait(false);

                return View(planos);
            }
            else
            {

                return View(await _context.Plano.ToListAsync());
            }
        }

        // GET: Plano/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plano/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,observacao,formaPagamento,valor")] Plano plano)
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
        public async Task<IActionResult> Edit(int? id)
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
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,observacao,formaPagamento,valor,dataCadastro")] Plano plano)
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
        public async Task<IActionResult> Delete(int? id)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
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


        public ActionResult ListaPlanosJson()
        {
            

            Dictionary<string, string> listaNova = new Dictionary<string, string>();

            foreach(var lista in _context.Plano.ToList())
            {

                listaNova.Add("id",lista.id.ToString());
                listaNova.Add("text",lista.nome);

            }

            ArrayList arrayList = new ArrayList();
            arrayList.Add(listaNova);

            
            return Json(arrayList);

        }

    }
}
