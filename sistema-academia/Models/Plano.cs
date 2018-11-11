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
        [Display(Name = "Nome")]
        public string nome { get; set; }

        
        [Column("observacao", TypeName = "varchar(100)")]
        [Display(Name = "Observação")]
        public string observacao { get; set; }



        [Required]
        [Column("formaPagamento", TypeName = "varchar(100)")]
        [Display(Name = "Forma de pagamento")]
        public string formaPagamento { get; set; }


        
        [Required]
        [Column("valor", TypeName = "decimal(10,4)")]
        [Display(Name = "Valor")]
        public decimal valor { get; set; }


        

        
        [Column("dataCadastro", TypeName = "datetime")]
        [Display(Name = "Data de cadastro")]
        public DateTime dataCadastro {get; set;}


        public virtual ICollection<PlanoAluno> PlanosAlunos { get; set; }


        public virtual ICollection<PagamentoAluno> PagamentosAlunos { get; set; }

        

        public Plano ()
        {
            this.dataCadastro =  System.DateTime.Now;
        }

        


    }

}