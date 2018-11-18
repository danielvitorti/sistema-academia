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
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlunosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alunos
        public async Task<IActionResult> Index(string ordem, 
            string filtroAtual,
            string filtro, 
            int? pagina)
        {
            

            ViewData["NomeParam"] = String.IsNullOrEmpty(ordem) ? "nome_desc" : "";
            ViewData["IdParam"] = ordem == "Id" ? "id_desc" : "Id";
            ViewData["filtro"] = filtro;

        
        
            var alunos = from aln in _context.Aluno
                         select aln;

            if (!String.IsNullOrEmpty(filtro))
            {
                alunos = alunos.Where(s => s.nome.Contains(filtro));
                                       
            }


            switch (ordem)
            {
                case "nome_desc":
                    alunos = alunos.OrderByDescending(aln => aln.nome);
                    break;
                case "Id":
                    alunos = alunos.OrderBy(aln => aln.id);
                    break;
                case "id_desc":
                    alunos = alunos.OrderByDescending(aln => aln.id);
                    break;
                default:
                    alunos = alunos.OrderBy(aln => aln.nome);
                    break;
            }

        
                int pageSize = 10;
                return View(await PaginatedList<Aluno>.CreateAsync(alunos.AsNoTracking(), pagina ?? 1, pageSize));
        
        }


        // GET: Alunos/Details/5
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            if(aluno.sexo.Equals('1'))
            {
                ViewData["sexo"] = "Masculino";
            }
            else if(aluno.sexo.Equals("2"))
            {
                ViewData["sexo"] = "Feminino";
            }

            return View(aluno);
        }

        // GET: Alunos/Create
        public IActionResult Cadastrar()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar([Bind("id,nome,sexo,enderecoCep,enderecoRua,enderecoNumero,enderecoBairro,enderecoCidade,enderecoEstado,situacaoAluno,diaVencimento")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aluno);
        }

        // GET: Alunos/Edit/5
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno.FindAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("id,nome,sexo,enderecoCep,enderecoRua,enderecoNumero,enderecoBairro,enderecoCidade,enderecoEstado,dataCadastro")] Aluno aluno)
        {
            if (id != aluno.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlunoExists(aluno.id))
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
            return View(aluno);
        }

        // GET: Alunos/Delete/5
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluno = await _context.Aluno
                .FirstOrDefaultAsync(m => m.id == id);
            if (aluno == null)
            {
                return NotFound();
            }

            if(aluno.sexo.Equals('1'))
            {
                ViewData["sexo"] = "Masculino";
            }
            else if(aluno.sexo.Equals("2"))
            {
                ViewData["sexo"] = "Feminino";
            }


            return View(aluno);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmed(int id)
        {
            var aluno = await _context.Aluno.FindAsync(id);
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlunoExists(int id)
        {
            return _context.Aluno.Any(e => e.id == id);
        }


        public ActionResult ListaAlunosJson(){

            return Json(_context.Aluno.ToList());
        }
    }
}
