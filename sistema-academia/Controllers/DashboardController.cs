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
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            /*
                var count = context.MyContainer
            .Where(o => o.ID == '1')
            .SelectMany(o => o.MyTable)
            .Count()
             */
            //return View(await _context.Aluno.ToListAsync());

            var countAlunos = _context.Aluno.Count();
            ViewData["countAlunos"] = countAlunos;


            var countAlunosAtivos = _context.Aluno.Count(a => a.situacaoAluno.Equals("1"));
            ViewData["countAlunosAtivos"] = countAlunosAtivos;
            return View();
        
        }


    }
}    