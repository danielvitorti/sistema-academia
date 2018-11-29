using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sistema_academia.Models
{
    public class PlanoAluno
    {
        
        [Key]
        public int id { get; set; }

        public virtual Aluno Aluno { get; set; }

        public virtual Plano Plano { get; set; }


        [Column("dataCadastro", TypeName = "datetime")]
        public DateTime dataCadastro {get; set;}


        public PlanoAluno()
        {
            this.dataCadastro = System.DateTime.Now;
        }

        
    }


}