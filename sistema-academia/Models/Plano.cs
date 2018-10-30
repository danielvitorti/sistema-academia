using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace sistema_academia.Models
{
    public class Plano
    {
        [Key]
        public int id { get; set; }


        
        [Required]
        [Column("nome", TypeName = "varchar(100)")]
        public string nome { get; set; }

        [Required]
        [Column("observacao", TypeName = "varchar(100)")]
        public string observacao { get; set; }



        [Required]
        [Column("formaPagamento", TypeName = "varchar(100)")]
        public string formaPagamento { get; set; }


        
        [Required]
        [Column("valor", TypeName = "decimal(4,2)")]
        public decimal valor { get; set; }


        

        
        [Column("dataCadastro", TypeName = "datetime")]
        public DateTime dataCadastro {get; set;}


        public virtual ICollection<PlanoAluno> PlanosAlunos { get; set; }


        public virtual ICollection<PagamentoAluno> PagamentosAlunos { get; set; }

        


    }

}