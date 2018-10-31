using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sistema_academia.Models;

namespace sistema_academia.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Aluno> Aluno{ get; set;}
        public virtual DbSet<Treino> Treino{ get; set;}
        public virtual DbSet<ExercicioTreino> ExercicioTreino{ get; set;}
        public virtual DbSet<Plano> Plano{ get; set;}
        public virtual DbSet<PlanoAluno> PlanoAluno{ get; set;}

        public virtual DbSet<PresencaAluno> PresencaAluno{ get; set;}

    }
}
